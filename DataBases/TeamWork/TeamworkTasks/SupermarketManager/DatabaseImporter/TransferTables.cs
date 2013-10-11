using MySQLStore;
using SQLStore.Data;
using System;
using System.Linq;

namespace SupermarketManager.DatabaseImporter
{
    class TransferTables
    {
        public void TransferFromMySqlToSqlServer(bool deleteTables = true)
        {
            using (var mySqlStore = new StoreModel())
            {
                using (var sqlStore = new SQLStoreDb())
                {
                    if (deleteTables)
                    {
                        this.DeleteTables(sqlStore);
                    }

                    foreach (var mySqlVendor in mySqlStore.Vendors)
                    {
                        sqlStore.Vendors.Add(new SQLStore.Model.Vendor()
                        {
                            Id = mySqlVendor.ID,
                            VendorName = mySqlVendor.Name
                        });
                    }

                    foreach (var mySqlMeasure in mySqlStore.Measures)
                    {
                        sqlStore.Measures.Add(new SQLStore.Model.Measure()
                        {
                            Id = mySqlMeasure.ID,
                            MeasureName = mySqlMeasure.Name
                        });
                    }

                    foreach (var mySqlProduct in mySqlStore.Products)
                    {
                        sqlStore.Products.Add(new SQLStore.Model.Product()
                        {
                            Id = mySqlProduct.ID,
                            ProductName = mySqlProduct.Name,
                            BasePrice = mySqlProduct.Price,
                            MeasureId = mySqlProduct.MeasureID,
                            VendorId = mySqlProduct.VendorID
                        });
                    }

                    sqlStore.SaveChanges();
                }
            }

        }

        public void DeleteTables(SQLStoreDb sqlStore)
        {
            try
            {
                sqlStore.Database.ExecuteSqlCommand("Delete FROM Products");
                sqlStore.Database.ExecuteSqlCommand("Delete FROM Measures");
                sqlStore.Database.ExecuteSqlCommand("Delete FROM Vendors");
                sqlStore.Database.ExecuteSqlCommand("Delete FROM Sales");
                sqlStore.Database.ExecuteSqlCommand("Delete FROM SaleDates");
                sqlStore.Database.ExecuteSqlCommand("Delete FROM Locations");
                sqlStore.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine("Tables already exist.");
                Console.WriteLine(e.Message);
            }
        }
    }
}
