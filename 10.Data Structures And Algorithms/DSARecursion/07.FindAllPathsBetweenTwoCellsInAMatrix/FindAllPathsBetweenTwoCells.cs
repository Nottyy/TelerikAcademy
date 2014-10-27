using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.FindAllPathsBetweenTwoCellsInAMatrix
{
    class FindAllPathsBetweenTwoCells
    {
        static string[,] matrix =  
            {
            {" ", " ", " ", "*", " ", " ", " "},
            {"*", "*", " ", "*", " ", "*", " "},
            {" ", " ", " ", " ", " ", " ", " "},
            {" ", "*", "*", "*", "*", "*", " "},
            {" ", " ", " ", " ", " ", " ", " "},
        };
        static int counter = 0;

        static void Main()
        {
            int startRow = 4;
            int startCol = 0;
            int endRow = 0;
            int endCol = 6;

            matrix[endRow, endCol] = "e";

            Solve(startRow, startCol);

            Console.WriteLine("All paths from startRow '{0}', startCol '{1}' to endRow '{2}', endCol '{3}' are ''{4}''",
                startRow,startCol,endRow,endCol,counter);
        }

        static private void Solve(int row, int col)
        {
            if (row < 0 || col < 0 || row >= matrix.GetLength(0) || col >= matrix.GetLength(1))
            {
                return;
            }
            else if (matrix[row, col] == "e")
            {
                counter++;
                return;
            }
            else if (matrix[row, col] != " ")
            {
                return;
            }

            matrix[row, col] = "X";
            Solve(row, col + 1);
            Solve(row + 1, col);
            Solve(row, col -1);
            Solve(row - 1, col);

            matrix[row, col] = " ";
        }
    }
}
