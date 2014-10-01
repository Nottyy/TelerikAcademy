// Write a program that reads two integer numbers N and K and an array of N elements from the console. Find in the array those K elements that have maximal sum.

using System;

class MaxSumOfKelementsInArraysOfNelements
{
    static void Main()
    {
        Console.WriteLine("Enter N: ");
        int n = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter K: ");
        int k = int.Parse(Console.ReadLine());

        int[] array = new int[n];

        for (int i = 0; i < array.Length; i++)
        {
            Console.WriteLine("Enter element: {0}/{1}", i, array.Length - 1);
            array[i] = int.Parse(Console.ReadLine());
        }

        int sum = 0;
        int max = int.MinValue;
        int pos = 0;
        
        
        for (int i = 0; i <= n - k; i++)
        {
            for (int j = i; j < i + k; j++)
            {
                sum += array[j];
            }
            if (sum > max)
            {
                max = sum;
                pos = i;
            }
            sum = 0;
        }
        for (int i = pos; i < pos + k; i++)
        {
            Console.Write(array[i] + " ");
        }
        Console.WriteLine("The sum is: {0}", max);

    }
}

