using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.FindElementOccurenceInGivenSequence
{
    class FindElementOccurenceInGivenSequence
    {
        static void Main()
        {
            List<int> sequence = new List<int>() { 1, 1, 1, 1, 1, 1, 2, 3, 4, 5, 1, 22, 22, 22 };
            Console.WriteLine("Initial sequence: -> {0}", string.Join(" ", sequence));
            Console.WriteLine();
            FindElementsOccurence(sequence);
        }

        private static void FindElementsOccurence(List<int> sequence)
        {
            Dictionary<int, int> elementsData = new Dictionary<int, int>();

            for (int i = 0; i < sequence.Count; i++)
            {
                var currentElement = sequence[i];
                if (elementsData.ContainsKey(currentElement))
                {
                    elementsData[currentElement]++;
                }
                else
                {
                    elementsData.Add(currentElement, 1);
                }
            }

            PrintElements(elementsData);
        }

        private static void PrintElements(Dictionary<int, int> elementsData)
        {
            foreach (var element in elementsData)
            {
                Console.WriteLine("The number '{0}' appears '{1}' times!", element.Key, element.Value);
            }
        }
    }
}
