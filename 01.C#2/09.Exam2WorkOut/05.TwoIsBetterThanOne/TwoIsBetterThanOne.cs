using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class TwoIsBetterThanOne
{
    static bool IsPalindrome(ulong number)
    {
        string num = number.ToString();

        for (int i = 0; i < num.Length / 2; i++)
        {
            if (num[i] != num[num.Length - i - 1])
            {
                return false;
            }
        }
        return true;
    }

    static int FindLuckyNumbers(ulong lowerBound, ulong upperBound)
    {

        ulong max = upperBound;
        int left = 0;
        var numbers = new List<ulong> { 3, 5 };

        int count = 0;
        while (left < numbers.Count)
        {
            int right = numbers.Count;

            for (int i = left; i < right; i++)
            {
                if (numbers[i] < max)
                {
                    numbers.Add((numbers[i] * 10) + 3);
                    numbers.Add((numbers[i] * 10) + 5);
                }
            }
            left = right;
        }

        foreach (var num in numbers)
        {
            if (num >= lowerBound && num <= upperBound && IsPalindrome(num))
            {
                count++;
            }
        }
        return count;
    }

    static void Main(string[] args)
    {

        string[] strings = Console.ReadLine().Split(' ');
        ulong[] pafish = new ulong[strings.Length];

        for (int i = 0; i < strings.Length; i++)
        {
            pafish[i] = ulong.Parse(strings[i]);
        }

        ulong a = pafish[0];
        ulong b = pafish[1];
        int count = FindLuckyNumbers(a, b);
        // --------------------------


        int answerSecondTask = FindAnswerSecondTask();
        //----------------------------
        Console.WriteLine(count);
        Console.WriteLine(answerSecondTask);
    }

    private static int FindAnswerSecondTask()
    {
        string[] Input = Console.ReadLine().Split(',');
        int percentile = int.Parse(Console.ReadLine());
        int[] array = new int[Input.Length];
        for (int i = 0; i < Input.Length; i++)
        {
            array[i] = int.Parse(Input[i]);
        }
        Array.Sort(array);
        return array[(percentile * Input.Length - 1) / 100];
    }
}
