using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class MultiCommunication
{
    static void Main(string[] args)
    {
        string input = Console.ReadLine();

        var words = new List<string>() { "CHU", "TEL", "OFT", "IVA", "EMY", "VNB", "POQ", "ERI", "CAD", "K-A", "IIA", "YLO", "PLA" };

        //var result = new StringBuilder();
        long decimalRepresentation = 0;

        for (int i = 0; i < input.Length; i += 3)
        {
            var digitIn13 = input.Substring(i, 3);
            for (int j = 0; j < words.Count; j++)
            {
                if (words[j] == digitIn13)
                {
                    int decimalValue = j;
                    decimalRepresentation *= 13;
                    decimalRepresentation += decimalValue;
                }
            }

        }
        Console.WriteLine(decimalRepresentation);

    }
}
