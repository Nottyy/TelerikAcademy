//Write a program that finds the index of given element in a sorted array of integers by using the binary search algorithm (find it in Wikipedia).

using System;

class BinarySearchAlgorithm
{
    static void Main(string[] args)
    {
        int[] array = { -5, -1, 1, 3, 5, 8, 9, 10, 12, 15, 17, 19 };
        int target = 1; // the index of the element we are searching for
        int max = array.Length;
        int min = 0;
        while (min < max)
        {
            int middle = (min + max) / 2;
            if (array[middle] > target)
            {
                max = middle;
            }
            else if (array[middle] < target)
            {
                min = middle;
            }
            else if (array[middle] == target)
            {
                Console.WriteLine("The index of {0} in the array is: {1}", target, middle);
                break;
            }

        }
    }
}

