using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wintellect.PowerCollections;

namespace TestLargeCollectionOfProducts
{
    public class Test
    {
        static void Main()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            int numberOfGeneratedProducts = 500000;
            OrderedBag<Product> products = AddProducts(numberOfGeneratedProducts);

            int priceSearches = 10000;
            int range = 20;
            for (int i = 0; i < priceSearches; i++)
			{
                if (i + range < priceSearches)
	            {
		             var firstTwentyProducts = FindFirstTwentyProducts(products, i, i + range);
	            }
			}
            sw.Stop();
            Console.WriteLine("Elapsed time -> {0}", sw.Elapsed);
        }

        // If uncomment the first result and input 200 for example, instead of "pricesearches", the program will hang out.
        private static List<Product> FindFirstTwentyProducts(OrderedBag<Product> products,double minRange,double maxRange)
        {
            //var result = products.Where(x => x.Price >= minRange && x.Price <= maxRange).OrderBy(x => x.Price).ToList();
            var result = products.Range(new Product("searchItem", maxRange), true,
                new Product("searchItem", minRange), true).ToList();

            return result;
        }

        private static OrderedBag<Product> AddProducts(int numberOfEntries)
        {
            var products = new OrderedBag<Product>();

            for (int i = 0; i < numberOfEntries; i++)
            {
                var newProduct = new Product("Product" + i, i);
                products.Add(newProduct);
            }

            return products;
        }
    }
}
