using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;


class GagNumbers9
{
    static void Main()
    {
        string input = Console.ReadLine();

        string[] chars = new string[9];
        chars[0] = "-!";
        chars[1] = "**";
        chars[2] = "!!!";
        chars[3] = "&&";
        chars[4] = "&-";
        chars[5] = "!-";
        chars[6] = "*!!!";
        chars[7] = "&*!";
        chars[8] = "!!**!-";

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
        BigInteger degree = 1;
        BigInteger resultAfter = 0;
        for (int i = 0; i < digits.Count; i++)
        {
            BigInteger decimalValue = digits[digits.Count - i - 1];
            if (i == 0)
            {
                resultAfter = decimalValue;
            }
            else
            {
                degree *= 9;
                resultAfter += decimalValue * degree;
            }
        }
        Console.WriteLine(resultAfter);
    }
}
