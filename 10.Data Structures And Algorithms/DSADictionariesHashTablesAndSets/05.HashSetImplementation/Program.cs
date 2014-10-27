using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.HashSetImplementation
{
    class Program
    {
        static void Main(string[] args)
        {
            HashedSet<int> hashedSet = new HashedSet<int>();
            for (int i = 0; i < 10; i++)
            {
                hashedSet.Add(i);
            }
            Console.WriteLine("First hashedset -> {0}", string.Join(" ", hashedSet.Values));

            HashedSet<int> otherHashedSet = new HashedSet<int>();
            for (int i = 5; i < 15; i++)
            {
                otherHashedSet.Add(i);
            }
            Console.WriteLine("Second hashedset -> {0}", string.Join(" ", otherHashedSet.Values));

            var unionSet = hashedSet.Union(otherHashedSet);
            Console.WriteLine("After union -> {0}", string.Join(" ", unionSet.Values));

            var intersectSet = hashedSet.Intersect(otherHashedSet);
            Console.WriteLine("After intersect -> {0}", string.Join(" ", intersectSet.Values));
        }
    }
}
