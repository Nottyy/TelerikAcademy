//Write a program that prints from given array of integers all numbers that are divisible by 7 and 3. Use the built-in extension methods and lambda expressions. Rewrite the same with LINQ.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class PrintAllNumbersDivisibleBy3And7
{
    static void Main()
    {
        int[] array = { 21, 22, 49, 7, 21, 42, 56, 73, 63, 2100 };

        //With lambda expression

        int[] arr = Array.FindAll(array, num => num % 21 == 0);

        foreach (int num in arr)
        {
            Console.WriteLine(num);
        }

        Console.WriteLine();
        //With LINQ

        var arrNums = from num in array where num % 21 == 0 select num;

        foreach (int num in arrNums)
        {
            Console.WriteLine(num);
        }
    }
}

