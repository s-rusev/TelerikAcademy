using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Xml;
using SQLStore.Data;
using SQLStore.Model;

namespace SupermarketManager.XmlExporter
{
    class XmlExportProvider
    {
        public static void ToXml(SQLStoreDb msSqlDbContext, string reportFileName)
        {
            var vendors =
                    (from sr in msSqlDbContext.Vendors
                     select sr.VendorName).Distinct().ToList();

            FileStream stream = new FileStream(reportFileName, FileMode.Create);
            using (stream)
            {
                using (var writer = new XmlTextWriter(stream, UTF8Encoding.UTF8))
                {
                    writer.WriteStartDocument();
                    writer.WriteStartElement("sales");

                    foreach (var vendor in vendors)
                    {
                        IQueryable<Sale> salesVendor = msSqlDbContext.Sales.Where(s => s.Product.Vendor.VendorName == vendor).Select(sa => sa);
                        writer.WriteStartElement("sale");
                        writer.WriteAttributeString("vendor", vendor);
                        foreach (var sale in salesVendor)
                        {
                            writer.WriteStartElement("summary", vendor);
                            writer.WriteAttributeString("date", sale.SaleDate.Date.ToString());
                            writer.WriteAttributeString("total-sum", (sale.Quantity * sale.UnitPrice).ToString());
                            writer.WriteEndElement();
                        }
                        writer.WriteEndElement();
                    }

                    writer.WriteEndElement();
                    writer.WriteEndDocument();
                }
            }
        }
    }
}
