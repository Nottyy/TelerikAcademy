using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriorityQueue
{
    public class Program
    {
        static void Main()
        {
            BinaryHeap<Item> binaryHeap = new BinaryHeap<Item>(3);
            binaryHeap.Insert(new Item(7));
            binaryHeap.Insert(new Item(3));
            binaryHeap.Insert(new Item(9));

            while (binaryHeap.Size > 0)
            {
                Console.WriteLine(binaryHeap.Pop());
            }
        }
    }
}
