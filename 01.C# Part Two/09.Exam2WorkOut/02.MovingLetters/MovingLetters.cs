using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class MovingLetters
{
    static void Main()
    {

        string[] input = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        StringBuilder inputSequence = InputSequence(input);

        string finalResult = MovingLetters(inputSequence);


        Console.WriteLine(finalResult);
    }

    private static string MovingLetters(StringBuilder inputSequence)
    {
        int transition = 0;
        for (int i = 0; i < inputSequence.Length; i++)
        {
            char symbol = inputSequence[i];
            transition = (char.ToLower(symbol) - 'a' + 1);
            int position = (transition + i) % (inputSequence.Length);

            inputSequence.Remove(i, 1);
            inputSequence.Insert(position, symbol);
        }

        return inputSequence.ToString();
    }

    private static StringBuilder InputSequence(string[] words)
    {
        var countChars = new StringBuilder();
        //var firstChar = string.Empty;

        int maxLength = 0;
        for (int i = 0; i < words.Length; i++)
        {
            if (words[i].Length > maxLength)
            {
                maxLength = words[i].Length;
            }
        }

        for (int i = 0; i < maxLength; i++)
        {
            for (int j = 0; j < words.Length; j++)
            {
                string currentWord = words[j];
                if (currentWord.Length > i)
                {
                    int lastLetter = currentWord.Length - i - 1;
                    //firstChar = currentWord.Substring(currentWord.Length - i - 1, 1);
                    countChars.Append(currentWord[lastLetter]);
                }
            }
        }

        return countChars;
    }
}
