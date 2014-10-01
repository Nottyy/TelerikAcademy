//Write methods to calculate minimum, maximum, average, sum and product of given set of integer numbers. Use variable number of arguments.

using System;

class MinMaxSumAvrgProduct
{
    static void Main()
    {

        Console.WriteLine(" int[] arr = { 2, 3, 5, 123, 1, 2, 3, 51, 213 }");
        int[] arr = { 2, 3, 5, 123, 1, 2, 3, 51, 213 };//new int[numbers];


        Console.WriteLine("the minimum is {0}", MinimumValue(arr));
        Console.WriteLine("the maxmimum is {0}", MaximumValue(arr));
        Console.WriteLine("the average number is {0}", AverageValue(arr));
        Console.WriteLine("the sum is {0}", Sum(arr));
        Console.WriteLine("the product is {0}", Product(arr));
    }

    static int MinimumValue(int[] arr)
    {
        int minValue = int.MaxValue;

        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i] < minValue)
            {
                minValue = arr[i];
            }
        }

        return minValue;
    }

    static int MaximumValue(int[] arr)
    {
        int maxValue = int.MinValue;

        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i] > maxValue)
            {
                maxValue = arr[i];
            }
        }

        return maxValue;
    }

    static int Sum(int[] arr)
    {
        int sum = 0;
        for (int i = 0; i < arr.Length; i++)
        {
            sum += arr[i];
        }
        return sum;
    }

    static double AverageValue(int[] arr)
    {
        double sum = 0;
        for (int i = 0; i < arr.Length; i++)
        {
            sum += arr[i];
        }
        return sum / arr.Length;
    }

    static long Product(int[] arr)
    {
        long product = 1;
        for (int i = 0; i < arr.Length; i++)
        {
            product *= arr[i];
        }
        return product;
    }
}

