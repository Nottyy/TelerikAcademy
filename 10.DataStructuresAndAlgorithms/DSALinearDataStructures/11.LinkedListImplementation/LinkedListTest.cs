using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11.LinkedListImplementation
{
    class LinkedListTest
    {
        static void Main()
        {
            LinkedList<int> linkedList = new LinkedList<int>();
            linkedList.AddFirst(5);
            linkedList.AddLast(100);
            linkedList.AddAfter(linkedList.FirstElement.NextItem, 1000);
            linkedList.AddBefore(linkedList.FirstElement.NextItem, 999);
            linkedList.AddBefore(linkedList.FirstElement, 0);
            linkedList.RemoveFirst();
            linkedList.RemoveLast();

            ListItem<int> next = linkedList.FirstElement;
            while (next != null)
            {
                Console.WriteLine(next.Value);
                next = next.NextItem;
            }

            Console.WriteLine(linkedList.Count);
        }
    }
}
