using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EightNinthAndTenthTasksGenericMatrix
{
    public class Matrix<T> where T :
           struct, IComparable, IFormattable, IConvertible, IComparable<T>, IEquatable<T>
    {

        private const int DefaultSize = 8;
        public int Row { get; private set; }
        public int Col { get; private set; }
        private T[,] matrix;

        public Matrix()
        {
            matrix = new T[DefaultSize, DefaultSize];
        }

        public Matrix(int row, int col)
        {
            if (row < 0 || col < 0) throw new ArgumentOutOfRangeException("Negative row or col value");
            else
            {
                Row = row;
                Col = col;
                matrix = new T[row, col];
            }
        }

        public Matrix(T[,] matrix)
        {
            this.matrix = matrix;
            Row = matrix.GetLength(0);
            Col = matrix.GetLength(1);
        }

        public T this[int row, int col]
        {
            get
            {
                if (Row < row || Col < col || row < 0 || col < 0) throw new ArgumentOutOfRangeException("Index out of range for Row or Col");
                else return matrix[row, col];
            }
            set
            {
                if (Row < row || Col < col || row < 0 || col < 0) throw new ArgumentOutOfRangeException("Index out of range for Row or Col");
                else matrix[row, col] = value;
            }
        }

        public static Matrix<T> operator +(Matrix<T> first, Matrix<T> second)
        {
            if (first.Row == second.Row && first.Col == second.Col)
            {
                Matrix<T> tempArr = new Matrix<T>(first.Row, first.Col);
                for (int i = 0; i < first.Row; i++)
                {
                    for (int j = 0; j < first.Col; j++)
                    {
                        checked
                        {
                            tempArr[i, j] = (dynamic)first[i, j] + second[i, j];
                        }
                    }
                }
                return tempArr;
            }
            else throw new MatrixException("The given matrix are not with the same Col and Row size");
        }

        public static Matrix<T> operator -(Matrix<T> first, Matrix<T> second)
        {
            if (first.Row == second.Row && first.Col == second.Col)
            {
                Matrix<T> tempArr = new Matrix<T>(first.Row, first.Col);
                for (int i = 0; i < first.Row; i++)
                {
                    for (int j = 0; j < first.Col; j++)
                    {
                        checked
                        {
                            tempArr[i, j] = (dynamic)first[i, j] - second[i, j];
                        }
                    }
                }
                return tempArr;
            }
            else throw new MatrixException("The given matrix are not with the same Col and Row size");
        }

        public static Matrix<T> operator *(Matrix<T> first, Matrix<T> second)
        {
            if (first.Col == second.Row && (first.Row > 0 && second.Col > 0 && first.Col > 0))
            {
                Matrix<T> tempArr = new Matrix<T>(first.Row, second.Col);
                for (int i = 0; i < first.Row; i++)
                {
                    for (int j = 0; j < first.Col; j++)
                    {
                        checked
                        {
                            tempArr[i, j] = (dynamic)first[i, j] * second[i, j];
                        }
                    }
                }
                return tempArr;
            }
            else
            {
                throw new MatrixException("Row on the first matrix and col on the second matrix, are with different size, multiplication cannot be done.");
            }
        }
        public static Boolean operator true(Matrix<T> matrix)
        {
            int zeroChecker = 0;
            for (int i = 0; i < matrix.Row; i++)
            {
                for (int j = 0; j < matrix.Col; j++)
                {
                    if ((dynamic)matrix[i, j] == zeroChecker)
                    {
                        return false;
                        break;
                    }
                }
            }
            return true;
        }

        public static Boolean operator false(Matrix<T> matrix)
        {
            int zeroChecker = 0;
            for (int i = 0; i < matrix.Row; i++)
            {
                for (int j = 0; j < matrix.Col; j++)
                {
                    if ((dynamic)matrix[i, j] == zeroChecker)
                    {
                        return false;
                        break;
                    }
                }
            }
            return true;
        }
        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < Row; i++)
            {
                for (int j = 0; j < Col; j++)
                {
                    builder.Append(matrix[i, j] + " ");
                }
                builder.AppendLine();
            }
            return builder.ToString();
        }
    }
}
