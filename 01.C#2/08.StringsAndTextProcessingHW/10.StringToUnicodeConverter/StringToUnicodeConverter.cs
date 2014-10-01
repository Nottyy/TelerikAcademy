//Write a program that converts a string to a sequence of C# Unicode character literals. Use format strings. 

using System;

class StringToUnicodeConverter
{
    static void Main()
    {
        string input = "Hi! How are you?";

        for (int i = 0; i < input.Length; i++)
        {
            Console.WriteLine("\\u{0:X4}", (int)input[i]);
        }
        Console.WriteLine();
    }
}

