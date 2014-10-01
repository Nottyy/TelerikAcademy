using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09.QueuePrintSequenceByPattern
{
    class QueuePrintSequenceByPattern
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter positive number!");
            int N = int.Parse(Console.ReadLine());

            Queue<int> queue = new Queue<int>();
            queue.Enqueue(N);
            List<int> numbers = new List<int>();

            for (int i = 0; i < 50; i++)
            {
                var number = queue.Dequeue();
                numbers.Add(number);

                queue.Enqueue(number + 1);
                queue.Enqueue(number * 2 + 1);
                queue.Enqueue(number + 2);
            }

            Console.WriteLine("Numbers after processing the pattern!\n{0}",string.Join(" ", numbers));
        }
    }
}
