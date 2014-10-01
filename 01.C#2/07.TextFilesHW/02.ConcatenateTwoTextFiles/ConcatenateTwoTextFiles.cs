//Write a program that concatenates two text files into another text file.

using System;
using System.IO;
using System.Text;
class ConcatenateTwoTextFiles
{
    static void WriteToFile(StreamWriter output, string file)
    {
        using (StreamReader input = new StreamReader(file))
        {
            for (string line; (line = input.ReadLine()) != null; )
            {
                output.WriteLine(line);
            }
        }
    }

    static void Main()
    {
        string[] files = { "../../subs.txt", "../../subs2.txt" };

        using (StreamWriter output = new StreamWriter("../../conc.txt"))
        {
            foreach (string file in files)
            {
                WriteToFile(output, file);
            }
        }
    }
    //static void Main()
    //{
    //    StreamReader readerFirstFile = new StreamReader("../../subs.txt", Encoding.GetEncoding("windows-1251"));
    //    StreamReader readerSecondFile = new StreamReader("../../subs2.txt", Encoding.GetEncoding("windows-1251"));
    //    using (readerFirstFile)    // read and write first file
    //    {
    //        StreamWriter writer = new StreamWriter("../../conc.txt", false, Encoding.GetEncoding("windows-1251"));
    //        using (writer)
    //        {
    //            string s;
    //            while ((s = readerFirstFile.ReadLine()) != null)
    //            {
    //                writer.WriteLine(s);
    //            }
    //        }
    //    }
    //    using (readerSecondFile)   //read and append(true) second file to first file
    //    {
    //        StreamWriter writer = new StreamWriter("../../conc.txt", true, Encoding.GetEncoding("windows-1251"));
    //        using (writer)
    //        {
    //            string s;
    //            while ((s = readerSecondFile.ReadLine()) != null)
    //            {
    //                writer.WriteLine(s);
    //            }
    //        }
    //    }
    //}
}

