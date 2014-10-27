namespace _04.GenerateAllPermutationsToN
{
    using System;
    public class GenerateAllPermutations
    {
        static void Main()
        {
            int N = 3;// int.Parse(Console.ReadLine());
            int[] arr = new int[N];
            GenerateAllPermutationsToN(arr, 0);
        }

        private static void GenerateAllPermutationsToN(int[] arr, int index)
        {
            if (index == arr.Length)
            {
                Console.WriteLine("{" + string.Join(", ", arr) + "}");
            }
            else
            {
                for (int i = 1; i <= arr.Length; i++)
                {
                    bool numCheck = true;

                    for (int j = 0; j < index; j++)
                    {
                        if (arr[j] == i)
                        {
                            numCheck = false;
                        }
                    }

                    if (numCheck)
                    {
                        arr[index] = i;
                        GenerateAllPermutationsToN(arr, index + 1);
                    }
                }
            }
        }
    }
}