using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.Sudoku
{
    class Sudoku
    {
        static int[,] sudoku = new int[9, 9];
        static void Main()
        {
            for (int i = 0; i < 9; i++)
            {
                string currentLine = Console.ReadLine();
                for (int j = 0; j < 9; j++)
                {
                    
                    if (currentLine[j] == '-')
                    {
                        sudoku[i, j] = 0;
                    }
                    else
                    {
                        sudoku[i, j] = currentLine[j] - '0';
                    }
                }
            }

            Solver(0, 0);
        }

        private static void Solver(int row, int col)
        {
            if (row == 9 && col == 0)
            {
                PrintSudoku();
                Environment.Exit(0);
            }
            else if (sudoku[row,col] == 0)
            {
                for (int i = 1; i <= 9; i++)
                {
                    if (CheckRow(row, i) || CheckCol(col, i) || CheckSquare(row, col, i))
                    {
                        continue;
                    }

                    sudoku[row, col] = i;
                    Solver(ReturnRow(row, col), ReturnCol(col));
                    sudoku[row, col] = 0;
                }
            }
            else
            {
                Solver(ReturnRow(row, col), ReturnCol(col));
            }
        }

        static bool CheckSquare(int row, int col, int number)
        {
            var startRow = (row / 3) * 3;
            var startCol = (col / 3) * 3;

            for (int i = startRow; i < startRow + 3; i++)
            {
                for (int j = startCol; j < startCol + 3; j++)
                {
                    if (sudoku[i, j] == number)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        static bool CheckRow(int row, int number)
        {
            for (int i = 0; i < 9; i++)
            {
                if (sudoku[row,i] == number)
                {
                    return true;
                }
            }
            return false;
        }

        static bool CheckCol(int col, int number)
        {
            for (int i = 0; i < 9; i++)
            {
                if (sudoku[i, col] == number)
                {
                    return true;
                }
            }

            return false;
        }

        static int ReturnRow(int row, int col)
        {
            col++;
            if (col > 8)
            {
                return row + 1;
            }
            return row;
        }

        static int ReturnCol(int col)
        {
            col++;
            if (col > 8)
            {
                return 0;
            }

            return col;
        }
        private static void PrintSudoku()
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    Console.Write(sudoku[i,j]);
                }
                Console.WriteLine();
            }
        }
    }
}
