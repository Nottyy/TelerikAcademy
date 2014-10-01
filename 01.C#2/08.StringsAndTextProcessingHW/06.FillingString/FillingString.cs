//Write a program that reads from the console a string of maximum 20 characters. If the length of the string is less than 20, the rest of the characters should be filled with '*'. Print the result string into the console.

using System;

class FillingString
{
    static void Main()
    {
        string input = Console.ReadLine();

        int maxlength = 20;
        if (input.Length < maxlength)
        {
            Console.WriteLine(input.PadRight(maxlength,'*'));
        }

    
    }
}

