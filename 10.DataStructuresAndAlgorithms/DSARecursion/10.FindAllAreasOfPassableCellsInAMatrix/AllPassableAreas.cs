using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10.FindAllAreasOfPassableCellsInAMatrix
{
    class AllPassableAreas
    {
        static string[,] matrix =  
            {
            {" ", " ", " ", "*", " ", "*", " "},
            {"*", "*", " ", "*", " ", "*", " "},
            {" ", " ", " ", " ", " ", "*", " "},
            {"*", "*", "*", "*", "*", "*", " "},
            {" ", " ", " ", " ", "*", " ", " "},
        };
        static int areas = 0;

        static void Main()
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == " ")
                    {
                        Solve(i, j);
                        areas++;
                    }
                }
            }
            Console.WriteLine("The areas with passable cells are - {0}", areas);
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

            Solve(row, col + 1);
            Solve(row + 1, col);
            Solve(row, col - 1);
            Solve(row - 1, col);
        }
    }
}
