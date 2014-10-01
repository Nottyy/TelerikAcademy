using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.RemoveAllNegativeNumbers
{
    class RemovingNegativeNumbers
    {
        static void Main(string[] args)
        {
            List<int> sequence = new List<int>() { -1, 2, 3, 4, -5, 6, -7 };
            Console.WriteLine("Initial sequence: -> {0}", string.Join(" ", sequence));

            var afterRemovingNegativeNumbersSequence = RemoveNegativeNumbers(sequence);
            Console.WriteLine("After removing negative numbers sequence: -> {0}", string.Join(" ", afterRemovingNegativeNumbersSequence));
        }

        private static List<int> RemoveNegativeNumbers(List<int> sequence)
        {
            for (int i = 0; i < sequence.Count; i++)
            {
                var currentElement = sequence[i];
                if (currentElement < 0)
                {
                    sequence.RemoveAt(i);
                }
            }

            return sequence;
        }
    }
}
