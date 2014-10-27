//Write a method that reverses the digits of given decimal number. Example: 256  652

using System;

class ReverseDigits
{
    static void Main()
    {
        Console.WriteLine("Enter number: ");
        int number = int.Parse(Console.ReadLine());
        Console.WriteLine(DigitsReverse(number));
        
    }

    static int DigitsReverse(int num)
    {
        int reversed = 0;

        while (num > 0)
        {
            reversed = reversed * 10 + num % 10;
            num /= 10;
        }

        return reversed;
    }
}

