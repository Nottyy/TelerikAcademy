//A dictionary is stored as a sequence of text lines containing words and their explanations. Write a program that enters a word and translates it by using the dictionary. 

using System;
using System.Text.RegularExpressions;

class Dictionary
{
    static void Main()
    {

        string dictionary = @".NET – platform for applications from Microsoft
                                CLR – managed execution environment for .NET
                                namespace – hierarchical organization of classes
                            ";

        string searchWord = "clr";
        string regex = searchWord + @"(\s+?)\-(\s+?)(?<definition>((.|\s)*?))";

        MatchCollection matches = Regex.Matches(dictionary, regex, RegexOptions.IgnoreCase | RegexOptions.IgnorePatternWhitespace);
        if (matches.Count > 0)
        {
            foreach (Match match in matches)
            {
                Console.WriteLine(match.Groups["definition"]);
            }
        }
        else
        {
            Console.WriteLine("This word does not exist in the dictionary!");
        }
    }
}
