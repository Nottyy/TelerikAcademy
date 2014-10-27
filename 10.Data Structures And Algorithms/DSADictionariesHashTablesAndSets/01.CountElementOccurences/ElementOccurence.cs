using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.CountElementOccurences
{
    class ElementOccurence
    {
        static void Main(string[] args)
        {
            var elements = new List<double>() { 3, 4, 4, -2.5, 3, 3, 4, 3, -2.5 };
            Console.WriteLine("Initial sequence: -> {0}", string.Join(" ", elements));

            Dictionary<double, int> elementsCount = new Dictionary<double, int>();

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

            foreach (var element in elementsCount)
            {
                Console.WriteLine("Element -> {0}, appears -> {1} times", element.Key, element.Value);
            }
        }
    }
}
