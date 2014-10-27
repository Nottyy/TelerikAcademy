using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13.Divisors
{
    class Program
    {
        static int counter;
        static int minDivisors = int.MaxValue;
        static int minNumber = int.MaxValue;

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] arr = new int[n];

            for (int i = 0; i < n; i++)
			{
                arr[i] = int.Parse(Console.ReadLine());
			}

            Perm(arr, 0);
            Console.WriteLine(minNumber);
        }

        static void Perm<T>(T[] arr, int k)
        {
            if (k >= arr.Length)
            {
                int currentNum = int.Parse(string.Join("", arr));
                var currentDivisors = Factor(currentNum);

                if (currentDivisors < minDivisors)
                {
                    minDivisors = currentDivisors;
                    minNumber = currentNum;
                }
            }
            else
            {
                Perm(arr, k + 1);
                for (int i = k + 1; i < arr.Length; i++)
                {
                    Swap(ref arr[k], ref arr[i]);
                    Perm(arr, k + 1);
                    Swap(ref arr[k], ref arr[i]);
                }
            }
        }

        private static int Factor(int number)
        {
            int count = 0;
            for (int i = 1; i < number / 2 + 2; i++)
            {
                if (number % i == 0)
                {
                    count++;
                }
            }

            return count + 1;
        }

        static void Swap<T>(ref T first, ref T second)
        {
            T oldFirst = first;
            first = second;
            second = oldFirst;
        }
    }
}
