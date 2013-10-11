namespace DAO
{
    using System;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Validation;
    using System.Data.SqlClient;
    using System.Diagnostics;
    using System.Linq;

    //No time - no solutions to 7 to 11 :D
    public class DAO
    {
        static void Main()
        {
            //2nd task
            Edit("ANATR", "DSFA"); //check northwind to find a row to edit 
            //Add("Pesh", "ASDF");
            //Delete("CONSH");
            //3rd task
            int year = 1997;
            FindAllCustomers(year, "Canada");
            //4th task
            FindAllCustomersNativeSqlQuery(1997, "Canada");
            //5th task
            FindAllSalesByDateRange("Canada", 1997, 1999);

            //6th task
            #region database clone
            IObjectContextAdapter context = new NorthwindEntities();
            string cloneNorthwind = context.ObjectContext.CreateDatabaseScript();

            string createNorthwindCloneDB = "CREATE DATABASE NorthwindTwin ON PRIMARY " +
            "(NAME = NorthwindTwin, " +
            "FILENAME = 'E:\\NorthwindTwin.mdf', " +
            "SIZE = 5MB, MAXSIZE = 10MB, FILEGROWTH = 10%) " +
            "LOG ON (NAME = NorthwindTwinLog, " +
            "FILENAME = 'E:\\NorthwindTwin.ldf', " +
            "SIZE = 1MB, " +
            "MAXSIZE = 5MB, " +
            "FILEGROWTH = 10%)";

            SqlConnection dbConForCreatingDB = new SqlConnection(
                "Server=LOCALHOST; " +
                "Database=master; " +
                "Integrated Security=true");

            dbConForCreatingDB.Open();

            using (dbConForCreatingDB)
            {
                SqlCommand createDB = new SqlCommand(createNorthwindCloneDB, dbConForCreatingDB);
                createDB.ExecuteNonQuery();
            }

            SqlConnection dbConForCloning = new SqlConnection(
                "Server=LOCALHOST; " +
                "Database=NorthwindTwin; " +
                "Integrated Security=true");

            dbConForCloning.Open();

            using (dbConForCloning)
            {
                SqlCommand cloneDB = new SqlCommand(cloneNorthwind, dbConForCloning);
                cloneDB.ExecuteNonQuery();
            }
            #endregion

        }

        static void Add(string name, string id)
        {
            Customer newCustomer = new Customer()
            {
                CompanyName = name,
                CustomerID = id
            };

            using (NorthwindEntities db = new NorthwindEntities())
            {
                bool isInDB = IsInDataBase(db, id);

                if (!isInDB)
                {
                    try
                    {
                        db.Customers.Add(newCustomer);
                        db.SaveChanges();
                        Console.WriteLine("Added Successful.");
                    }
                    catch (DbEntityValidationException dbEx)
                    {
                        //used to trace f***ed up errors :/
                        foreach (var validationErrors in dbEx.EntityValidationErrors)
                        {
                            foreach (var validationError in validationErrors.ValidationErrors)
                            {
                                Trace.TraceInformation("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);
                            }
                        }
                    }
                   
                }
                else
                {
                    throw new ArgumentException("Such customer already exists");
                }
            }
        }

        static void Edit(string id, string newContactName)
        {
            using (NorthwindEntities db = new NorthwindEntities())
            {
                var customer = db.Customers.Where(x => x.CustomerID == id).FirstOrDefault();
                customer.ContactName = newContactName;
                db.SaveChanges();
            }
        }

        static void Delete(string id)
        {
            using (NorthwindEntities db = new NorthwindEntities())
            {
                var customer = db.Customers.Where(x => x.CustomerID == id).FirstOrDefault();
                db.Customers.Remove(customer);
                db.SaveChanges();
            }
        }

        static bool IsInDataBase(NorthwindEntities db, string id)
        {
            bool alreadyInDB = db.Customers.Where(a => a.CustomerID == id).Any();
            return alreadyInDB;
        }

        //3rd task
        static void FindAllCustomers(int orderDate, string shipDestination)
        {
            using (NorthwindEntities db = new NorthwindEntities())
            {
                var orders = from order in db.Orders
                             where order.OrderDate.Value.Year == orderDate && order.ShipCountry == shipDestination
                             select order;

                foreach (var item in orders)
                {
                    Console.WriteLine("Order made by: {0} with CustomerId: {1}", item.Customer.ContactName, item.Customer.CustomerID);
                }
            }
        }

        static void FindAllCustomersNativeSqlQuery(int orderDate, string country)
        {
            using (NorthwindEntities db = new NorthwindEntities())
            {
                string sqlQuery = @"SELECT c.ContactName from Customers" +
                                  " c INNER JOIN Orders o ON o.CustomerID = c.CustomerID " +
                                  "WHERE (YEAR(o.OrderDate) = {0} AND o.ShipCountry = {1});";

                object[] parameters = { orderDate, country };
                var sqlQueryResult = db.Database.SqlQuery<string>(sqlQuery, parameters);

                foreach (var order in sqlQueryResult)
                {
                    Console.WriteLine(order);
                }
            }
        }

        static void FindAllSalesByDateRange(string region, int startDate, int endDate)
        {
            using (NorthwindEntities db = new NorthwindEntities())
            {
                var sales = from order in db.Orders
                            join orderDetails in db.Order_Details
                            on order.OrderID equals orderDetails.OrderID
                            where (order.ShipRegion == region && order.OrderDate.Value.Year == startDate && order.ShippedDate.Value.Year == endDate)
                            select new
                            {
                                Quantity = orderDetails.Quantity,
                                Region = order.ShipRegion,
                                Country = order.ShipCountry
                            };

                foreach (var sale in sales)
                {
                    Console.WriteLine("Ship Region: {0}, Ship Country: {1}, Order Quantity: {2}",
                                        sale.Region, sale.Country, sale.Quantity);
                }
            }
        }
    }
}