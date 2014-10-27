using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Lines3D
{
    private static char[, ,] cube;
    private static int width, height, depth;
    private static int[] dirsWidth = { 1, 0, 1, -1, 0, 0, 0, 1, -1, 1, 1, 1, 1 };
    private static int[] dirsHeight = { 0, 1, 0, 0, 0, 1, 1, 1, 1, 1, -1, 1, -1 };
    private static int[] dirsDepth = { 0, 0, 1, 1, 1, 1, -1, 0, 0, 1, 1, -1, -1 };
    private static int BestLineLength = 0;
    private static int BestNuberOfLines = 0;

    static void Main()
    {
        string[] rawNumbers = Console.ReadLine().Split();
        width = int.Parse(rawNumbers[0]);
        height = int.Parse(rawNumbers[1]);
        depth = int.Parse(rawNumbers[2]);
        cube = new char[width, height, depth];

        for (int h = 0; h < height; h++)
        {
            string[] lineFragment = Console.ReadLine().Split();
            for (int d = 0; d < depth; d++)
            {
                string depthFragment = lineFragment[d];
                for (int w = 0; w < width; w++)
                {
                    cube[w, h, d] = depthFragment[w];
                }
            }
        }

        for (int w = 0; w < width; w++)
        {
            for (int h = 0; h < height; h++)
            {
                for (int d = 0; d < depth; d++)
                {
                    ProcessDirs(w, h, d);
                }
            }
        }

        Console.WriteLine("{0} {1}", BestLineLength , BestNuberOfLines);
    }

    private static void ProcessDirs(int w, int h, int d)
    {
        char currCell = cube[w, h, d];
        for (int i = 0; i < dirsDepth.Length; i++)
        {
            int currentLineLength = 1;
            int currWidth = w;
            int currHeight = h;
            int currDepth = d;

            while (true)
            {
                currWidth += dirsWidth[i];
                currHeight += dirsHeight[i];
                currDepth += dirsDepth[i];
                if (!IsInCube(currWidth,currHeight,currDepth))
                {
                    break;
                }

                if (cube[currWidth,currHeight,currDepth] == currCell)
                {
                    currentLineLength++;
                }
                else
                {
                    break;
                }

                if (currentLineLength >= BestLineLength)
                {
                    BestLineLength = currentLineLength;
                    BestNuberOfLines++;
                }
                else
                {
                    currentLineLength = 0;
                }
            }
        }
    }

    private static bool IsInCube(int w, int h, int d)
    {
        if (w >= 0 && h >= 0 && d >= 0 && w < width && h < height && d < depth)
        {
            return true;
        }
        else
        {
            return false;   
        }
    }
}

