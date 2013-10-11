using System;
using System.Collections.Generic;
using Wintellect.PowerCollections;

namespace _2.ArticlesPriceRange
{
    public class Program
    {
        static void Main()
        {
            OrderedMultiDictionary<decimal, Article> articlesByPrice = new OrderedMultiDictionary<decimal, Article>(true);
            Console.WriteLine("Adding some elements to the list of articles - this may take some time...");
            for (int i = 500000; i > 0; i--)
            {
                Article anArticle = new Article("PrideAndPrejudies" + i, "Vendor" + i, "barcode" + i, i);
                articlesByPrice.Add(anArticle.Price, anArticle);
            }
            for (int i = 500000; i > 0; i--)
            {
                Article anArticle = new Article("PrideAndPrejudies" + i, "Vendor" + i, "barcode" + i, i);
                articlesByPrice.Add(anArticle.Price, anArticle);
            }

            decimal articleStartPrice = 500;
            decimal articleEndPrice = 510;
            
            //borders inclusive
            var articlesInRange = articlesByPrice.Range(articleStartPrice, true, articleEndPrice, true);

            Console.WriteLine("All items in the price range [500-510] are:");
            foreach (var articlesRecord in articlesInRange)
            {
                foreach (var article in articlesRecord.Value)
                {
                    Console.WriteLine(article.ToString());
                }
            }
            
        }
    }
}
