using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.WordsNovember2012
{
    class Words
    {
        static Dictionary<char, HashSet<string>> wordsByCharDict = new Dictionary<char, HashSet<string>>();

        static void InitDict()
        {
            for (char i = 'a'; i <= 'z'; i++)
            {
                wordsByCharDict[i] = new HashSet<string>();
            }
        }

        static void AddWord(string word)
        {
            for (int i = 0; i < word.Length; i++)
            {
                wordsByCharDict[word[i]].Add(word);
            }
        }

        static void ReadWords()
        {
            int N = int.Parse(Console.ReadLine());

            for (int i = 0; i < N; i++)
            {
                string inputLine = Console.ReadLine().ToLower();
                var word = new StringBuilder();

                for (int j = 0; j < inputLine.Length; j++)
                {
                    if (inputLine[j] >= 'a' && inputLine[j] <= 'z')
                    {
                        word.Append(inputLine[j]);
                    }
                    else if (inputLine[j] >= 'A' && inputLine[j] <= 'Z')
                    {
                        word.Append((char)inputLine[j] - 'A' + 'a');
                    }
                    else if (word.Length > 0)
                    {
                        AddWord(word.ToString());
                        word.Clear();
                    }
                }

                if (word.Length > 0)
                {
                    AddWord(word.ToString());
                    word.Clear();
                }
            }
        }

        static void ProcessWords()
        {
            int N = int.Parse(Console.ReadLine());

            for (int i = 0; i < N; i++)
            {
                string word = Console.ReadLine();
                string wordToLower = word.ToLower();
                HashSet<string> current = new HashSet<string>(wordsByCharDict[wordToLower[0]]);

                for (int j = 0; j < wordToLower.Length; j++)
                {
                    current.IntersectWith(wordsByCharDict[wordToLower[j]]);
                }

                Console.WriteLine(word + " -> " + current.Count);
            }

        }

        static void Main(string[] args)
        {
            InitDict();
            ReadWords();
            ProcessWords();
        }
    }
}
