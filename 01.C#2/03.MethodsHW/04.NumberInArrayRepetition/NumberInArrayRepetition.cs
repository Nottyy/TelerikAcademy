//Write a method that counts how many times given number appears in given array. Write a test program to check if the method is working correctly.

using System;

class NumberInArrayRepetition
{
    static int[] myArray = new int[20];

    static void Main(string[] args)
    {

        GenerateRandomArray();

        for (int i = 0; i < myArray.Length; i++)
        {
            Console.WriteLine("Value {0} appears {1} times", myArray[i], CountTimes(myArray[i]));

        }

    }

    private static int CountTimes(int element)
    {
        int count = 0;

        for (int i = 0; i < myArray.Length; i++)
        {
            if (element == myArray[i])
            {
                count++;
            }
        }

        return count;
    }

    private static void GenerateRandomArray()
    {
        Random randomNumber = new Random();

        for (int i = 0; i < myArray.Length; i++)
        {
            myArray[i] = randomNumber.Next(11); //generate random number between 0 and 10
        }
    }
}

