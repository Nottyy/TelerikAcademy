using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10.FindTheShortestWay
{
    class FindTheShortestWay
    {
        static int end = 1024;

        // To save easily the current path I use the ValuePathPair class, where every elements keeps its current path.
        static void Main(string[] args)
        {
            int N = 2;
            Queue<ValuePathPair> queue = new Queue<ValuePathPair>();
            queue.Enqueue(new ValuePathPair(N));

            while (queue.Count > 0)
            {
                var currentElement = queue.Dequeue();

                if (currentElement.Value == end)
                {
                    Console.WriteLine(currentElement.PathToHere);
                    return;
                }
                else if (currentElement.Value > end)
                {
                    continue;
                }

                string currentPath = currentElement.PathToHere;

                queue.Enqueue(new ValuePathPair(currentElement.Value + 1, currentPath));
                queue.Enqueue(new ValuePathPair(currentElement.Value + 2, currentPath));
                queue.Enqueue(new ValuePathPair(currentElement.Value * 2, currentPath));
            }
        }
    }
}
