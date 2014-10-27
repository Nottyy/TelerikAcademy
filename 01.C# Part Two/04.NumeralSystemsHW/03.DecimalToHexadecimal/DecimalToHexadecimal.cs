//Write a program to convert decimal numbers to their hexadecimal representation.

using System;
using System.Collections.Generic;
class DecimalToHexadecimal
{
    static char GetChar(int i)
    {
        if (i >= 10)
        {
            return (char)('A' + i - 10);
        }
        else
        {
            return (char)('0' + i);
        }
    }

    static string Base10ToBase16(int d)
    {
        string h = String.Empty;

        for (int i = d; i != 0; i /= 16)
        {
            h = GetChar(d % 16) + h;
        }
        return h;
    }

    static void Main()
    {
        Console.WriteLine(Base10ToBase16(253));
    }
    //static void Main()
    //{
    //    int number = 11;
    //    List<string> str = DecimalToHexadecimalConversion(ref number);
    //    Print(str);
    //}

    //private static void Print(List<string> str)
    //{
    //    foreach (var sign in str)
    //    {
    //        Console.Write(sign);
    //    }
    //    Console.WriteLine();
    //}

    //private static List<string> DecimalToHexadecimalConversion(ref int number)
    //{
    //    List<string> str = new List<string>();

    //    string letters = "ABCDEF";
    //    while (number != 0)
    //    {
    //        int carry = number % 16;
    //        if (carry > 10)
    //        {
    //            str.Add(letters[carry - 10].ToString());
    //        }
    //        else
    //        {
    //            str.Add(carry.ToString());
    //        }
    //        number /= 16;
    //    }
    //    str.Reverse();
    //    return str;
    //}
}

