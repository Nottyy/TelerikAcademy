using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.ReverseASequenceUsingStack
{
    class ReverseASequenceUsingStack
    {
        static void Main()
        {
            Stack<int> stack = new Stack<int>();
            List<int> initialSequence = new List<int>();
            List<int> afterReversingSequence = new List<int>();

            ReverseCollectionWithStack(stack, initialSequence, afterReversingSequence);

            PrintSequence(initialSequence, "Initial");
            PrintSequence(afterReversingSequence, "After reversing with stack");
        }

        private static void PrintSequence(List<int> sequence, string message)
        {
            Console.WriteLine("{0} sequence: {1}", message, string.Join(" ", sequence));
        }

        private static void ReverseCollectionWithStack(Stack<int> stack, List<int> initialSequence, List<int> afterReversingSequence)
        {
            for (int i = 0; i < 5; i++)
            {
                int number = int.Parse(Console.ReadLine());
                stack.Push(number);
                initialSequence.Add(number);
            }

            for (int i = 0; i < 5; i++)
            {
                var number = stack.Pop();
                afterReversingSequence.Add(number);
            }
        }
    }
}
