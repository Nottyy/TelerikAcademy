using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class JoroTheRabbit
{
    static void Main(string[] args)
    {

        string input = Console.ReadLine();
        string[] inputNumbers = input.Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);

        int[] numbers = new int[inputNumbers.Length];

        for (int i = 0; i < numbers.Length; i++)
        {
            numbers[i] = int.Parse(inputNumbers[i]);
        }

        //Array.Reverse(numbers);
        //bool[] visited = new bool[numbers.Length];


        int bestPath = 0;

        for (int startIndex = 0; startIndex < numbers.Length; startIndex++)
        {
            //visited[startIndex] = true;
            for (int step = 1; step < numbers.Length; step++)
            {

                int index = startIndex;
                int currentPath = 1;
                int next = (index + step);
                if (next >= numbers.Length)
                {
                    next -= numbers.Length;
                }

                while ((numbers[next] > numbers[index]))
                {
                    //visited[next] = true;
                    currentPath++;
                    index = next;
                    next = (index + step);
                    if (next >= numbers.Length)
                    {
                        next -= numbers.Length;
                    }
                }

                //Array.Clear(visited, 0, visited.Length);
                if (currentPath > bestPath)
                {
                    bestPath = currentPath;
                }
            }
        }
        Console.WriteLine(bestPath);


    }
}