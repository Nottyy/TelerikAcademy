using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class ThreeInOne
{
    static void Main(string[] args)
    {
        Problem1();
        Problem2();
        Problem3();
    }

    static void Problem1()
    {
        int[] scores = Console.ReadLine().Split(',').Select(s => int.Parse(s)).ToArray();

        int? winner = null;

        for (int i = 0; i < scores.Length; i++)
        {
            int currentScore = scores[i];
            if (currentScore <= 21)
            {
                if (winner == null || currentScore > scores[winner.Value])
                {
                    winner = i;
                }
            }
        }

        if (winner == null)
        {
            Console.WriteLine(-1);
        }
        else
        {
            for (int i = 0; i < scores.Length; i++)
            {
                if (scores[i] == scores[winner.Value] && i != winner.Value)
                {
                    Console.WriteLine(-1);
                    return;
                }
            }
            Console.WriteLine(winner.Value);
        }
    }
    static void Problem2()
    {
        int[] sizes = Console.ReadLine().Split(',').Select(s => int.Parse(s)).ToArray();

        int friends = int.Parse(Console.ReadLine());
        // 6,7,9,6,4 15

        Array.Sort(sizes);
        Array.Reverse(sizes);

        int eatenCakes = 0;
        for (int i = 0; i < sizes.Length; i += (friends + 1))
        {
            eatenCakes += sizes[i];
        }
        Console.WriteLine(eatenCakes);
    }

    static void Problem3()
    {
        var number = Console.ReadLine().Split(' ').Select(s => int.Parse(s));

        int[] current = number.Take(3).ToArray();
        int[] target = number.Skip(3).Take(3).ToArray();

        const int GOLD = 0;
        const int SILVER = 1;
        const int BRONZE = 2;
        //1 0 0    1 100 12 
        //0 0 81   5 53  33
        int operations = 0;
        while (true)
        {
            if (current[GOLD] >= target[GOLD] && current[SILVER] >= target[SILVER] && current[BRONZE] >= target[BRONZE])
            {
                Console.WriteLine(operations);
                return;
            }

            while (current[SILVER] > target[SILVER])
            {
                if (current[GOLD] < target[GOLD])
                {
                    if (current[SILVER] - target[SILVER] >= 11)
                    {
                        current[SILVER] -= 11;
                        current[GOLD] += 1;
                        operations += 1;
                    }
                    else if (current[BRONZE] - target[BRONZE] >= 11)
                    {
                        current[BRONZE] -= 11;
                        current[SILVER] += 1;
                        operations += 1;
                    }
                    else
                    {
                        Console.WriteLine(-1);
                        return;
                    }
                }
                //1 0 0    1 100 12 
                //0 0 81   5 53  33
                else if (current[BRONZE] < target[BRONZE])
                {
                    current[SILVER] -= 1;
                    current[BRONZE] += 9;
                    operations += 1;
                }
                else
                {
                    Console.WriteLine(operations);
                    return;
                }
            }
            while (current[SILVER] < target[SILVER])
            {
                if (current[GOLD] > target[GOLD])
                {
                    current[GOLD] -= 1;
                    current[SILVER] += 9;
                    operations += 1;
                }
                else if (current[BRONZE] - target[BRONZE] >= 11)
                {
                    current[SILVER] += 1;
                    current[BRONZE] -= 11;
                    operations += 1;
                }
                else
                {
                    Console.WriteLine(-1);
                    return;
                }
            }

            if (current[GOLD] < target[GOLD])
            {
                if (current[BRONZE] - target[BRONZE] >= 11)
                {
                    current[SILVER] += 1;
                    current[BRONZE] -= 11;
                    operations += 1;
                }
                else
                {
                    Console.WriteLine(-1);
                    return;
                }
            }

            if (current[BRONZE] < target[BRONZE])
            {
                if (current[GOLD] > target[GOLD])
                {
                    current[GOLD] -= 1;
                    current[SILVER] += 9;
                    operations += 1;
                }
                else
                {
                    Console.WriteLine(-1);
                    return;
                }
            }
        }
    }
}
