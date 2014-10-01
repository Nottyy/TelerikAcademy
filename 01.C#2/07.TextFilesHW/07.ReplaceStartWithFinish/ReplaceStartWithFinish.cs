//Write a program that replaces all occurrences of the substring "start" with the substring "finish" in a text file. Ensure it will work with large files (e.g. 100 MB).

using System;
using System.IO;

class ReplaceStartWithFinish
{
    static void Main(string[] args)
    {
        StreamReader reader = new StreamReader("../../input.txt");
        StreamWriter writer = new StreamWriter("../../result.txt");

        using (reader)
        using (writer)
        {
            string line = reader.ReadLine();

            while (line != null)
            {
                line = line.ToLower().Replace("start", "finish");// 8exercise    line = line.ToLower();
                writer.WriteLine(line);                          // 8exercise    writer.WriteLine(Regex.Replace(line, @"\bstart\b", "finish"));
                line = reader.ReadLine();
            }
        }
    }
}

