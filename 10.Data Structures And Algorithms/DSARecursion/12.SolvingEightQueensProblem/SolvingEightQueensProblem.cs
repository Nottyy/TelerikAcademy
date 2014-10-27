using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8.SolvingQueensProblem
{
    class SolvingEightQueensProblem
    {
        static int count = 0;

        static void Main(string[] args)
        {
            int size = 10;
            SolvingQueensProblem(new bool[size, size], new int[size, size], 0);
            Console.WriteLine(count);
        }

        static void SolvingQueensProblem(bool[,] board, int[,] occupied, int columnIndex)
        {
            if (columnIndex == board.GetLength(0))
            {
                count++;
                return;
            }
            for (int rowIndex = 0; rowIndex < board.GetLength(0); rowIndex++)
            {
                if (occupied[rowIndex, columnIndex] == 0)
                {
                    board[rowIndex, columnIndex] = true;
                    MarkOccupied(occupied, +1, rowIndex, columnIndex);
                    SolvingQueensProblem(board, occupied, columnIndex + 1);
                    board[rowIndex, columnIndex] = false;
                    MarkOccupied(occupied, -1, rowIndex, columnIndex);
                }
            }
        }

        static void MarkOccupied(int[,] occupied, int value, int row, int column)
        {
            for (int i = 0; i < occupied.GetLength(0); i++)
            {
                occupied[i, column] += value;
                occupied[row, i] += value;

                if (row + i < occupied.GetLength(0) && column + i < occupied.GetLength(0))
                {
                    occupied[row + i, column + i] += value;
                }
                if (row - i >= 0 && column + i < occupied.GetLength(0))
                {
                    occupied[row - i, column + i] += value;
                }
            }
        }
    }
}
