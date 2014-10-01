//Write a program that extracts from given HTML file its title (if available), and its body text without the HTML tags. 

using System;
using System.IO;
using System.Text.RegularExpressions;
class ExtractText
{
    static void Main()
    {
        StreamReader reader = new StreamReader(@"..\..\..\text.html");
        using (reader)
        {
            string line = string.Empty;
            MatchCollection matchProtocolAndSiteName = Regex.Matches(line, @"(?<=^|>)[^><]+?(?=<|$)");
            while ((line = reader.ReadLine()) != null)
            {
                matchProtocolAndSiteName = Regex.Matches(line, @"(?<=^|>)[^><]+?(?=<|$)");

                foreach (var word in matchProtocolAndSiteName)
                    Console.WriteLine(word);
            }
        }
    }
}