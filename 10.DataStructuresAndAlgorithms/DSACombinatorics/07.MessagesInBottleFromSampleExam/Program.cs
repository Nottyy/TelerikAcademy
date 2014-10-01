using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.MessagesInBottleFromSampleExam
{
    class Program
    {
        static StringBuilder output = new StringBuilder();
        static int counter = 0;
        static string message = Console.ReadLine();
        static List<KeyValuePair<char, string>> ciphers = new List<KeyValuePair<char, string>>();
        static string cipher = Console.ReadLine();
        static SortedSet<string> sortedWords = new SortedSet<string>();

        static void Main()
        {
            var key = char.MinValue;
            for (int i = 0; i < cipher.Length; i++)
            {
                if (cipher[i] >= 'A' && cipher[i] <= 'Z')
                {
                    if (key != char.MinValue)
                    {
                        ciphers.Add(new KeyValuePair<char, string>(key, output.ToString()));
                        output.Clear();
                    }
                    
                    key = cipher[i];
                }
                else
                {
                    output.Append(cipher[i]);
                }
            }
            if (key != char.MinValue)
            {
                ciphers.Add(new KeyValuePair<char, string>(key, output.ToString()));
                output.Clear();
            }

            Solve(0, new StringBuilder());

            Console.WriteLine(counter);
            for (int i = 0; i < sortedWords.Count; i++)
            {
                Console.WriteLine(sortedWords.ElementAt(i));
            }
        }

        private static void Solve(int index, StringBuilder sb)
        {
            if (index == message.Length)
            {
                sortedWords.Add(sb.ToString());
                counter++;
                return;
            }


            foreach (var cip in ciphers)
            {
                if (message.Substring(index).StartsWith(cip.Value))
                {
                    sb.Append(cip.Key);
                    Solve(index + cip.Value.Length, sb);
                    sb.Length--;
                }
            }
        }
    }
}
