//Write a program that reads a rectangular matrix of size N x M and finds in it the square 3 x 3 that has maximal sum of its elements.

using System;

class RectangularMatrixMaxSumOfElements
{
    static void Main()
    {
        Random randomNumb = new Random();
        int rowsNumberN = randomNumb.Next(3, 15);
        int colsNumberN = randomNumb.Next(3, 15);

        int[,] matrix = new int[rowsNumberN, colsNumberN];

        ////create randomly generated matrix with elements till 100;
        matrix = RandomMatrix(matrix, rowsNumberN, colsNumberN);

        //print Matrix
        Print(matrix);
        //check for max sum
        CheckMaxSum(matrix, rowsNumberN, colsNumberN);
    }

    private static int[,] RandomMatrix(int[,] matrix, int rowsNumberN, int colsNumberN)
    {
        Random randomNumb = new Random();
        for (int i = 0; i < rowsNumberN; i++)
        {
            for (int j = 0; j < colsNumberN; j++)
            {
                matrix[i, j] = randomNumb.Next(100);
            }
        }
        return matrix;
    }

    private static void CheckMaxSum(int[,] matrix, int rowsNumberN, int colsNumberK)
    {
        int bestSum = int.MinValue;
        int totalSum;
        int bestCellRow = 0;
        int bestCellCol = 0;

        for (int rows = 0; rows < rowsNumberN - 3; rows++)
        {
            for (int cols = 0; cols < colsNumberK - 3; cols++)
            {
                totalSum = SumMatrix(matrix, rows, cols);

                if (totalSum >= bestSum)
                {
                    bestSum = totalSum;
                    bestCellRow = rows;
                    bestCellCol = cols;
                }
            }
        }
        Console.WriteLine("The maximum sum is: {0}", bestSum);
        PrintSmallMatrix(matrix, bestCellRow, bestCellCol);

    }

    private static void PrintSmallMatrix(int[,] matrix, int rows, int cols)
    {
        Console.WriteLine("The coordinate of the first cell is ({0},{1})", rows + 1, cols + 1);
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                Console.Write("{0,3}", matrix[rows + i, cols + j]);
            }
        }
        Console.WriteLine();
    }
    private static int SumMatrix(int[,] matrix, int rows, int cols)
    {
        int totalSum = 0;
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                totalSum += matrix[rows + i, cols + j];
            }
        }
        return totalSum;
    }

    private static void Print(int[,] matrix)
    {
        int lengthRows = matrix.GetLength(0);
        int lengthCols = matrix.GetLength(1);

        for (int i = 0; i < lengthRows; i++)
        {
            for (int j = 0; j < lengthCols; j++)
            {
                Console.Write("{0,3} ", matrix[i, j]);
            }
            Console.WriteLine();
        }
    }

}

