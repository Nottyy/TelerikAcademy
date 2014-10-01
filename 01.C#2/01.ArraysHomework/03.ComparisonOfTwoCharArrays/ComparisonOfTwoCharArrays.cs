//Write a program that compares two char arrays lexicographically (letter by letter).

using System;

class ComparisonOfTwoCharArrays
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter the length of the first char array: ");
        int n = int.Parse(Console.ReadLine());

        Console.WriteLine("Enter the length of the second char array: ");
        int m = int.Parse(Console.ReadLine());

        char[] firstArray = new char[n];
        char[] secondArray = new char[m];

        if (n == m)
        {
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("Enter ({0}) element in the first array: ", i);
                firstArray[i] = char.Parse(Console.ReadLine());
            }

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("Enter ({0}) element in the second array: ", i);
                secondArray[i] = char.Parse(Console.ReadLine());

                if (firstArray[i] > secondArray[i])
                {
                    Console.WriteLine("Lexicographically The Second Array is First");
                    break;
                }
                else if (firstArray[i] < secondArray[i])
                {
                    Console.WriteLine("Lexicographically The First Array is First");
                    break;
                }
                else if ((i == n))
                {
                    Console.WriteLine("Lexicographically The  Arrays are Equal");
                }
            }
        }

        else if (n < m)
        {
            Console.WriteLine("Lexicographically The First Array is First");
        }
        else
        {
            Console.WriteLine("Lexicographically The Second Array is First");
        }
    }
}

