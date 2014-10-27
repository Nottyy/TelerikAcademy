using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.ExtractOddElements
{
    class ExtractOddElements
    {
        static void Main(string[] args)
        {
            var elements = new List<string>() {"C#", "SQL", "PHP", "PHP", "SQL", "SQL" } ;
            Console.WriteLine("Initial sequence: -> {0}", string.Join(" ", elements));

            var elementsCount = new Dictionary<string, int>();

            for (int i = 0; i < elements.Count; i++)
            {
                if (elementsCount.ContainsKey(elements[i]))
                {
                    elementsCount[elements[i]]++;
                }
                else
                {
                    elementsCount.Add(elements[i], 1);
                }
            }

            var oddElementsOccurence = new List<string>();
            foreach (var element in elementsCount)
            {
                if (element.Value % 2 != 0)
                {
                    oddElementsOccurence.Add(element.Key);
                }
            }

            Console.WriteLine("Sequence, after removing odd elements: -> {0}", string.Join(" ", oddElementsOccurence));
        }
    }
}
