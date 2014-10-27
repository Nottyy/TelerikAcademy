//Write a program that finds the most frequent number in an array. Example:
//	{4, 1, 1, 4, 2, 3, 4, 4, 1, 2, 4, 9, 3}  4 (5 times)

using System;

class MostFrequentNumberInAnArray
{
    static void Main()
    {
        Console.WriteLine("Enter array length: ");
        int length = int.Parse(Console.ReadLine());
        int[] arr = new int[length];

        for (int i = 0; i < length; i++)
        {
            Console.Write("Element[{0}] = ", i);
            arr[i] = int.Parse(Console.ReadLine());
        }

        int maxCounter = 1;
        int frequentNumber = 0;

        for (int i = 0; i < length - 1; i++)
        {
            int counter = 1;
            for (int j = i + 1; j < length; j++)
            {
                if (arr[i] == arr[j])
                {
                    counter++;
                }
            }
            if (counter > maxCounter)
            {
                maxCounter = counter;
                frequentNumber = arr[i];
            }
        }
        if (maxCounter > 1)
        {
            Console.WriteLine("Most frequent number = {0}", frequentNumber);
            Console.WriteLine("Count = {0} times", maxCounter);
        }
        else
        {
            Console.WriteLine("All elements are different");
        }
    }
}

