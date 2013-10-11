using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLStore.Data;
using SQLStore.Model;
using MongoDB.Bson.IO;
using System.IO;

namespace SupermarketManager.MongoExporter
{
    public class MongoReporter
    {
        public void ReportProducts(SQLStoreDb msSqlContext)
        {
            MongoDatabase db = this.GetDbConnection();

            var products = db.GetCollection<MongoProduct>("Products");
            products.Drop();
            products = db.GetCollection<MongoProduct>("Products");

            var msProducts = msSqlContext.Products.ToList();
            string dirName = "ProductReports";
            Directory.CreateDirectory(dirName);

            foreach (var msProduct in msProducts)
            {
                int soldQuantities = QuantitiesSold(msProduct, msSqlContext);

                MongoProduct product = new MongoProduct(msProduct.Id, msProduct.ProductName, msProduct.Vendor.VendorName,
                    soldQuantities, soldQuantities * msProduct.BasePrice);

                products.Insert<MongoProduct>(product);

                using (StreamWriter writer = new StreamWriter(dirName + "/" + product.ProductId + ".json"))
                {
                    writer.Write("{");
                    writer.WriteLine(String.Format("\"product-id\": \"{0}\",", product.ProductId.ToString().Replace("\"", "\\\"")));
                    writer.WriteLine(String.Format("\"product-name\": \"{0}\",", product.Name.ToString().Replace("\"", "\\\"")));
                    writer.WriteLine(String.Format("\"vendor-name\": \"{0}\",", product.VendorName.ToString().Replace("\"", "\\\"")));
                    writer.WriteLine(String.Format("\"total-quantity-sold\": \"{0}\",", product.TotalQuantitySold.ToString().Replace("\"", "\\\"")));
                    writer.WriteLine(String.Format("\"total-incomes\": \"{0}\"", product.TotalIncomes.ToString().Replace("\"", "\\\"")) + "}");
                }
            }

            this.PrintProducts();
        }

        public void PlaceExpense(DateTime date, string vendorName, decimal amount)
        {
            MongoDatabase db = this.GetDbConnection();
            string dbExpensesName = "Expenses";
            
            var expenses = db.GetCollection<MongoProduct>(dbExpensesName);

            MongoExpense expense = new MongoExpense(date, vendorName, amount);
            expenses.Insert<MongoExpense>(expense);

            Console.WriteLine("Expence inserted: {0}", expense);
        }

        public static int QuantitiesSold(Product product, SQLStoreDb msContext)
        {
            var sales = msContext.Sales.Where(s => s.Product.Id == product.Id).Select(sa => sa).ToList();
            int quantities = 0;
            foreach (Sale sale in sales)
            {
                quantities += sale.Quantity;
            }

            return quantities;
        }

        public MongoDatabase GetDbConnection()
        {
            var connectionString = "mongodb://localhost/";
            var client = new MongoClient(connectionString);
            var server = client.GetServer();
            return server.GetDatabase("mongo-supermarket");
        }

        public void PrintProducts()
        {
            var db = this.GetDbConnection();
            var products = db.GetCollection<MongoProduct>("Products");
            foreach (var prod in products.AsQueryable<MongoProduct>())
            {
                Console.WriteLine(prod);
                Console.WriteLine();
            }
        }

        public void PrintExpenses()
        {
            var db = this.GetDbConnection();
            var products = db.GetCollection<MongoExpense>("Expenses");
            foreach (var prod in products.AsQueryable<MongoExpense>())
            {
                Console.WriteLine(prod);
                Console.WriteLine();
            }
        }


    }
}
