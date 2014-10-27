//Write a method that adds two positive integer numbers represented as arrays of digits (each array element arr[i] contains a digit; the last digit is kept in arr[0]). Each of the numbers that will be added could have up to 10 000 digits.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


class SumTwoArraysOfDigits
{
    static void Main(string[] args)
    {
        
        int[] firstArray = { 9, 4, 1, 9, 3 };
        int[] secondArray = { 1, 5, 6, 7, 9, 9, 9 };

        string total = SumArrays(firstArray, secondArray);
        Console.WriteLine(total);

    }

    private static string SumArrays(int[] firstArray, int[] secondArray)
    {
        List<int> maxArray = new List<int>();
        List<int> minArray = new List<int>();

        if (firstArray.Length > secondArray.Length)
        {
            maxArray.AddRange(firstArray);
            minArray.AddRange(secondArray);
        }
        else
        {
            maxArray.AddRange(secondArray);
            minArray.AddRange(firstArray);
        }

        int minLength = minArray.Count;
        int maxLength = maxArray.Count;
        int addition = 0;
        int sum = 0;

        StringBuilder result = new StringBuilder();

        for (int i = 0; i < minLength; i++)
        {
            sum = minArray[i] + maxArray[i] + addition;

            if (sum >= 10)
            {
                addition = 1;
                sum = sum % 10;
                result.Append(sum);
            }
            else
            {
                addition = 0;
                result.Append(sum);
            }
        }

        for (int j = minLength; j < maxLength; j++)
        {
            sum = maxArray[j] + addition;

            if (sum >= 10)
            {
                addition = 1;
                sum = sum % 10;
                result.Append(sum);
            }
            else
            {
                addition = 0;
                result.Append(sum);
            }
        }

        if (addition == 1)
        {
            result.Append(1);
        }

        char[] reversed = (result.ToString()).ToCharArray();
        result.Clear();

        for (int i = reversed.Length - 1 ; i >= 0; i--)
        {
            result = result.Append(reversed[i]);
        }

        return result.ToString();
    }
}
