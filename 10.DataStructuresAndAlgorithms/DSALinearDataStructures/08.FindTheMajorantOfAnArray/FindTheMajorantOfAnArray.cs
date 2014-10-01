using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.FindTheMajorantOfAnArray
{
    class FindTheMajorantOfAnArray
    {
        static void Main()
        {
            List<int> sequence = new List<int>() { 1, 1, 1, 1, 1, 1, 2, 1, 22, 22, 22 };
            Console.WriteLine("Initial sequence: -> {0}", string.Join(" ", sequence));
            GetMajorant(sequence);
        }

        private static void GetMajorant(List<int> sequence)
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

            int majorant = (sequence.Count / 2) + 1;
            int majorantElement = int.MinValue;
            int majorantOccurence = int.MinValue;

            foreach (var element in elementsData)
            {
                if (element.Value >= majorant)
                {
                    majorantElement = element.Key;
                    majorantOccurence = element.Value;
                    break;
                }
            }

            if (majorantElement == int.MinValue)
            {
                throw new ArgumentException("There is no majorant in the array!");
            }

            Console.WriteLine("The majorant of the array is '{0}' and appears '{1}' times!", majorantElement, majorantOccurence);
        }
    }
}
