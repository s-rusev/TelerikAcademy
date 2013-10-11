using System;

namespace _2.ArticlesPriceRange
{
    public class Article : IComparable<Article>
    {
        public string Title { get; set; }
        public string Vendor { get; set; }
        public string Barcode { get; set; }
        public decimal Price { get; set; }

        public Article(string title, string vendor, string barcode, decimal price)
        {
            this.Title = title;
            this.Vendor = vendor;
            this.Barcode = barcode;
            this.Price = price;
        }

        public override string ToString()
        {
            return string.Format("Title: {0}, Vendor: {1}, Barcode: {2}, Price: {3}", Title, Vendor, Barcode, Price);
        }

        public int CompareTo(Article other)
        {
            int result = 0;
            if (this.Price > other.Price)
            {
                result = 1;
            }
            else if (this.Price < other.Price)
            {
                result = -1;
            }

            return result;
        }
    }
}
