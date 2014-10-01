using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class BombingCuboids
{
    static int[] lettersHit = new int[91];

    static int totalHit = 0;

    const char empty = ' ';
    static void Main()
    {
        string[] dimensionStrings = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        int width = int.Parse(dimensionStrings[0]);
        int height = int.Parse(dimensionStrings[1]);
        int depth = int.Parse(dimensionStrings[2]);

        char[, ,] cube = InputCube(width, height, depth);

        int bombsCount = int.Parse(Console.ReadLine());
        for (int i = 0; i < bombsCount; i++)
        {
            string[] bombValues = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            int bombWidth = int.Parse(bombValues[0]);
            int bombHeight = int.Parse(bombValues[1]);
            int bombDepth = int.Parse(bombValues[2]);
            int power = int.Parse(bombValues[3]);

            DetonateBomb(cube, bombWidth, bombHeight, bombDepth, power);
            FallDown(cube);
        }

        PrintResult();
 
    }

    private static void PrintResult()
    {
        Console.WriteLine(totalHit);

        for (int i = 0; i < lettersHit.Length; i++)
        {
            if (lettersHit[i] != 0)
            {
                Console.WriteLine("{0} {1}", (char)i, lettersHit[i]);
            }
        }
    }

    private static void FallDown(char[, ,] cube)
    {
        int width = cube.GetLength(0);
        int height = cube.GetLength(1);
        int depth = cube.GetLength(2);

        for (int pillarWidth = 0; pillarWidth < width; pillarWidth++)
        {
            for (int pillarDepth = 0; pillarDepth < depth; pillarDepth++)
            {

                FallDownPillar(cube, pillarWidth, pillarDepth);
            }
        }
    }

    private static void FallDownPillar(char[, ,] cube, int pillarWidth, int pillarDepth)
    {
        int pillarHeight = cube.GetLength(1);
        int bottom = 0;

        for (int currHeight = 0; currHeight < pillarHeight; currHeight++)
        {
            if (cube[pillarWidth, currHeight, pillarDepth] != empty)
            {
                if (currHeight != bottom)
                {
                    cube[pillarWidth, bottom, pillarDepth] = cube[pillarWidth, currHeight, pillarDepth];
                    cube[pillarWidth, currHeight, pillarDepth] = empty;
                }
                bottom++;
            }
        }
    }

    private static void DetonateBomb(char[, ,] cube, int bombWidth, int bombHeight, int bombDepth, int power)
    {
        for (int currWidth = 0; currWidth < cube.GetLength(0); currWidth++)
        {
            for (int currHeight = 0; currHeight < cube.GetLength(1); currHeight++)
            {
                for (int currDepth = 0; currDepth < cube.GetLength(2); currDepth++)
                {
                    if (cube[currWidth, currHeight, currDepth] != empty)
                    {
                        int distSquarred = GetDistSquarred(currWidth, currHeight, currDepth, bombWidth, bombHeight, bombDepth);
                        int pSquarred = power * power;

                        if (distSquarred <= pSquarred)
                        {
                            char currLetter = cube[currWidth, currHeight, currDepth];
                            lettersHit[(int)currLetter]++;
                            totalHit++;
                            //isHit
                            cube[currWidth, currHeight, currDepth] = empty;
                        }
                    }
                }
            }
        }
    }

    private static int GetDistSquarred(int currWidth, int currHeight, int currDepth, int bombWidth, int bombHeight, int bombDepth)
    {
        int deltaWidth = currWidth - bombWidth,
            deltaHeight = currHeight - bombHeight,
            deltaDepth = currDepth - bombDepth;

        return deltaWidth * deltaWidth + deltaHeight * deltaHeight + deltaDepth * deltaDepth;
    }

    private static char[, ,] InputCube(int width, int height, int depth)
    {
        char[, ,] cube = new char[width, height, depth];

        for (int h = 0; h < height; h++)
        {
            string[] plateRows = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            for (int d = 0; d < depth; d++)
            {
                string currPlateRow = plateRows[d];

                for (int w = 0; w < width; w++)
                {
                    cube[w, h, d] = currPlateRow[w];
                }
            }
        }

        return cube;
    }

    private static void PrintCube(int width, int height, int depth, char[, ,] cube)
    {
        for (int h = 0; h < height; h++)
        {
            string[] plateRows = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            for (int d = 0; d < depth; d++)
            {
                string currPlateRow = plateRows[d];

                for (int w = 0; w < width; w++)
                {
                    cube[w, h, d] = currPlateRow[w];
                }
            }
        }
    }
}

