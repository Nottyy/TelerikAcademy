using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.WordOccurencesInGivenText
{
    class WordOccurencesInGivenText
    {
        static void Main(string[] args)
        {
            string text = "This is the TEXT. Text, text, text – THIS TEXT! Is this the text?";
            Console.WriteLine("Initial text: {0}", text);
            Console.WriteLine();

            string[] allWordsInText = text.Split(new char[] { ' ', ',', '.', '–', '!', '?', ';' }, StringSplitOptions.RemoveEmptyEntries);

            var allWordsCount = new Dictionary<string, int>();

            foreach (var word in allWordsInText)
            {
                string wordToLower = word.ToLower();

                if (allWordsCount.ContainsKey(wordToLower))
                {
                    allWordsCount[wordToLower]++;
                }
                else
                {
                    allWordsCount.Add(wordToLower, 1);
                }
            }

            foreach (var wordCount in allWordsCount)
            {
                Console.WriteLine("The word: -> {0}, appears -> {1} times in the text!", wordCount.Key, wordCount.Value);
            }
        }
    }
}
