using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTableImplementation
{
    class Program
    {
        static void Main(string[] args)
        {
            SampleHashTable<int, int> numbers = new SampleHashTable<int, int>();
            numbers.Add(5, 5);
            numbers.Add(12, 3);
            numbers.Add(123, 4);
            numbers.Remove(5);

            Console.WriteLine("After adding three elements and removing one the count should be one: {0}", numbers.Count == 2 ? true : false);
            Console.WriteLine("Keys: -> {0}", string.Join(" ", numbers.Keys()));
            Console.WriteLine("Capacity -> {0}", numbers.Capacity);
        }
    }
}
