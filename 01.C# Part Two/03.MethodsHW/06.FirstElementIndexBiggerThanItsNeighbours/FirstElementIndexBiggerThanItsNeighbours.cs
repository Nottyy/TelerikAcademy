using System;

class FirstElementIndexBiggerThanItsNeighbours
{
    static int[] arr = new int[20];

    static void Main(string[] args)
    {
        GenerateRandomArray();
        // int[] arr = { 1, 5, 2, 3, 3, 3, 4, 3, 4, 4, 5 };

        Console.WriteLine(ElementIndex(arr));
    }

    private static bool IsInside(int[] arr, int i)
    {
        return 0 <= i && i < arr.Length;
    }

    private static bool IsBigger(int[] arr, int i, int j)
    {
        return IsInside(arr, j) ? arr[i] > arr[j] : true;
    }

    private static bool IsBiggerThanNeighbours(int[] arr, int i)
    {
        return IsBigger(arr, i, i - 1) && IsBigger(arr, i, i + 1);
    }

    private static int ElementIndex(int[] arr)
    {
        for (int i = 1; i < arr.Length - 1; i++)
        {
            if (IsBiggerThanNeighbours(arr,i))
            {
                return i;
            }
        }
        return -1;
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

