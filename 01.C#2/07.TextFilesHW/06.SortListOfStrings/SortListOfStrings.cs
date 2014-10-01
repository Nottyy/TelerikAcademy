//Write a program that reads a text file containing a list of strings, sorts them and saves them to another text file. 

using System;
using System.IO;
using System.Collections.Generic;

class SortListOfStrings
{
    static void Main()
    {
        List<string> lines = ReadLines();
        lines.Sort();
        WriteLines(lines);
    }

    static List<string> ReadLines()
    {
        StreamReader input = new StreamReader("../../input.txt");
        List<string> names = new List<string>();
        using (input)
        {
            for (string line; (line = input.ReadLine()) != null; )
            {
                names.Add(line);
            }
        }
        return names;
    }

    static void WriteLines(List<string> lines)
    {
        using (StreamWriter writer = new StreamWriter("../../output.txt"))
        {
            foreach (var line in lines)
            {
                writer.WriteLine(line);
            }
        }
    }
}

