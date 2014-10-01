//* Write a program that reads an array of integers and removes from it a minimal number of elements in such way that the remaining array is sorted in increasing order. Print the remaining sorted array. Example:
//    {6, 1, 4, 3, 0, 3, 6, 4, 5}  {1, 3, 3, 4, 5}

using System;
using System.Collections.Generic;

class IncreasingOrderArraySort
{
    static void Main()
    {
        int[] array = { 6, 1, 4, 3, 0, 3, 6, 4, 5 };
        int length = (2 << array.Length - 1) - 1;
        List<int> sort = new List<int>();
        List<int> checker = new List<int>();
        int minValue;
        int counter = 0;
        int count = 0;

        for (int i = 0; i <= length; i++)
        {
            // check all combination in which the next number is bigger or equal to previous
            counter = 0;
            minValue = int.MinValue;
            for (int k = 0; k < array.Length; k++)
            {
                if ((((i >> k) & 1) == 1) && (minValue <= array[k]))
                {
                    minValue = array[k];
                    checker.Add(array[k]);
                    counter++;
                }
            }

            // check if the new combination is bigger than the previous
            if (counter > count)
            {
                sort.Clear();
                count = counter;
                for (int k = 0; k < checker.Count; k++)
                {
                    sort.Add(checker[k]);
                }
            }
            checker.Clear();
        }

        // print the biggest combination
        for (int index = 0; index < sort.Count; index++)
        {
            Console.Write(sort[index] + " ");
        }
        Console.WriteLine();
    }
}

