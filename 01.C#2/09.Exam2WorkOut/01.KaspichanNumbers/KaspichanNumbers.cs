using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class KaspichanNumbers
{
    static void Main(string[] args)
    {
        string[] kaspichanNumbers = KaspichanNumbers();

        //for (int i = 0; i < kaspichanNumbers.Length; i++)
        //{
        //    Console.WriteLine("{0}  {1}",i ,kaspichanNumbers[i]);
        //}

        ulong input = ulong.Parse(Console.ReadLine());

        string result = string.Empty;
        if (input == 0)
        {
            Console.WriteLine("A");
        }
        while (input != 0)
        {
            result = kaspichanNumbers[input % 256] + result;
            input /= 256;
        }
        Console.WriteLine(result);



        //int decimalRepresentation = 0;
        //string buffer = string.Empty;
        ////BBA
        //string kaspichanDigit = string.Empty;
        //var decimals = new List<int>();

        //for (int i = 0; i < input.Length; i++)
        //{
        //    if (input[i] >= 'A' && input[i] <= 'Z')
        //    {

        //        kaspichanDigit += buffer + input[i].ToString();
        //        decimalRepresentation = Array.IndexOf(kaspichanNumbers, kaspichanDigit);
        //        buffer = string.Empty;
        //        kaspichanDigit = string.Empty;
        //        decimals.Add(decimalRepresentation);
        //    }
        //    else
        //    {
        //        buffer = input[i].ToString();
        //    }
        //}

        //long finalResult = 0;
        //for (int i = 0; i < decimals.Count; i++)
        //{
        //    finalResult += (long)(decimals[decimals.Count - i - 1] * Math.Pow(256, i));
        //}
        //Console.WriteLine(finalResult);
    }

    private static string[] KaspichanNumbers()
    {
        string[] kaspichanNumbers = new string[256];

        for (int i = 0; i < kaspichanNumbers.Length; i++)
        {
            if (i < 26)
            {
                kaspichanNumbers[i] = ((char)('A' + i)).ToString();
            }
            else if (i < 2 * 26)
            {
                kaspichanNumbers[i] = 'a' + kaspichanNumbers[i - 26];
            }
            else if (i < 3 * 26)
            {
                kaspichanNumbers[i] = 'b' + kaspichanNumbers[i - 2 * 26];
            }
            else if (i < 4 * 26)
            {
                kaspichanNumbers[i] = 'c' + kaspichanNumbers[i - 3 * 26];
            }
            else if (i < 5 * 26)
            {
                kaspichanNumbers[i] = 'd' + kaspichanNumbers[i - 4 * 26];
            }
            else if (i < 6 * 26)
            {
                kaspichanNumbers[i] = 'e' + kaspichanNumbers[i - 5 * 26];
            }
            else if (i < 7 * 26)
            {
                kaspichanNumbers[i] = 'f' + kaspichanNumbers[i - 6 * 26];
            }
            else if (i < 8 * 26)
            {
                kaspichanNumbers[i] = 'g' + kaspichanNumbers[i - 7 * 26];
            }
            else if (i < 9 * 26)
            {
                kaspichanNumbers[i] = 'h' + kaspichanNumbers[i - 8 * 26];
            }
            else if (i < 10 * 26)
            {
                kaspichanNumbers[i] = 'i' + kaspichanNumbers[i - 9 * 26];
            }
        }

        return kaspichanNumbers;
    }
}
