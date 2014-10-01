//Write a program that can solve these tasks:
//Reverses the digits of a number
//Calculates the average of a sequence of integers
//Solves a linear equation a * x + b = 0

using System;

class MultiTask
{
    static double Average(int[] arr)
    {
        double average = 0;
        int sum = 0;
        for (int j = 0; j < arr.Length; j++)
        {
            sum = arr[j] + sum;
        }

        return average = sum / (double)arr.Length;
    }

    static double Equation(int a, int b)
    {
        double result = (double)-b / a;
        return result;
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

    static void Main()
    {
        Console.WriteLine("Please select the desired function and enter the coresponding number");
        Console.WriteLine("1-Reverse the digits of a number");
        Console.WriteLine("2-Calculate the average of a sequence of integers");
        Console.WriteLine("3-Solve a linear equation");
        int choice = int.Parse(Console.ReadLine());
        if (choice < 1 || choice > 3)
        {
            Console.WriteLine("Invalid selection please try again");
        }
        else if (choice == 1)
        {
            Console.WriteLine("Please enter a number");
            int number = int.Parse(Console.ReadLine());
            if (number >= 0)
            {
                Console.WriteLine(DigitsReverse(number));
            }
            else
            {
                Console.WriteLine("Please enter a valid number(bigger than 0)");
            }
        }
        else if (choice == 2)
        {
            Console.WriteLine("How many numbers are in the sequence");
            int sequenceCount = int.Parse(Console.ReadLine());
            if (sequenceCount > 0)
            {
                var myArray = new int[sequenceCount];
                for (int i = 0; i < myArray.Length; i++)
                {
                    Console.WriteLine("Input {0} number", i);
                    myArray[i] = int.Parse(Console.ReadLine());
                }

                double finalAverage = Average(myArray);
                Console.WriteLine(finalAverage);
            }
            else
            {
                Console.WriteLine("Please enter a valid number(bigger than 0)");
            }
        }
        else if (choice == 3)
        {
            Console.WriteLine("Enter values for a and b in the following equation: a*x+b=0");
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            if (a == 0)
            {
                Console.WriteLine("Please enter a value for a different from zero");
            }
            else
            {
                double finalResult = Equation(a, b);
                Console.WriteLine("Result: {0}", finalResult);
            }
        }
    }
}

