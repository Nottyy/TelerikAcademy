//Write a program that finds how many times a substring is contained in a given text (perform case insensitive search).


using System;
using System.Text.RegularExpressions;

class CaseInsensitiveWordCount
{
    static void Main()
    {
        string text = "We are living in an yellow submarine.We don't have anything else. Inside the submarine is very tight. So we are drinking all the day. We will move out of it in 5 days.";
        string regex = "in";

        Console.WriteLine(Regex.Matches(text, regex, RegexOptions.IgnoreCase).Count);
    }
}

