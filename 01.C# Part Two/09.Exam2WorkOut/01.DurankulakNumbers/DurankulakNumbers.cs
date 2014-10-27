using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class DurankulakNumbers
{
    static void Main()
    {
        string[] durankulakDigits = DurankulakDigits();
        string input = Console.ReadLine();

        string durankulakDigit = string.Empty;
        string buffer = string.Empty;
        ulong decimalRepresentation = 0;

        List<
            ulong> decimals = new List<ulong>();

        for (int i = 0; i < input.Length; i++)
        {
            if (input[i] >= 'A' && input[i] <= 'Z')
            {
                durankulakDigit += buffer + input[i].ToString();
                decimalRepresentation = (ulong)Array.IndexOf(durankulakDigits, durankulakDigit);
                durankulakDigit = string.Empty;
                buffer = string.Empty;
                decimals.Add(decimalRepresentation);
            }
            else
            {
                buffer = input[i].ToString();
            }
        }
        ulong result = 0;
        for (int i = 0; i < decimals.Count; i++)
        {
            result += decimals[decimals.Count - i - 1] * (ulong)Math.Pow(168, i);
        }
        Console.WriteLine(result);

    }

    private static string[] DurankulakDigits()
    {
        string[] durankulakDigits = new string[168];

        for (int i = 0; i < 168; i++)
        {
            if (i < 26)
            {
                durankulakDigits[i] = (((char)('A' + i)).ToString());
            }
            else if (i < 2 * 26)
            {
                durankulakDigits[i] = 'a' + durankulakDigits[i - 26];
            }
            else if (i < 3 * 26)
            {
                durankulakDigits[i] = 'b' + durankulakDigits[i - 2 * 26];
            }
            else if (i < 4 * 26)
            {
                durankulakDigits[i] = 'c' + durankulakDigits[i - 3 * 26];
            }
            else if (i < 5 * 26)
            {
                durankulakDigits[i] = 'd' + durankulakDigits[i - 4 * 26];
            }
            else if (i < 6 * 26)
            {
                durankulakDigits[i] = 'e' + durankulakDigits[i - 5 * 26];
            }
            else if (i < 7 * 26)
            {
                durankulakDigits[i] = 'f' + durankulakDigits[i - 6 * 26];
            }
        }
        return durankulakDigits;
    }
}
