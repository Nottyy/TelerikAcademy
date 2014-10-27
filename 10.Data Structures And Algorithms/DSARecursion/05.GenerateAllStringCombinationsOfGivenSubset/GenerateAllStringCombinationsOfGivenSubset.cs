using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.GenerateAllStringCombinationsOfGivenSubset
{
    class GenerateAllStringCombinationsOfGivenSubset
    {
        static void Main()
        {
            int N = 3;// int.Parse(Console.ReadLine());
            int K = 2;// int.Parse(Console.ReadLine());
            string[] arr = new string[K];
            string[] subsets = new string[N];
            subsets[0] = "hi";
            subsets[1] = "a";
            subsets[2] = "b";

            GenerateCombinations(N, K, subsets, arr, 0);
        }

        private static void GenerateCombinations(int N, int K, string[] subsets, string[] arr, int index)
        {
            if (index == K)
            {
                Console.WriteLine("{ " + string.Join(" ", arr) + "}");
            }
            else
            {
                for (int i = 0; i < N; i++)
                {
                    arr[index] = subsets[i];
                    GenerateCombinations(N, K, subsets, arr, index + 1);
                }
            }
        }
    }
}
