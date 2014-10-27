//Sorting an array means to arrange its elements in increasing order. Write a program to sort an array. Use the "selection sort" algorithm: Find the smallest element, move it at the first position, find the smallest from the rest, move it at the second position, etc.

using System;

class ArraySort
{
    static void Main()
    {
        //enter array length
        Console.WriteLine("Enter array length");
        int length = int.Parse(Console.ReadLine());
        int[] arr = new int[length];

        for (int i = 0; i < length; i++)
        {
            Console.WriteLine("Enter element {0}/{1}", i , length - 1);
            arr[i] = int.Parse(Console.ReadLine());
        }

        // sort array with selection sort
        int temp, min;

        for (int j = 0; j < arr.Length - 1; j++)
        {
            min = j;

            for (int k = j + 1; k < arr.Length; k++)
            {
                if (arr[k] < arr[min])
                {
                    min = k;
                }
            }

            temp = arr[min];
            arr[min] = arr[j];
            arr[j] = temp;
        }

        //array after selection sort
        for (int i = 0; i < arr.Length; i++)
        {
            Console.WriteLine("array[" + i + "] = " + arr[i]);
        }
    }
}

