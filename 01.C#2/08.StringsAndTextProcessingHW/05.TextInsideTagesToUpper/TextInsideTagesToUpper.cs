//You are given a text. Write a program that changes the text in all regions surrounded by the tags <upcase> and </upcase> to uppercase. The tags cannot be nested. 

using System;
using System.Text.RegularExpressions;

class TextInsideTagesToUpper
{
    static void Main()
    {
        string text = "We are living in a <upcase>yelloW submarine</upcase>. We don't have <upcase>anything</upcase> else.";

        string regex = @"<upcase>(?<capitalise>(.|\s)*?)</upcase>";
        Console.WriteLine(Regex.Replace(text,regex, m => m.Groups["capitalise"].Value.ToUpper()));
    }
}

