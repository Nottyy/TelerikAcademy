//Write a program that finds in given array of integers a sequence of given sum S (if present). Example:	 {4, 3, 1, 4, 2, 5, 8}, S=11  {4, 2, 5}

using System;

class SequenceOfGivenSum
{
    static void Main()
    {
        Console.WriteLine("Enter array length: ");
        int length = int.Parse(Console.ReadLine());

        int[] array = new int[length];

        for (int i = 0; i < length; i++)
        {
            array[i] = int.Parse(Console.ReadLine());
        }
        int s = 11;
        int currentSum = 0;
        int startElement = 0;
        int printStart = 0;
        int printEnd = 0;

        for (int i = 0; i < array.Length; i++)
        {
            currentSum += array[i];
            if (currentSum == s)
            {
                printStart = startElement; //get the element from which we start printing
                printEnd = i; //get the element at which we end printing
                break;
            }
            if (i == array.Length - 1)
            {
                currentSum = 0;
                startElement++;
                if (startElement == array.Length)
                {
                    break;
                }
                i = startElement - 1; //-1, because we have a i++ in the for loop
            }
        }
        if (s != currentSum)
        {
            Console.WriteLine("No such sum in array");
            return;
        }
        for (int i = printStart; i <= printEnd; i++)
        {
            Console.Write("{0} ", array[i]);
        }

    }
}

