using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09.FindLargestConnectedAreaOfAdjacentEmptyCells
{
    class FindLargestConnectedAreaOfAdjacentEmptyCells
    {
        static string[,] matrix =  
            {
            {" ", " ", " ", "*", " ", "*", " "},
            {"*", "*", " ", "*", " ", "*", " "},
            {" ", " ", " ", " ", " ", "*", " "},
            {"*", "*", "*", "*", "*", "*", " "},
            {" ", " ", " ", " ", " ", " ", " "},
        };
        static int maxSum = 0;
        static int currentSum = 0;

        static void Main()
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i,j] == " ")
                    {
                        Solve(i, j);
                    }

                    if (currentSum > maxSum)
                    {
                        maxSum = currentSum;
                    }

                    currentSum = 0;
                }
            }
            Console.WriteLine("The max sum of adjacent empty cells is - {0}", maxSum);
        }

        static private void Solve(int row, int col)
        {
            if (row < 0 || col < 0 || row >= matrix.GetLength(0) || col >= matrix.GetLength(1))
            {
                return;
            }
            else if (matrix[row, col] != " ")
            {
                return;
            }

            matrix[row, col] = "*";
            currentSum++;

            Solve(row, col + 1);
            Solve(row + 1, col);
            Solve(row, col - 1);
            Solve(row - 1, col);
        }
    }
}
