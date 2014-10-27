//We are given a matrix of strings of size N x M. Sequences in the matrix we define as sets of several neighbor elements located on the same line, column or diagonal. Write a program that finds the longest sequence of equal strings in the matrix.

using System;

class LongestSequenceOfEqualStrings
{
    static int colCount;
    static int rowCount;
    static int longestSequenceCounter = int.MinValue;
    static string longestSequenceStr = " ";
    static string[,] array;

    static void Main()
    {
        colCount = 4;
        rowCount = 3;

        array = new string[,] { { "hu", "he", "sr", "hu" }, 
                                { "hw", "sr", "he", "xx" }, 
                                { "sr", "ho", "ha", "ha" } };

        for (int row = 0; row < rowCount; row++)
        {
            for (int col = 0; col < colCount; col++)
            {
                MoveRight(1, row, col + 1);
                MoveDown(1, row + 1, col);
                MoveCorner(1, row + 1, col + 1);
                MoveCornerRight(1, row + 1, col);
            }
        }

        for (int i = 0; i < longestSequenceCounter; i++)
        {
            Console.Write(longestSequenceStr + " ");
        }
    }

    static void GetLongestSequence(int counter, int row, int col)
    {
        if (counter > longestSequenceCounter)
        {
            longestSequenceCounter = counter;
            longestSequenceStr = array[row, col];
        }
    }

    static void MoveCornerRight(int count, int row, int col)
    {
        if (col >= colCount - 1 || row >= rowCount || col < 0) return;
        if (array[row, col] == array[row - 1, col + 1])
        {
            count++;
            GetLongestSequence(count, row, col);
            MoveCornerRight(count, row + 1, col - 1);
        }
        else
        {
            return;
        }
    }

    static void MoveRight(int count, int row, int col)
    {
        if (col >= colCount || row >= rowCount) return;
        if (array[row, col] == array[row, col - 1])
        {
            count++;
            GetLongestSequence(count, row, col);
            MoveRight(count, row, col + 1);
        }
        else
        {
            return;
        }
    }

    static void MoveDown(int count, int row, int col)
    {
        if (col >= colCount || row >= rowCount) return;
        if (array[row, col] == array[row - 1, col])
        {
            count++;
            GetLongestSequence(count, row, col);
            MoveDown(count, row + 1, col);

        }
        else
        {
            return;
        }
    }

    static void MoveCorner(int count, int row, int col)
    {
        if (col >= colCount || row >= rowCount) return;
        if (array[row, col] == array[row - 1, col - 1])
        {
            count++;
            GetLongestSequence(count, row, col);
            MoveCorner(count, row + 1, col + 1);
        }
        else
        {
            return;
        }
    }
}

