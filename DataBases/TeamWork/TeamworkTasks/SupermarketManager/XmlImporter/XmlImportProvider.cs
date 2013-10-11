using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using SupermarketManager.MongoExporter;
using MongoDB.Driver;

namespace SupermarketManager.XmlImporter
{
    class XmlImportProvider
    {
        public static void SaveToMongoDb(Dictionary<string, Dictionary<DateTime, Decimal>> vendorExpensesDateAndPrice)
        {
            MongoReporter mongo = new MongoReporter();

            MongoDatabase db = mongo.GetDbConnection();
            string dbExpensesName = "Expenses";
            var expenses = db.GetCollection<MongoProduct>(dbExpensesName);
            expenses.Drop();

            foreach (KeyValuePair<string, Dictionary<DateTime, decimal>> gadost in vendorExpensesDateAndPrice)
            {
                string vendorName = gadost.Key;
                foreach (var datePrice in gadost.Value)
                {
                    DateTime date = datePrice.Key;
                    Decimal price = datePrice.Value;

                    mongo.PlaceExpense(date, vendorName, price);
                }
            }
        }

        public static Dictionary<string, Dictionary<DateTime, Decimal>> ParseFile(string inputPath)
        {
            XDocument xmlDoc = XDocument.Load(inputPath);
            var sales =
                from sale in xmlDoc.Descendants("sale")
                select sale;

            var expensesData = new Dictionary<string, Dictionary<DateTime, Decimal>>();

            foreach (var item in sales)
            {
                var expenses = GetExpenses(item);
                var vendorName = item.Attribute("vendor").Value;
                expensesData.Add(vendorName, expenses);
            }

            return expensesData;
        }

        private static Dictionary<DateTime, Decimal> GetExpenses(XElement item)
        {
            var expenses = new Dictionary<DateTime, Decimal>();
            System.Threading.Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            foreach (var child in item.Elements())
            {
                var monthAsString = "01-" + child.Attribute("month").Value;
                var month = DateTime.Parse(monthAsString);
                var price = decimal.Parse(child.Value);
                expenses.Add(month, price);
            }
            return expenses;
        }
    }
}
