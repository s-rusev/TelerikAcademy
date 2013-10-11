using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using SQLStore.Model;
using SQLStore.Data;
using System;
using System.IO.Compression;

namespace SupermarketManager.DatabaseImporter
{
    class TransferFromExcel
    {
        public void ParseExcelZip(string archivePath)
        {
            using (SQLStoreDb msSqlContext = new SQLStoreDb())
            {
                using (ZipArchive archive = ZipFile.Open(archivePath, ZipArchiveMode.Update))
                {
                    archive.ExtractToDirectory("temporaryExcels");

                    foreach (var dir in Directory.GetDirectories("temporaryExcels"))
                    {
                        string dateString = dir.Replace("temporaryExcels\\", "");
                        DateTime date = DateTime.Parse(dateString);
                        SaleDate saleDate = new SaleDate() { Date = date };
                        msSqlContext.SalesDate.Add(saleDate);
                        msSqlContext.SaveChanges();
                        Console.WriteLine("Just added new SaleDate: {0}", saleDate.Date);

                        foreach (var file in Directory.GetFiles(dir))
                        {
                            OleDbConnection dbConn = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;" +
                   @"Data Source=" + file + @";Extended Properties=""Excel 12.0 XML;HDR=Yes""");
                            OleDbCommand myCommand = new OleDbCommand("select * from [Sales$]", dbConn);
                            dbConn.Open();

                            using (dbConn)
                            {
                                OleDbDataReader reader = myCommand.ExecuteReader();
                                reader.Read();
                                string marketName = reader.GetValue(0).ToString();
                                reader.Read();
                                Location supermarket;
                                if (msSqlContext.Locations.Any(sm => sm.LocationName == marketName) == false)
                                {
                                    supermarket = new Location() { LocationName = marketName };
                                    msSqlContext.Locations.Add(supermarket);
                                    msSqlContext.SaveChanges();
                                }
                                else
                                {
                                    supermarket = msSqlContext.Locations.First(sm => sm.LocationName == marketName);
                                }

                                while (reader.Read())
                                {
                                    string ProductId = reader.GetValue(0).ToString();
                                    string Qauntity = reader.GetValue(1).ToString();
                                    string UnitPrice = reader.GetValue(2).ToString();

                                    if (ProductId.Trim() == "…" || ProductId.Trim() == "Total sum:")
                                    {
                                        break;
                                    }

                                    Sale newReport = new Sale()
                                    {
                                        SaleDate = saleDate,
                                        ProductID = int.Parse(ProductId),
                                        Quantity = int.Parse(Qauntity),
                                        LocationID = supermarket.LocationID,
                                        UnitPrice = decimal.Parse(UnitPrice)
                                    };

                                    msSqlContext.Sales.Add(newReport);
                                }
                                msSqlContext.SaveChanges();
                            }
                        }
                    }

                    Directory.Delete("temporaryExcels", true);
                }
                
            }
        }
    }
}
