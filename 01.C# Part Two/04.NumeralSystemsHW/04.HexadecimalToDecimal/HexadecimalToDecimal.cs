//Write a program to convert hexadecimal numbers to their decimal representation.

using System;

class HexadecimalToDecimal
{
    static int GetNumber(string str, int i)
    {
        if (str[i] >= 'A')
        {
            return str[i] - 'A' + 10;
        }
        else
        {
            return str[i] - '0';
        }
    }

    static int Base16ToBase10(string str)
    {
        int d = 0;

        for (int i = str.Length - 1, p = 1; i >= 0; i--, p *= 16)
        {
            d = d + GetNumber(str, i) * p;
        }
        return d;
    }

    static void Main()
    {
        Console.WriteLine(Base16ToBase10("1E"));
    }
}
