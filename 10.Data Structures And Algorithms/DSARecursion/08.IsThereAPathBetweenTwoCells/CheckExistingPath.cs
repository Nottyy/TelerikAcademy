using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.IsThereAPathBetweenTwoCells
{
    class CheckExistingPath
    {
        static string[,] matrix = SetMatrixSize(100, 100);
        static bool pathExists = false;

        static void Main()
        {
            int startRow = 14;
            int startCol = 0;
            int endRow = 90;
            int endCol = 90;

            matrix[endRow, endCol] = "e";
            

            Solve(startRow, startCol);
            if (pathExists == false)
            {
                Console.WriteLine("There is no existing path!");
            }
        }

        static private void Solve(int row, int col)
        {
            if (!pathExists)
            {
                if (row < 0 || col < 0 || row >= matrix.GetLength(0) || col >= matrix.GetLength(1))
                {
                    return;
                }
                else if (matrix[row, col] == "e")
                {
                    pathExists = true;
                    Console.WriteLine("There is an Existing path!");
                    return;
                }
                else if (matrix[row, col] != " ")
                {
                    return;
                }

                matrix[row, col] = "X";
                Solve(row, col + 1);
                Solve(row + 1, col);
                Solve(row, col - 1);
                Solve(row - 1, col);

                matrix[row, col] = " ";
            }
            
        }

        static private string[,] SetMatrixSize(int allRows, int AllCols)
        {
            string[,] sampleMatrix = new string[allRows, AllCols];

            for (int i = 0; i < allRows; i++)
            {
                for (int j = 0; j < AllCols; j++)
                {
                    sampleMatrix[i, j] = " ";
                }
            }

            return sampleMatrix;
        }
    }
}
