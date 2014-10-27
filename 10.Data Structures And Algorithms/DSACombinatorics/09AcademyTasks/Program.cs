using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09AcademyTasks
{
    class Program
    {

        static int[] numbers;
        static int variety;
        static int bestSolution;
        static int maxIndex;
        static void Main()
        {
            string pleasentLine = Console.ReadLine();
            string[] pleasentNumbers = pleasentLine.Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
            variety = int.Parse(Console.ReadLine());

            numbers = new int[pleasentNumbers.Length];

            for (int i = 0; i < pleasentNumbers.Length; i++)
            {
                numbers[i] = int.Parse(pleasentNumbers[i]);
            }

            var currentMin = numbers[0];
            var currentMax = numbers[0];
            maxIndex = -1;
            for (int i = 0; i < numbers.Length; i++)
            {
                currentMax = Math.Max(numbers[i], currentMax);
                currentMin = Math.Min(numbers[i], currentMin);

                if (currentMax - currentMin >= variety)
                {
                    maxIndex = i;
                    break;
                }
            }

            if (maxIndex == - 1)
            {
                Console.WriteLine(numbers.Length);
                return;
            }
            bestSolution = numbers.Length;
            SolvePleasentNumbers(0, numbers[0], 1, numbers[0]);
            Console.WriteLine(bestSolution);
        }


        private static void SolvePleasentNumbers(int startPos, int minNumber,
            int tasksSolved, int maxNumber)
        {
            if (maxNumber - minNumber >= variety)
            {
                bestSolution = Math.Min(bestSolution, tasksSolved);

                return;
            }

            if (startPos >= maxIndex)
            {
                return;
            }

            for (int i = 2; i >= 1; i--)
            {
                if (startPos + i < numbers.Length)
                {
                    SolvePleasentNumbers(startPos + i,
                        Math.Min(minNumber,
                        numbers[startPos + i]),
                        tasksSolved + 1,
                        Math.Max(maxNumber, numbers[startPos + i]));

                    if (bestSolution != numbers.Length)
                    {
                        return;
                    }
                }
            }

        }
    }
}
