﻿//Write a program, that reads from the console an array of N integers and an integer K, sorts the array and using the method Array.BinSearch() finds the largest number in the array which is ≤ K. 

using System;

class ArrayBinSearch
{
    static void Main()
    {
        //Write a program, that reads from the console an array of N integers and an integer K,
        //sorts the array and using the method Array.BinSearch() finds the largest number in the array which is ≤ K.


        int n = int.Parse(Console.ReadLine());
        int k = int.Parse(Console.ReadLine());
        int[] array = new int[n];
        for (int i = 0; i < n; i++)
        {
            array[i] = int.Parse(Console.ReadLine());
        }

        Array.Sort(array);

        int elemIndex = Array.BinarySearch(array, k);
        while (elemIndex < 0)
        {
            if (k < array[0])
            {
                break;
            }
            k--;
            elemIndex = Array.BinarySearch(array, k);

        }
        if (elemIndex < 0)
        {
            Console.WriteLine("Element not found!");
        }
        else
        {
            Console.WriteLine("Element <= K found at index [{0}] = {1}", elemIndex, array[elemIndex]);
        }
    }
}

// test 
//10
//14
//15
//-1
//0
//22
//30
//60
//31
//28
//9
//8