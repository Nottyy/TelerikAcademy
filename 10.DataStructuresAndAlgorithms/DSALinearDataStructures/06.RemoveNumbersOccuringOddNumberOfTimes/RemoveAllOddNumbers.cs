using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.RemoveNumbersOccuringOddNumberOfTimes
{
    class RemoveAllOddNumbers
    {
        static void Main(string[] args)
        {
            List<int> sequence = new List<int>() { 1, 1, 2, 2, 3, 4, 5, 66, 6, 66, 66, 5 };
            Console.WriteLine("Initial sequence: -> {0}", string.Join(" ", sequence));

            List<int> afterRemovingOddNumbers = RemoveNumbersOccuringOddNumberOfTimes(sequence);
            Console.WriteLine("After removing odd numbers: -> {0}", string.Join(" ", afterRemovingOddNumbers));
        }

        private static List<int> RemoveNumbersOccuringOddNumberOfTimes(List<int> sequence)
        {
            Dictionary<int, int> elementsCounter = new Dictionary<int, int>();

            for (int i = 0; i < sequence.Count; i++)
            {
                if (elementsCounter.ContainsKey(sequence[i]))
                {
                    elementsCounter[sequence[i]]++;
                }
                else
                {
                    elementsCounter.Add(sequence[i], 1);
                }
            }

            RemoveOddNumbers(elementsCounter, sequence);

            return sequence;
        }

        private static void RemoveOddNumbers(Dictionary<int,int> elementsCounter, List<int> sequence)
        {
            for (int i = 0; i < sequence.Count; i++)
            {
                int currentElement = sequence[i];
                if (elementsCounter[currentElement] % 2 != 0)
                {
                    sequence.RemoveAt(i);
                    i--;
                }
            }
        }
    }
}
