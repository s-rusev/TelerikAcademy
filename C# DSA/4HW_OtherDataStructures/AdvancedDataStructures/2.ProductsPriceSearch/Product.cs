using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.ProductsPriceSearch
{
    public class Product : IComparable<Product>
    {
        public string Name { get; set; }
        public decimal Price { get; set; }

        public Product(string name, decimal price)
        {
            this.Name = name;
            this.Price = price;
        }

        public int CompareTo(Product other)
        {
            return this.Price.CompareTo(other.Price);
        }

        public override string ToString()
        {
            return string.Format(Name + " -> " + Price);
        }
    }
}
