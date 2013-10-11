using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Wintellect.PowerCollections;
using System.Linq;

namespace _2.ProductsPriceSearch
{
    public class ProductsPriceSearchDemo
    {
        static void Main()
        {

            string productsFilePath = "..//..//products.txt";

            //used to generate products 
            //using (StreamWriter sw = new StreamWriter(productsFilePath))
            //{
            //    StringBuilder result = new StringBuilder();
            //    for (int i = 0; i < 500000; i++)
            //    {
            //        result.AppendLine("Product" + i + " | " + i);
            //    }
            //    sw.Write(result);
            //}

            string[] lines = GetLinesFromTextFile(productsFilePath);
            OrderedBag<Product> products = GetProducts(lines);

            Product productPriceStart = new Product("Product50000", 50000);
            Product productPriceEnd = new Product("Product60000", 60000);
            IEnumerable<Product> productsInPriceRange = products.Range(productPriceStart, true, productPriceEnd, true).Take(20);

            foreach (var item in productsInPriceRange)
            {
                Console.WriteLine(item.ToString());
            }
        }

        private static OrderedBag<Product> GetProducts(string[] lines)
        {
            OrderedBag<Product> coursesStudents = new OrderedBag<Product>();
            foreach (var line in lines)
            {
                string[] tokens = line.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
                string productName = tokens[0].Trim();
                decimal productPrice = decimal.Parse(tokens[1].Trim());
                Product productToAdd = new Product(productName, productPrice);

                coursesStudents.Add(productToAdd);
            }

            return coursesStudents;
        }

        private static string[] GetLinesFromTextFile(string path)
        {
            string[] lines = null;

            try
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    string text = sr.ReadToEnd();
                    char[] seperators = new char[] { '\r', '\n' };
                    lines = text.Split(seperators, StringSplitOptions.RemoveEmptyEntries);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }

            return lines;
        }
    }
}
