namespace _01.PrintingAllCombinationsFrom1ToN
{
    using System;

    public class GenerateAllPossibleCombinations
    {
        static int N = int.Parse(Console.ReadLine());
        static int[] arrWithCombinations;

        static void Main()
        {
            arrWithCombinations = new int[N];
            GenerateAllCombinations(0);
        }

        private static void PrintCombination()
        {
            for (int i = 0; i < N; i++)
            {
                Console.Write(arrWithCombinations[i]);
            }

            Console.WriteLine();
        }
        private static void GenerateAllCombinations(int index)
        {
            if (index == N)
            {
                PrintCombination();
                return;
            }

            for (int i = 1; i <= N; i++)
            {
                arrWithCombinations[index] = i;
                GenerateAllCombinations(index + 1);
            }
        }
    }
}
