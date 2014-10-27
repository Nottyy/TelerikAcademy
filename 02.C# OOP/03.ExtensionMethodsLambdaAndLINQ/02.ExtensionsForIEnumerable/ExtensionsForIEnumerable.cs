// Implement a set of extension methods for IEnumerable<T> that implement the following group functions: sum, product, min, max, average.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtensionsForIEnumerable
{
    class ExtensionsForIEnumerable
    {
        static void Main()
        {
            int[] arr = new int[] { 1, 2, 3, 4, 5, 6 };

            Console.WriteLine("Min: {0}", arr.Min<int>());
            Console.WriteLine("Max: {0}", arr.Max<int>());
            Console.WriteLine("Sum: {0}", arr.Sum<int>());
            Console.WriteLine("Average: {0}", arr.Average<int>());
            Console.WriteLine("Product: {0}", arr.Product<int>());
        }
    }
}
