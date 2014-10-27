using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Crossword08Feb2012
{
    class Program
    {
        static string[] words;
        static HashSet<string> allWords = new HashSet<string>();
        static string[] crosswords;

        static void Main()
        {
            int N = int.Parse(Console.ReadLine());
            words = new string[2 * N];
            crosswords = new string[N];

            for (int i = 0; i < 2 * N; i++)
            {
                string currentWord = Console.ReadLine();
                words[i] = currentWord;
                allWords.Add(currentWord);
            }

            Array.Sort(words);

            Solver(0);

            Console.WriteLine("NO SOLUTION!");
        }

        private static bool Checker()
        {
            var sb = new StringBuilder();

            for (int i = 0; i < crosswords.Length; i++)
            {
                sb.Clear();

                for (int j = 0; j < crosswords.Length; j++)
                {
                    sb.Append(crosswords[j][i]);
                }

                if (!allWords.Contains(sb.ToString()))
                {
                    return false;
                }
            }

            return true;
        }

        private static void Solver(int index)
        {
            if (index == crosswords.Length) 
            {
                if (Checker())
                {
                    Printer();
                    
                }

                return;
            }

            for (int i = 0; i < words.Length; i++)
            {
                crosswords[index] = words[i];
                Solver(index + 1);
                crosswords[index] = string.Empty;
            }
        }

        private static void Printer()
        {
            Console.WriteLine();
            for (int i = 0; i < crosswords.Length; i++)
            {
                Console.WriteLine(crosswords[i]);
            }
        }
    }
}
