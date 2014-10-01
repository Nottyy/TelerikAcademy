//Write a method that returns the last digit of given integer as an English word. Examples: 512  "two", 1024  "four", 12309  "nine".

using System;

class ReturnLastDigitAsWord
{
    static string[] digitNames = new string[] { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
    static void Main()
    {
        Console.WriteLine("Enter number: ");
        int n = int.Parse(Console.ReadLine());

        Console.WriteLine(ReturnLastDigit(n));
    }

    static string ReturnLastDigit(int num)
    {
        int lastDigit = num % 10;

        return digitNames[lastDigit];
    }
}

