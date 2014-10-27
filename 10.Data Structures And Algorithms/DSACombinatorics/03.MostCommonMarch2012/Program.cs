using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.MostCommonMarch2012
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<string, int> firstName = new Dictionary<string, int>();
            Dictionary<string, int> lastName  = new Dictionary<string, int>();
            Dictionary<string, int> year = new Dictionary<string, int>();
            Dictionary<string, int> eyes = new Dictionary<string, int>();
            Dictionary<string, int> hair = new Dictionary<string, int>();
            Dictionary<string, int> height = new Dictionary<string, int>();

            for (int i = 0; i < n; i++)
            {
                string line = Console.ReadLine();
                string[] characteristics = line.Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);

                AddCharacteristicsToDictionary(characteristics[0], firstName);
                AddCharacteristicsToDictionary(characteristics[1], lastName);
                AddCharacteristicsToDictionary(characteristics[2], year);
                AddCharacteristicsToDictionary(characteristics[3], eyes);
                AddCharacteristicsToDictionary(characteristics[4], hair);
                AddCharacteristicsToDictionary(characteristics[5], height);
            }

            Console.WriteLine(SearchElement(firstName));
            Console.WriteLine(SearchElement(lastName));
            Console.WriteLine(SearchElement(year));
            Console.WriteLine(SearchElement(eyes));
            Console.WriteLine(SearchElement(hair));
            Console.WriteLine(SearchElement(height));
        }

        private static void AddCharacteristicsToDictionary(string key, Dictionary<string, int> dict)
        {
            if (dict.ContainsKey(key))
            {
                dict[key] += 1;
            }
            else
            {
                dict.Add(key, 1);
            }
        }

        private static string SearchElement(Dictionary<string, int> dict)
        {
            string result = string.Empty;
            int max = int.MinValue;

            foreach (var item in dict)
            {
                if (item.Value > max)
                {
                    max = item.Value;
                    result = item.Key;
                }
                else if (item.Value == max)
                {
                    if (result.CompareTo(item.Key) > 0)
                    {
                        result = item.Key;
                    }
                }
            }

            return result;
        }

    }
}
