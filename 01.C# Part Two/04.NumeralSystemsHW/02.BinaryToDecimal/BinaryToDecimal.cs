//Write a program to convert binary numbers to their decimal representation.

using System;
using System.Collections.Generic;
class BinaryToDecimal
{
    static void Main()
    {
        Console.WriteLine(Base2ToBase10("0011"));

        //string input = Console.ReadLine();
        //int decNum = 0;
        //for (int i = 0; i < input.Length; i++)
        //{
        //    decNum = decNum << 1;
        //    if (input[i] == '1')
        //    {
        //        decNum = decNum ^ 1;
        //    }
        //}
        //Console.WriteLine(decNum);

    }
    static int GetNumber(string numberToString, int i)
    {
        return numberToString[i] - '0';
    }

    static int Base2ToBase10(string numberToString)
    {
        int result = 0;

        for (int i = numberToString.Length - 1, degree = 1; i >= 0; i--, degree *= 2)
        {
            result = result + GetNumber(numberToString, i) * degree;
        }
        return result;
    }

}
