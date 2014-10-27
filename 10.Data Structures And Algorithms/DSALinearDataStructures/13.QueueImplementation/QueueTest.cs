using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13.QueueImplementation
{
    class QueueTest
    {
        static void Main(string[] args)
        {
            DynamicQueue<int> queue = new DynamicQueue<int>();

            Console.WriteLine("Enqueue first number: 5");
            queue.Enqueue(5);
            Console.WriteLine("Enqueue first number: 6");
            queue.Enqueue(6);
            Console.WriteLine("Enqueue first number: 7");
            queue.Enqueue(7);
            Console.WriteLine("Enqueue first number: 8");
            queue.Enqueue(8);
            Console.WriteLine("Current count is: {0}", queue.Count());
            Console.WriteLine("Check first enqueued element: {0}", queue.Peek());
            Console.WriteLine("Dequeue element");
            var element = queue.Dequeue();
            Console.WriteLine("The dequeued element is: {0}", element);
            Console.WriteLine("Queue count after dequeuing an element: {0}", queue.Count());
        }
    }
}
