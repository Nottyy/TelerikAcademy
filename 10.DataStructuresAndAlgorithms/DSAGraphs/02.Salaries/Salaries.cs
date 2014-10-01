using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Salaries
{
    // Everything is in one file in order to test the task in bgcoder.
    class Salaries
    {
        static int C = int.Parse(Console.ReadLine());
        static string[,] matrix = new string[C, C];
        static long[] employeeSalaries = new long[C];

        static void Main(string[] args)
        {
            for (int i = 0; i < C; i++)
            {
                string line = Console.ReadLine();
                for (int j = 0; j < C; j++)
                {
                    matrix[i, j] = line[j].ToString();
                }
            }

            long allSalaries = 0;

            for (int i = 0; i < C; i++)
            {
                allSalaries += FindSalary(i);
            }

            Console.WriteLine(allSalaries);
        }

        static long FindSalary(int employee)
        {
            if (employeeSalaries[employee] != 0)
            {
                return employeeSalaries[employee];
            }

            long currentEmployeeSum = 0;

            for (int i = 0; i < C; i++)
            {
                if (matrix[employee,i] == "Y")
                {
                    currentEmployeeSum += FindSalary(i);
                }
            }

            if (currentEmployeeSum == 0)
            {
                currentEmployeeSum = 1;
            }

            employeeSalaries[employee] = currentEmployeeSum;

            return currentEmployeeSum;
        }
    }
}
