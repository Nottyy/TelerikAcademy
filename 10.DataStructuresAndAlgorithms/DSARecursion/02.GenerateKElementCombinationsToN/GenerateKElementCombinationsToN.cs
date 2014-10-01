namespace _02.GenerateKElementCombinationsToN
{
    using System;
    

    public class GenerateKElementCombinationsToN
    {
        static int counter = 0;
        static int N = 6;//int.Parse(Console.ReadLine());
        static int K = 2;//int.Parse(Console.ReadLine());
        static int[] combinations;

        static void Main()
        {
            combinations = new int[N];
            GenerateCombinations(0);
            Console.WriteLine(counter);
        }

        private static void GenerateCombinations(int index){
            if (index == K)
            {
                counter += 1;
                PrintCombination();
                return;
            }

            for (int i = 1; i <= combinations.Length; i++)
            {
                
                combinations[index] = i;
                
                GenerateCombinations(index + 1);
                
            }
        }

        private static void PrintCombination()
        {
            for (int i = 0; i < K; i++)
            {
                Console.Write(combinations[i]);
            }
            Console.WriteLine();
        }
    }
}
