using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupermarketManager.MongoExporter
{
    class MongoProduct
    {
        [BsonId]
        public ObjectId Id { get; set; }

        public int ProductId { get; set; }
        public string Name { get; set; }
        public string VendorName { get; set; }
        public int TotalQuantitySold { get; set; }
        public decimal TotalIncomes { get; set; }

        public MongoProduct(int id, string name, string vendorName, int totalQuantitySold, decimal totalIncomes)
        {
            this.ProductId = id;
            this.Name = name;
            this.VendorName = vendorName;
            this.TotalQuantitySold = totalQuantitySold;
            this.TotalIncomes = totalIncomes;
        }

        public override string ToString()
        {
            return String.Format("ProductId: {0}, Name: {1}, Vendor: {2}, Quantity sold: {3}, Incomes: {4}, TrueID: {5}",
                this.ProductId, this.Name, this.VendorName, this.TotalQuantitySold, this.TotalIncomes, this.Id);
        }
    }
}
