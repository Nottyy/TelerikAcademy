// Write a program that finds the maximal increasing sequence in an array. Example: {3, 2, 3, 4, 2, 2, 4}  {2, 3, 4}.

using System;

class MaxIncreasingSequenceProgram

{
    static void Main()
    {
        Console.WriteLine("Enter array length: ");
        int n = int.Parse(Console.ReadLine());
        int[] array = new int[n];


        int len = 1;
        int bestLen = 0;
        int endIndex = 0;
        string maxSequenceElements;
        for (int i = 0; i < array.Length; i++)
        {
            Console.WriteLine("Enter element ({0})/{1}", i, array.Length);
            array[i] = int.Parse(Console.ReadLine());
        }

        for (int i = 0; i < array.Length - 1; i++)
        {
            if (array[i] < array[i + 1])
            {
                len++;
            }
            else
            {
                if (len > bestLen)
                {
                    bestLen = len;
                    endIndex = i;
                }
                len = 1;
            }
        }
        // Special case
        if (len > bestLen)
        {
            bestLen = len;
            endIndex = array.Length - 1;
        }

        // output
        len = 1;
        Console.WriteLine("The longest sequence of increasing elemints is:");
        Console.Write("{");
        for (int i = endIndex - bestLen + 1; i < endIndex + 1; i++)
        {
            Console.Write("{0},", array[i]);
        }
        Console.WriteLine("}");
    }
}

