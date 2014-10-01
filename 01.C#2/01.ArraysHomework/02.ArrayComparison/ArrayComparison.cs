//Write a program that reads two arrays from the console and compares them element by element.

using System;

class ArrayComparison
{

    static void Main(string[] args)
    {
        Console.WriteLine("The lenght of the arrays is:");
        int n = int.Parse(Console.ReadLine());
        int[] arrayOne = new int[n];
        int[] arrayTwo = new int[n];
        Console.WriteLine("Elements of a first array:");
        for (int i = 0; i < n; i++)
        {
            arrayOne[i] = int.Parse(Console.ReadLine());
        }
        Console.WriteLine("Elements of a second array:");
        for (int i = 0; i < n; i++)
        {
            arrayTwo[i] = int.Parse(Console.ReadLine());
        }
        
        for (int i = 0; i < n; i++)
        {
            bool equal = true;
            if (arrayOne[i] == arrayTwo[i])
            {
                Console.WriteLine("Element ({0}) is equal in the first and second array - {1}", i, equal);
            }
            else
            {
                equal = false;
                Console.WriteLine("Element ({0}) is equal in the first and second array - {1}", i, equal);
            }
        }
    }

}

