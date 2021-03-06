﻿//Write a program that reads a year from the console and checks whether it is a leap. Use DateTime.

using System;

class IsTheYearLeap
{
    static void Main()
    {
        Console.WriteLine("Enter Year: ");
        int year = int.Parse(Console.ReadLine());

        if (DateTime.IsLeapYear(year))
        {
            Console.WriteLine("The year {0} is leap.", year);
        }
        else
        {
            Console.WriteLine("The year {0} is not leap.", year);
        }
    }
}

