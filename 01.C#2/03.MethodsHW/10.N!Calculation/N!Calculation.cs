//Write a program to calculate n! for each n in the range [1..100]. Hint: Implement first a method that multiplies a number represented as array of digits by given integer number. 

using System;
using System.Numerics;
using System.Collections.Generic;
using System.Text;

class FactorialOfFirst100Numbers
{
    public static void FillArray(int[] array, string number) // Make the string to array
    {
        for (int i = 0; i < array.Length; i++)
        {
            array[i] = int.Parse(number[number.Length - i - 1].ToString());
        }
    }

    public static int[] Multiply(int[] firstArray, int[] secondArray)
    {
        int[] result = new int[firstArray.Length + secondArray.Length];

        if (firstArray.Length < secondArray.Length)
        {
            int[] temp = secondArray;
            secondArray = firstArray;
            firstArray = temp;
        }

        List<int[]> multyplication = new List<int[]>();

        // Multiply the two numbers
        for (int i = 0; i < secondArray.Length; i++)
        {
            multyplication.Add(new int[firstArray.Length + i + 1]);

            for (int j = 0; j < firstArray.Length; j++)
            {
                multyplication[i][j + i] = secondArray[i] * firstArray[j];
            }
        }

        // Check if there are elements that are bigger than 9 and extract their figures
        for (int i = 0; i < multyplication.Count; i++)
        {
            for (int j = 0; j < multyplication[i].Length; j++)
            {
                if (multyplication[i][j] > 9)
                {
                    int mod = multyplication[i][j] % 10;
                    multyplication[i][j + 1] += multyplication[i][j] / 10;
                    multyplication[i][j] = mod;
                }
            }
        }

        // Sum the elements to complete the multiplication
        for (int j = 0; j < multyplication.Count; j++)
        {
            for (int k = 0; k < multyplication[j].Length; k++)
            {
                result[k] += multyplication[j][k];
            }
        }

        // Check aggain if there are elements that are bigger than 9 and extract their figures
        for (int i = 0; i < result.Length; i++)
        {
            if (result[i] > 9)
            {
                int mod = result[i] % 10;
                result[i + 1] += result[i] / 10;
                result[i] = mod;
            }
        }

        return result;
    }

    public static string GetFactorial(int[] array) // Make the array to string
    {
        StringBuilder factorial = new StringBuilder();

        int zerosAtTheBeggingCounter = 0;

        // Remove useless zeros at the begging of the factorial
        for (int i = array.Length - 1; i >= 0; i--)
        {
            if (array[i] == 0)
            {
                zerosAtTheBeggingCounter++;
            }
            else
            {
                break;
            }
        }

        for (int i = zerosAtTheBeggingCounter; i < array.Length; i++)
        {
            factorial.Append(array[array.Length - i - 1].ToString());
        }

        return factorial.ToString();
    }

    static void Main(string[] args)
    {
        Console.Title = "Factorial";

        List<int[]> factorials = new List<int[]>();

        string number = "1";
        int[] numberArray = new int[number.Length];
        FillArray(numberArray, number);
        factorials.Add(numberArray);

        int index = 0;

        Console.WriteLine("Factorial 1! = {0}", GetFactorial(factorials[0]));

        for (int n = 2; n <= 100; n++)
        {
            number = n.ToString();
            numberArray = new int[number.Length];
            FillArray(numberArray, number);
            factorials.Add(Multiply(factorials[index], numberArray));
            index++;
            Console.WriteLine("Factorial {0}! = {1}", index + 1, GetFactorial(factorials[index]));
        }

        Console.WriteLine();
    }
}

