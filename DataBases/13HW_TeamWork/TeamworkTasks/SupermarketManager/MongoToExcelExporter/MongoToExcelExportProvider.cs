using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using SQLStore.Model;
using SQLStore.Data;
using SupermarketManager.MongoExporter;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using SupermarketManager.Sqlite;

namespace SupermarketManager.MongoToExcelExporter
{
    public class MongoToExcelExportProvider
    {
        static readonly string connection = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source= ..//..//Products-Total-Report.xlsx;
                   Extended Properties=""Excel 12.0 Xml;HDR=YES"";";
        static DateTime now = DateTime.Now;

        static string dayTableName = String.Format("Report{0}{1}{2}{3}{4}", now.Year, now.Month, now.Day, now.Hour, now.Minute);

        private static void CreateTable(OleDbConnection connection)
        {
            OleDbCommand excelCmd = new OleDbCommand(
                "CREATE TABLE " + dayTableName + @" (Vendor string, Income double, Expenses double, 
                Taxes double, [Financial Result] double)", connection);

            excelCmd.ExecuteNonQuery();
        }

        private static void InsertValues(OleDbConnection connection)
        {
            MongoExporter.MongoReporter mongo = new MongoReporter();
            MongoDatabase db = mongo.GetDbConnection();
            SqliteProvider sqlite = new SqliteProvider();

            var vendors = new SQLStoreDb().Vendors;
            foreach (var vendor in vendors)
            {
                var products = db.GetCollection<MongoProduct>("Products").AsQueryable<MongoProduct>().Where(p => p.VendorName == vendor.VendorName).Select(p => p);

                decimal totalIncome = 0.0m;
                decimal taxes = 0.0m;
                foreach (var mongoProduct in products)
                {
                    totalIncome += mongoProduct.TotalIncomes;
                    decimal taxPercent = sqlite.GetProductTax(mongoProduct.Name);
                    taxes += mongoProduct.TotalIncomes * taxPercent;
                }

                var expenses = db.GetCollection<MongoExpense>("Expenses").AsQueryable<MongoExpense>().Where(p => p.VendorName == vendor.VendorName).Select(p => p);
                decimal totalExpenses = 0.0m;
                foreach (var expense in expenses)
                {
                    totalExpenses += expense.Amount;
                }

                //one row
                decimal financialResult = totalIncome - totalExpenses - taxes > 0 ? totalIncome - totalExpenses - taxes : 0;
                
                InsertTableRow(connection, vendor, totalIncome, totalExpenses, taxes, financialResult);
                sqlite.InsertVendorRow(vendor.VendorName, totalIncome, totalExpenses, taxes, financialResult);
            }
        }
  
        private static void InsertTableRow(OleDbConnection connection, Vendor vendor, decimal totalIncome, decimal expenses, decimal taxes, decimal financialResult)
        {
            OleDbCommand excelCmd = new OleDbCommand(
                "INSERT INTO [" + dayTableName + "] (Vendor, Income, Expenses, Taxes, [Financial Result])" +
                "VALUES(@vendor, @income, @expenses, @taxes, @fResult)", connection);
            excelCmd.Parameters.AddWithValue("@vendor", vendor.VendorName);
            excelCmd.Parameters.AddWithValue("@income", (double)totalIncome);
            excelCmd.Parameters.AddWithValue("@expenses", (double)expenses);
            excelCmd.Parameters.AddWithValue("@taxes", (double)taxes);
            excelCmd.Parameters.AddWithValue("@fResult", (double)financialResult);
            excelCmd.ExecuteNonQuery();
        }

        public static void CreateExcelTable()
        {
            OleDbConnection excelCon = new OleDbConnection(connection);
            excelCon.Open();
            using (excelCon)
            {
                CreateTable(excelCon);
                InsertValues(excelCon);
            }
        }
    }
}