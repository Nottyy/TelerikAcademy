using System;
using System.Text;
using System.IO;


class InsertLineNumbers
{
    static void Main()
    {
        StreamReader reader = new StreamReader("../../text.txt");
        string line = reader.ReadLine();
        int lineNum = 0;
        using (reader)
        {
            StreamWriter writer = new StreamWriter("../../new.txt");

            using (writer)
            {
                while (line != null)
                {
                    writer.WriteLine("Line - {0}: {1}", lineNum, line);
                    line = reader.ReadLine();
                    lineNum++;
                }
            }
        }
    }
}

