using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.ExtendThePreviousExerciseToSkipDuplicates
{
    class SkipDuplicates
    {
        static int N = 4;//int.Parse(Console.ReadLine());
        static int K = 2;//int.Parse(Console.ReadLine());
        
        static void Main()
        {
            int[] combinations = new int[K];
            int startNum = 1;
            GenerateCombinations(combinations, 0, startNum);
        }

        private static void GenerateCombinations(int[] combinations,int index,int startNum)
        {
            if (index == K)
            {
                PrintCombination(combinations);
                return;
            }

            for (int i = startNum; i <= N; i++)
            {
                combinations[index] = i;
                GenerateCombinations(combinations ,index + 1, i + 1);
            }
        }

        private static void PrintCombination(int[] combinations)
        {
            for (int i = 0; i < K; i++)
            {
                Console.Write(combinations[i]);
            }
            Console.WriteLine();
        }
    }
}
