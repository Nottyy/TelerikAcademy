//Write a program to convert decimal numbers to their binary representation.

using System;
using System.Text;
using System.Collections.Generic;
class DecimalToBinary
{
    static void Main()
    {
        int num = 1028;
        List<int> inBinary = Convert(ref num);

        Print(inBinary);
    }

    private static List<int> Convert(ref int num)
    {
        List<int> inBinary = new List<int>();

        while (num != 0)
        {
            inBinary.Add(num % 2);
            num /= 2;
        }
        inBinary.Reverse();
        return inBinary;
    }

    private static void Print(List<int> inBinary)
    {
        for (int i = 0; i < inBinary.Count; i++)
        {
            Console.Write(inBinary[i]);
        }
        Console.WriteLine();
    }
   

    
}

