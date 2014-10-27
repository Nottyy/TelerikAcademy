using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.FindLongestSubSequenceOfEqualElements
{
    class LongestSubSequenceOfEqualElements
    {
        // I know that my program does'n work for more than 1 equal sequences, but the task does'n demand that.
        static void Main()
        {
            List<int> sequence = new List<int>() { 1, 1, 1, 1, 2, 2, 3, 4, 5, 5, 6, 7 };
            Console.WriteLine("Initial sequence: -> {0}", string.Join(" ", sequence));

            List<int> longestSequence = FindLongestSubSequenceOfEqualElements(sequence);
            Console.WriteLine("The longest subsequence of equal elements is: -> {0}", string.Join(" ", longestSequence));

            bool worksCorrectly = longestSequence.Count == 4 ? true: false;

            Console.WriteLine("Test whether the program works correctly: {0}", worksCorrectly);
        }

        private static List<int> FindLongestSubSequenceOfEqualElements(List<int> sequence)
        {
            var longestSequenceElements = new List<int>();
            var counterForEqualElements = 1;
            var maxSequence = int.MinValue;
            int mostAppearingElement = int.MinValue;

            for (int i = 1; i < sequence.Count; i++)
            {
                var currentElement = sequence[i];
                var previousElement = sequence[i - 1];

                if (currentElement == previousElement)
                {
                    counterForEqualElements++;

                    if (counterForEqualElements > maxSequence)
                    {
                        maxSequence = counterForEqualElements;
                        mostAppearingElement = currentElement;
                    }
                }
                else
                {
                    counterForEqualElements = 0;
                }
            }

            if (mostAppearingElement != int.MinValue)
            {
                for (int i = 0; i < maxSequence; i++)
                {
                    longestSequenceElements.Add(mostAppearingElement);
                }
            }

            return longestSequenceElements;
        }
    }
}
