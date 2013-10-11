using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace SupermarketManager.Sqlite
{
    class SqliteProvider
    {
        public decimal GetProductTax(string productName)
        {
            decimal result = 0;

            var dbCon = new SQLiteConnection("Data Source=../../Sqlite/ProductTaxesDb.db");
            dbCon.Open();
            using (dbCon)
            {
                var cmd = new SQLiteCommand("SELECT Tax FROM Taxes WHERE ProductName='" + productName + "'", dbCon);

                using (SQLiteDataReader reader = cmd.ExecuteReader())
                {
                    object num = reader.Read() ? reader["Tax"] : null;                   
                    if (num is Decimal)
                    {
                        result = (decimal)num;
                    }
                }
            }
            Console.WriteLine(result);
            return result;
        }

        public void InsertVendorRow(string vendor, decimal totalIncome, decimal expenses, decimal taxes, decimal financialResult)
        {
            var dbCon = new SQLiteConnection("Data Source=../../Sqlite/ProductTaxesDb.db");
            dbCon.Open();
            using (dbCon)
            {
                var cmd = new SQLiteCommand(
                    String.Format("INSERT INTO VendorFinances VALUES('{0}', {1}, {2}, {3}, {4})",
                        vendor, totalIncome, expenses, taxes, financialResult),
                        dbCon);

                cmd.ExecuteNonQuery();
            }
        }

    }
}
