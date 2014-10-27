namespace ExceptionsHomework
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Utils
    {
        public static T[] Subsequence<T>(T[] arr, int startIndex, int count)
        {
            if (arr == null || arr.Length == 0)
            {
                throw new ArgumentNullException("Array must have elements.");
            }
            if (startIndex < 0)
            {
                throw new ArgumentOutOfRangeException("startIndex", "startIndex cannot be less than zero.");
            }

            if (startIndex > arr.Length)
            {
                throw new ArgumentOutOfRangeException("startIndex", "startIndex cannot be larger than the length of the array.");
            }

            if (count < 0)
            {
                throw new ArgumentOutOfRangeException("count", "count cannot be less than zero.");
            }

            if (startIndex > arr.Length - count)
            {
                throw new ArgumentOutOfRangeException("count", "index and count must refer to a location within the array.");
            }

            if (count == 0)
            {
                return new T[0];
            }

            List<T> result = new List<T>();
            for (int i = startIndex; i < startIndex + count; i++)
            {
                result.Add(arr[i]);
            }
            return result.ToArray();
        }

        public static string ExtractEnding(string str, int length)
        {
            if (str == null)
            {
                throw new ArgumentNullException("string value cannot be null.");
            }

            if (length == null)
            {
                throw new ArgumentNullException("length cannot be null.");
            }

            if (length < 0)
            {
                throw new ArgumentOutOfRangeException("length cannot be less than zero.");
            }

            if (length > str.Length)
            {
                throw new ArgumentOutOfRangeException("length cannot be greater than the length of the string.");
            }

            StringBuilder result = new StringBuilder();
            for (int i = str.Length - length; i < str.Length; i++)
            {
                result.Append(str[i]);
            }
            return result.ToString();
        }

        public static bool CheckPrime(int number)
        {
            if (number < 2)
            {
                throw new ArgumentOutOfRangeException("Only natural numbers greater than 1 can be primes.");
            }

            for (int divisor = 2; divisor <= Math.Sqrt(number); divisor++)
            {
                if (number % divisor == 0)
                {
                    return false;
                }
            }

            return true;
        }

    }
}
