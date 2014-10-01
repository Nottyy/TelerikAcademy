//Write a program that reads an integer number and calculates and prints its square root. If the number is invalid or negative, print "Invalid number". In all cases finally print "Good bye". Use try-catch-finally.

using System;

class CheckSquareRoot
{
    static void Main()
    {
        Console.WriteLine("Enter number: ");
        try
        {
            
            int number = int.Parse(Console.ReadLine());
            CheckForNegativeNumber(number);
            double squareRoot = Math.Sqrt(number);
            Console.WriteLine("The square root of {0} is {1}.",number , squareRoot);


        }
        catch (FormatException formatException)
        {
            throw new FormatException("Invalid number! " + formatException.Message);
        }
        catch (OverflowException)
        {
            Console.WriteLine("The input number is too big or too small!");
        }
        finally
        {
            Console.WriteLine("Goodbye!");
        }

        
    }

    static void CheckForNegativeNumber(int number)
    {
        if (number < 0)
        {
            throw new ArithmeticException("Invalid number! The square root is defined only for non-negative numbers!");
        }
    }
}

