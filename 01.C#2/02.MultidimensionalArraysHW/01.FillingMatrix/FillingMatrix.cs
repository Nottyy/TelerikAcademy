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

        r = 0;
        c = 0;
        int offset = 0;
        digit = 1;
        while (digit < n*n)
        {
            //right
            r = offset;

            for (c = offset; c < n - offset; c++)
            {
                matrix[r, c] = digit;
                digit++;
            }

            //down
            c = n - offset - 1;

            for (r = 1 + offset; r < n-offset; r++)
            {
                matrix[r, c] = digit;
                digit++;
            }

            //left
            r = n - 1 - offset;

            for (c = n - 2 - offset; c >= offset; c--)
            {
                matrix[r, c] = digit;
                digit++;
            }
            //up
            c = offset;

            for (r = n - 2 - offset; r >=offset + 1; r--)
            {
                matrix[r, c] = digit;
                digit++;
            }
            
            offset++;
        }

        
        for (int roww = 0; roww < n; roww++)
        {
            for (int coll = 0; coll < n; coll++)
            {
                Console.Write(matrix[roww, coll] + " ");     //Print the matrix
            }
            Console.WriteLine();
        }
    }
}
