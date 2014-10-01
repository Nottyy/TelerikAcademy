//Write a program that reads two dates in the format: day.month.year and calculates the number of days between them. 

using System;

class TimeLapseCalculator
{
    static void Main()
    {
        Console.WriteLine("Please enter a date in the format:day.month.year");
        string firstDate = Console.ReadLine();
        Console.WriteLine("Please enter a date in the format:day.month.year");
        string secondDate = Console.ReadLine();
        var numberOfDays = (DateTime.Parse(secondDate) - DateTime.Parse(firstDate)).TotalDays;
        Console.WriteLine("The difference between given dates is:{0} days", numberOfDays);
    }
}

