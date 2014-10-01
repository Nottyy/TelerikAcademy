using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wintellect.PowerCollections;

namespace TradeCompany
{
    public class TestEntry
    {
        public static void Main()
        {
            OrderedMultiDictionary<double, Article> articles = new OrderedMultiDictionary<double, Article>(true);

            int range = 10000;
            for (int i = 0; i < range; i++)
            {
                var article = new Article("barcode" + i, "vendor" + i, "title" + i, i);
                articles.Add(article.Price, article);
            }

            int from = 5000;
            int to = 5040;

            //Make some duplications
            for (int i = from; i < to - 30; i++)
            {
                var article = new Article("newBarcode" + i, "newVendor" + i, "newTitle" + i, i);
                articles.Add(article.Price, article);
            }

            var articlesInGivenRange = articles.Range(from, true, to, true);
            foreach (var article in articlesInGivenRange)
            {
                foreach (var item in article.Value)
                {
                    Console.WriteLine("Title: {0}, Vendor: {1}, Barcode: {2}, Price: {3}",
                    item.Title, item.Vendor, item.Barcode, item.Price);
                }
                Console.WriteLine();
            }
        }
    }
}
