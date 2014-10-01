using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.GenerateAllSubsetsInGivenSetOfStrings
{
    class GenerateSubsets
    {
        static void Main()
        {
            int N = 3;
            int K = 2;
            string[] set = new string[] { "test", "fun", "rock"};
            string[] combinations = new string[K];

            GenerateCombinations(set, combinations, 0, 0);
        }

        private static void GenerateCombinations(string[] set, string[] combinations, int startIndex, int index)
        {
            if (index == combinations.Length)
            {
                Console.WriteLine("{ " + string.Join(" ", combinations) + " }");
                return;
            }

            for (int i = startIndex; i < set.Length; i++)
            {
                combinations[index] = set[i];
                GenerateCombinations(set, combinations, i + 1, index + 1);
            }
        }
    }
}
