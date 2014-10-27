using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.CalculationOfIntegersWithList
{
    public class CalculationOfIntegersWithList
    {
        static void Main()
        {
            Console.WriteLine("Enter each integer on a single line and end the sequence with empty line!");
            string currentNumber = Console.ReadLine();
            List<int> numbers = new List<int>();

            while (currentNumber != "")
            {
                numbers.Add(int.Parse(currentNumber));
                currentNumber = Console.ReadLine();
            }

            int sumCalculation = CalculateSum(numbers);
            Console.WriteLine("The sum of the integer sequence is: {0}", sumCalculation);

            double averageOfElements = CalculateAverage(numbers, sumCalculation);
            Console.WriteLine("The average of the integer sequence is: {0}", averageOfElements);
        }

        private static int CalculateSum(List<int> numbers)
        {
            int sum = 0;

            for (int i = 0; i < numbers.Count; i++)
            {
                sum += numbers[i];
            }

            return sum;
        }

        private static double CalculateAverage(List<int> numbers, int sumOfElements)
        {
            double average = sumOfElements/ numbers.Count;

            return average;
        }
    }
}
