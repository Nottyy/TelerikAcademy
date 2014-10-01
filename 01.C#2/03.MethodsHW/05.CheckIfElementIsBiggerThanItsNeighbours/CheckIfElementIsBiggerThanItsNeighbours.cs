//Write a method that checks if the element at given position in given array of integers is bigger than its two neighbors (when such exist).

using System;

class CheckIfElementIsBiggerThanItsNeighbours
{
    static int[] arr = new int[20];

    static void Main(string[] args)
    {
        GenerateRandomArray();
       // int[] arr = { 1, 5, 2, 3, 3, 3, 4, 3, 4, 4, 5 };

        for (int i = 1; i < arr.Length - 1; i++)
        {
            Console.WriteLine(arr[i] + ": " + IsBiggerThanNeighbours(arr, i));
        }

    }

    private static bool IsInside(int[] arr, int i)
    {
        return 0 <= i && i < arr.Length;
    }

    private static bool IsBigger(int[] arr ,int i , int j)
    {
        return IsInside(arr, j) ? arr[i] > arr[j] : true;
    }

    private static bool IsBiggerThanNeighbours(int[] arr, int i)
    {
        return IsBigger(arr, i, i - 1) && IsBigger(arr, i, i + 1);
    }


    private static void GenerateRandomArray()
    {
        Random randomNumber = new Random();

        for (int i = 1; i < arr.Length; i++)
        {
            arr[i] = randomNumber.Next(11); //generate random number between 0 and 10
        }
    }
}

