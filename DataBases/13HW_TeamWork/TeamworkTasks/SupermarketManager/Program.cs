using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySQLStore;
using SQLStore.Data;
using SQLStore.Model;
using System.Data.Entity;
using SupermarketManager.DatabaseImporter;
using SupermarketManager.MongoExporter;
using SupermarketManager.MongoToExcelExporter;
using SupermarketManager.Sqlite;

namespace SupermarketManager
{
    class Program
    {
        static void Main()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<SQLStoreDb, SQLStore.Data.Migrations.Configuration>());

            TransferTables transferTables = new TransferTables();
            transferTables.TransferFromMySqlToSqlServer(deleteTables: true);

            TransferFromExcel transferExcel = new TransferFromExcel();
            transferExcel.ParseExcelZip("../../../Sample-Sales-Reports.zip");

            PdfExporter.PdfExportProvider.ToPdf(new SQLStoreDb(), "DateSalesReport.pdf");

            XmlExporter.XmlExportProvider.ToXml(new SQLStoreDb(), "Reports.xml");

            var info = XmlImporter.XmlImportProvider.ParseFile("../../../Vendors-Expenses.xml");
            XmlImporter.XmlImportProvider.SaveToMongoDb(info);

            MongoReporter mongoReporter = new MongoReporter();
            mongoReporter.ReportProducts(new SQLStoreDb());

            MongoToExcelExportProvider.CreateExcelTable();

            SqliteProvider sqlite = new SqliteProvider();
            sqlite.GetProductTax(@"Beer ""Zagorka""");
            new MongoReporter().PrintExpenses();
            Console.ReadKey();
        }
    }
}
