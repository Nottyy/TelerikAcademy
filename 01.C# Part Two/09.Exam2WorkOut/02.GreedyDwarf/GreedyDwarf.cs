using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class GreedyDwarf
{
    private static long ProcessPattern(int[] vally)
    {
        string[] rawNumbers = Console.ReadLine().Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
        int[] pattern = new int[rawNumbers.Length];

        for (int i = 0; i < pattern.Length; i++)
        {
            pattern[i] = int.Parse(rawNumbers[i]);
        }

        bool[] visited = new bool[vally.Length];
        long coinSum = 0;
        coinSum += vally[0];
        visited[0] = true;
        int startPosition = 0;

        while (true)
        {
            for (int i = 0; i < pattern.Length; i++)
            {
                int nextMove = startPosition + pattern[i];
                if (nextMove >= 0 && nextMove < vally.Length && !visited[nextMove])
                {
                    coinSum += vally[nextMove];
                    visited[nextMove] = true;
                    startPosition = nextMove;
                }
                else
                {
                    return coinSum;
                }
            }
        }

        return 0;
    }
    static void Main()
    {
        string[] rawNumbers = Console.ReadLine().Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);

        int[] valleyNumbers = new int[rawNumbers.Length];

        for (int i = 0; i < valleyNumbers.Length; i++)
        {
            valleyNumbers[i] = int.Parse(rawNumbers[i]);
        }

        int numberOfPatterns = int.Parse(Console.ReadLine());

        long coinSum = 0;
        long bestCoinSum = long.MinValue;

        for (int i = 0; i < numberOfPatterns; i++)
        {
            coinSum = ProcessPattern(valleyNumbers);
            if (coinSum > bestCoinSum)
            {
                bestCoinSum = coinSum;
            }
        }
        Console.WriteLine(bestCoinSum);

    }
}
