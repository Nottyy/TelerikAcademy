using System;
using System.Collections.Generic;
using System.Linq;

using System.Text;
using System.Threading.Tasks;


class Program
{
    static void Main(string[] args)
    {
        string input = Console.ReadLine();

        string[] chars = new string[15];
        chars[0] = "Rawr";
        chars[1] = "Rrrr";
        chars[2] = "Hsst";
        chars[3] = "Ssst";
        chars[4] = "Grrr";
        chars[5] = "Rarr";
        chars[6] = "Mrrr";
        chars[7] = "Psst";
        chars[8] = "Uaah";
        chars[9] = "Uaha";
        chars[10] = "Zzzz";
        chars[11] = "Bauu";
        chars[12] = "Djav";
        chars[13] = "Myau";
        chars[14] = "Gruh";

        List<int> digits = new List<int>();
        int startPosition = 0;
        int endPosition = 0;
        string temp = string.Empty;
        int result = 0;
        for (int i = 0; i <= input.Length; i++)
        {
            temp = input.Substring(startPosition, endPosition);
            if (chars.Contains(temp))
            {
                result = Array.IndexOf(chars, temp);
                temp = string.Empty;
                startPosition = i;
                endPosition = 0;
                digits.Add(result);
            }
            endPosition++;
        }
        ulong degree = 1;
        ulong resultAfter = 0;
        for (int i = 0; i < digits.Count; i++)
        {
            ulong decimalValue = (ulong)digits[digits.Count - i - 1];
            if (i == 0)
            {
                resultAfter = decimalValue;
            }
            else
            {
                degree *= 15;
                resultAfter += decimalValue * degree;
            }
        }
        Console.WriteLine(resultAfter);
    }
}
