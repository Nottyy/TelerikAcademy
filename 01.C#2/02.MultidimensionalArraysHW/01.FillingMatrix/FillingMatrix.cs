// Write a program that fills and prints a matrix of size (n, n) 

using System;

class FillingMatrix
{
    static void Main()
    {
        Console.WriteLine("Enter matrix size: ");
        int n = int.Parse(Console.ReadLine());

        int[,] matrix = new int[n, n];
        int digit = 1;

        // A)----------------------------------------------------------------
        for (int col = 0; col < n; col++)
        {
            for (int row = 0; row < n; row++)
            {
                matrix[row, col] = digit;
                digit++;
            }
            Console.WriteLine();
        }

        for (int row = 0; row < n; row++)
        {
            for (int col = 0; col < n; col++)
            {
                Console.Write(matrix[row, col] + " ");     //Print the matrix
            }
            Console.WriteLine();
        }

        // B)------------------------------------------------------------------
        digit = 1;
        for (int col = 0; col < n; col++)
        {
            if (col % 2 == 0)
            {
                for (int row = 0; row < n; row++)
                {
                    matrix[row, col] = digit;
                    digit++;
                }
            }
            else
            {
                for (int row = n - 1; row >= 0; row--)
                {
                    matrix[row, col] = digit;
                    digit++;
                }
            }
            Console.WriteLine();
        }

        for (int row = 0; row < n; row++)
        {
            for (int col = 0; col < n; col++)
            {
                Console.Write(matrix[row, col] + " ");     //Print the matrix
            }
            Console.WriteLine();
        }
        Console.WriteLine();
        // C)----------------------------------------------------------------------
        digit = 1;
        int startRow = n-1;
        int startCol = 0;
        int r = n - 1;
        int c = 0;
        matrix[r, c] = 1;
        while (digit < n*n)
        {
            if (r == n - 1 && c < n - 1)
            {
                startRow--;
                startCol = 0;
                r = startRow;
                c = startCol;
                digit++;
                matrix[r, c] = digit;

                while (r < n-1 && c < n - 1)
                {
                    r++;
                    c++;
                    digit++;
                    matrix[r, c] = digit;
                }
            }

            if (c == n - 1)
            {
                startRow = 0;
                startCol++;
                r = startRow;
                c = startCol;
                digit++;
                matrix[r, c] = digit;
                while (c < n - 1)
                {
                    digit++;
                    r++;
                    c++;
                    matrix[r, c] = digit;
                }
            }
        }

        for (int row = 0; row < n; row++)
        {
            for (int col = 0; col < n; col++)
            {
                Console.Write(matrix[row, col] + " ");     //Print the matrix
            }
            Console.WriteLine();
        }
        Console.WriteLine();
        // D)--------------------------------------------------------------------------------

        int Row = 0;
        int Col = 0;
        int offset = 0;
        digit = 1;
        while (digit < n*n)
        {
            //down
            for (Row = offset; Row < n-offset; Row++)
            {
                Col = offset;
                matrix[Row, Col] = digit;
                digit++;
            }
            //right
            for (Col = 1 + offset; Col < n - offset; Col++)
            {
                Row = n - 1 - offset;
                matrix[Row, Col] = digit;
                digit++;
            }
            //up
            for (Row = n - 2 - offset; Row >=offset; Row--)
            {
                Col = n - 1 - offset;
                matrix[Row, Col] = digit;
                digit++;
            }
            //left
            for (Col = n - 2 - offset; Col >=offset + 1; Col--)
            {
                Row = offset;
                matrix[Row, Col] = digit;
                digit++;
            }
            offset++;
        }

        
        for (int row = 0; row < n; row++)
        {
            for (int col = 0; col < n; col++)
            {
                Console.Write(matrix[row, col] + " ");     //Print the matrix
            }
            Console.WriteLine();
        }
    }
}
