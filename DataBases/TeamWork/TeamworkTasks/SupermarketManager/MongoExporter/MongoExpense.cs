using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupermarketManager.MongoExporter
{
    class MongoExpense
    {
        [BsonId]
        public ObjectId Id { get; set; }

        public DateTime Date { get; set; }
        public string VendorName { get; set; }
        public decimal Amount { get; set; }

        public MongoExpense(DateTime date, string vendorName, decimal amount)
        {
            this.Date = date;
            this.VendorName = vendorName;
            this.Amount = amount;
        }

        public override string ToString()
        {
            return String.Format("Date: {0}, Vendor: {1}, Amount: {2}, TrueID: {3}",
                this.Date, this.VendorName, this.Amount, this.Id);
        }
    }
}
