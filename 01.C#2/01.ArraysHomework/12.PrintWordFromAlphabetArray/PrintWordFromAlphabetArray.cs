//Write a program that creates an array containing all letters from the alphabet (A-Z). Read a word from the console and print the index of each of its letters in the array.

using System;

class PrintWordFromAlphabetArray
{
    static void Main()
    {
        char[] arr = new char[26];
        string word = (Console.ReadLine().ToLower());

        for (int i = 0; i < 26; i++)
        {
            arr[i] = Convert.ToChar('a' + i);
        }

        for (int i = 0; i < word.Length; i++)
        {
            Console.WriteLine("{0} [{1}]", word[i], (int) word[i] - 'a');
        }
    }
}

