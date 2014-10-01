using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.Guitar
{
    public class Guitar
    {
        public static void Main()
        {
            int CNumberOfSongs = int.Parse(Console.ReadLine());
            string[] volumesString = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            int[] volumesInt = new int[volumesString.Length];

            for (int i = 0; i < volumesString.Length; i++)
            {
                volumesInt[i] = int.Parse(volumesString[i]);
            }

            int BStart = int.Parse(Console.ReadLine());
            int MMax = int.Parse(Console.ReadLine());

            int[,] matrix = new int[CNumberOfSongs + 1, MMax + 1];
            matrix[0, BStart] = 1;

            for (int i = 1; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i - 1,j] == 1)
                    {
                        int possiblePosition = j - volumesInt[i - 1];
                        if (possiblePosition >= 0)
                        {
                            matrix[i, possiblePosition] = 1;
                        }

                        possiblePosition = j + volumesInt[i - 1];
                        if (possiblePosition <= MMax)
                        {
                            matrix[i, possiblePosition] = 1;
                        }
                    }
                }
            }

            for (int i = MMax; i >= 0; i--)
            {
                if (matrix[CNumberOfSongs, i] == 1)
                {
                    Console.WriteLine(i);
                    return;
                }
            }

            Console.WriteLine(-1);
        }
    }
}
