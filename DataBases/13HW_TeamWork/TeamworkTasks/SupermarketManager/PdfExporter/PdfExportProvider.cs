using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using SQLStore.Data;
using SQLStore.Model;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace SupermarketManager.PdfExporter
{
    class PdfExportProvider
    {
        static readonly Font boldTableFont = FontFactory.GetFont("Arial", 12, Font.BOLD);

        public static void ToPdf(SQLStoreDb msSqlDbContext, string reportFileName)
        {
            // Create a Document object
            var document = new Document(PageSize.A4, 50, 50, 25, 25);

            // Create a new PdfWriter object, specifying the output stream
            using (var output = new FileStream(reportFileName, FileMode.Create))
            {
                var writer = PdfWriter.GetInstance(document, output);

                // Open the Document for writing
                document.Open();

                var paragraph = new Paragraph("Aggregated Sales Report", FontFactory.GetFont("Arial", 12, Font.BOLD));
                document.Add(paragraph);

                // Close the Document - this saves the document contents to the output stream

                var dates =
                    (from sr in msSqlDbContext.SalesDate
                     select sr.Date).Distinct().ToList();

                foreach (var date in dates)
                {    
                    var reports = msSqlDbContext.Sales.Where(sr => sr.SaleDate.Date == date).Select(sr => sr).ToList();

                    PdfPTable table = new PdfPTable(5);
                    table.HorizontalAlignment = 0;
                    table.SpacingBefore = 10;
                    table.SpacingAfter = 10;

                    AddHeaderCells(document, date, table);
                    decimal totalSum = 0;

                    foreach (var report in reports)
                    {
                        AddReportRow(table, report);
                        totalSum += report.Quantity * report.UnitPrice;
                    }

                    AddTotalSumRow(date, table, totalSum);

                    document.Add(table);
                }

                document.Close();
            }
        }

        private static void AddTotalSumRow(DateTime date, PdfPTable table, decimal totalSum)
        {
            PdfPCell totalSumCell = new PdfPCell(new Phrase("Total sum for " + date.ToShortDateString()));

            totalSumCell.Colspan = 4;
            totalSumCell.HorizontalAlignment = 2;

            PdfPCell totalSumValuCell = new PdfPCell(new Phrase(totalSum.ToString(), boldTableFont));

            table.AddCell(totalSumCell);
            table.AddCell(totalSumValuCell);
        }

        private static void AddReportRow(PdfPTable table, Sale report)
        {
            PdfPCell productCell = new PdfPCell(new Phrase(report.Product.ProductName));

            PdfPCell quantityCell = new PdfPCell(new Phrase(report.Quantity + " " + report.Product.Measure.MeasureName));

            PdfPCell priceCell = new PdfPCell(new Phrase(report.UnitPrice.ToString()));

            PdfPCell locationCell = new PdfPCell(new Phrase(report.Location.LocationName));

            PdfPCell sumCell = new PdfPCell(new Phrase((report.UnitPrice * report.Quantity).ToString()));

            table.AddCell(productCell);
            table.AddCell(quantityCell);
            table.AddCell(priceCell);
            table.AddCell(locationCell);
            table.AddCell(sumCell);
        }

        private static void AddHeaderCells(Document document, DateTime date, PdfPTable table)
        {

            PdfPCell headerCell = new PdfPCell(new Phrase(date.ToShortDateString(), boldTableFont));

            headerCell.Colspan = 5;

            headerCell.HorizontalAlignment = 1;

            table.AddCell(headerCell);

            PdfPCell productCell = new PdfPCell(new Phrase("Product", boldTableFont));
            PdfPCell quantityCell = new PdfPCell(new Phrase("Quantity", boldTableFont));
            PdfPCell priceCell = new PdfPCell(new Phrase("Unit price", boldTableFont));
            PdfPCell locationCell = new PdfPCell(new Phrase("Location", boldTableFont));
            PdfPCell sumCell = new PdfPCell(new Phrase("Sum", boldTableFont));

            table.AddCell(productCell);
            table.AddCell(quantityCell);
            table.AddCell(priceCell);
            table.AddCell(locationCell);
            table.AddCell(sumCell);
        }
    }
}
