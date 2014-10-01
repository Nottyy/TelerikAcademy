using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14.LabyrinthEscape
{
    class LabyrinthEscape
    {
        static int[,] directions =
        {
            {0, 1},
            {1, 0},
            {0, -1},
            {-1, 0},
        };

        static string[,] labyrinth =  
            {
                { "_", "_", "_", "x", "_", "x" },
                { "_", "x", "_", "x", "_", "x" },
                { "_", "X", "x", "_", "x", "_" },
                { "_", "x", "_", "_", "_", "_" },
                { "_", "_", "_", "x", "x", "_" },
                { "_", "_", "_", "x", "_", "x" },
            };

        static void Main(string[] args)
        {
            Queue<Cell> queue = new Queue<Cell>();
            Cell startingCell = new Cell(0, 2, 1);
            queue.Enqueue(startingCell);

            while (queue.Count > 0)
            {
                Cell currentCell = queue.Dequeue();

                for (int i = 0; i < directions.GetLength(0); i++)
                {
                    var nextDirectionRow = directions[i, 0];
                    var nextDirectionCol = directions[i, 1];

                    var nextCellRow = nextDirectionRow + currentCell.Row;
                    var nextCellCol = nextDirectionCol + currentCell.Col;

                    if (!IsInRange(nextCellRow, nextCellCol))
                    {
                        continue;
                    }

                    if (labyrinth[nextCellRow, nextCellCol] == "x")
                    {
                        continue;
                    }

                    if (char.IsDigit(labyrinth[nextCellRow, nextCellCol].ToCharArray()[0]))
                    {
                        continue;
                    }
                    
                    Cell nextCell = new Cell(currentCell.Value + 1, nextDirectionRow + currentCell.Row, nextDirectionCol + currentCell.Col);
                    labyrinth[nextCellRow, nextCellCol] = (currentCell.Value + 1).ToString();
                    queue.Enqueue(nextCell);
                }
            }
            MarkUnpassable();
            PrintLabyrinth();
        }

        private static void MarkUnpassable()
        {
            for (int i = 0; i < labyrinth.GetLength(0); i++)
            {
                for (int j = 0; j < labyrinth.GetLength(1); j++)
                {
                    if (labyrinth[i, j] == "_")
                    {
                        labyrinth[i, j] = "u";
                    }
                }
            }
        }

        private static void PrintLabyrinth()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < labyrinth.GetLength(0); i++)
            {
                for (int j = 0; j < labyrinth.GetLength(1); j++)
                {
                    sb.AppendFormat("{0, -3}", labyrinth[i, j]);
                }
                sb.AppendLine();
            }
            Console.WriteLine(sb.ToString());
        }

        private static bool IsInRange(int row, int col)
        {
            bool isInRange = true;

            if (row < 0 || col < 0 || row >= labyrinth.GetLength(0) || col >= labyrinth.GetLength(1))
            {
                return false;
            }

            return isInRange;
        }
    }
}
