using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class FTML
{
    private const string RevTagOpen = "<rev>";
    private const string UpperTagOpen = "<upper>";
    private const string LowerTagOpen = "<lower>";
    private const string ToggleTagOpen = "<toggle>";
    private const string DelTagOpen = "<del>";

    private const string RevTagClose = "</rev>";
    private const string UpperTagClose = "</upper>";
    private const string LowerTagClose = "</lower>";
    private const string ToggleTagClose = "</toggle>";
    private const string DelTagClose = "</del>";

    private static int openedDelTags = 0;
    private static List<string> currentOpenTags = new List<string>();
    private static List<int> revTagStarts = new List<int>();
    private static StringBuilder output = new StringBuilder();

    static void Main(string[] args)
    {
        int numberOfLines = int.Parse(Console.ReadLine());

        for (int i = 0; i < numberOfLines; i++)
        {
            string currentLine = Console.ReadLine();
            int currentSymbolIndex = 0;
            while (currentSymbolIndex < currentLine.Length)
            {
                if (currentLine[currentSymbolIndex] == '<')
                {
                    string tag = GetTag(currentLine, currentSymbolIndex);
                    ProcessTag(tag);

                    currentSymbolIndex += tag.Length - 1;
                }

                else
                {
                    if (openedDelTags == 0)
                    {
                        char symbolToAdd = currentLine[currentSymbolIndex];

                        for (int j = currentOpenTags.Count - 1; j >= 0; j--)
                        {
                            symbolToAdd = ApplyEffect(symbolToAdd, currentOpenTags[j]);
                        }
                        output.Append(symbolToAdd);
                    }
                }

                currentSymbolIndex++;
            }
            output.Append('\n');
        }
        Console.WriteLine(output.ToString().Trim());
    }

    private static string GetTag(string currentLine, int currentSymbolIndex)
    {
        int tagStart = currentSymbolIndex;
        int tagEnd = currentLine.IndexOf('>', tagStart);

        string tag = currentLine.Substring(tagStart, tagEnd - tagStart + 1);

        return tag;
    }

    private static char ApplyEffect(char symbolToAdd, string currentOpenTags)
    {
        if (char.IsLetter(symbolToAdd))
        {
            if (currentOpenTags == UpperTagOpen)
            {
                symbolToAdd = char.ToUpper(symbolToAdd);
            }
            else if (currentOpenTags == LowerTagOpen)
            {
                symbolToAdd = char.ToLower(symbolToAdd);
            }
            else if (currentOpenTags == ToggleTagOpen)
            {
                if (char.IsLower(symbolToAdd))
                {
                    symbolToAdd = char.ToUpper(symbolToAdd);
                }
                else
                {
                    symbolToAdd = char.ToLower(symbolToAdd);
                }
            }
        }
        return symbolToAdd;
    }

    private static void ProcessTag(string tag)
    {
        if (tag == DelTagOpen)
        {
            openedDelTags++;
        }
        else if (tag == DelTagClose)
        {
            openedDelTags--;
        }
        else
        {
            if (openedDelTags == 0)
            {
                if (tag == RevTagOpen)
                {
                    revTagStarts.Add(output.Length);
                }
                else if (tag == RevTagClose)
                {
                    int currentRevStart = revTagStarts[revTagStarts.Count - 1];
                    int revEnd = output.Length - 1;
                    Reverse(currentRevStart, revEnd);
                    revTagStarts.RemoveAt(revTagStarts.Count - 1);
                }
                else if (tag[1] == '/')
                {
                    currentOpenTags.RemoveAt(currentOpenTags.Count - 1);
                }
                else
                {
                    currentOpenTags.Add(tag);
                }
            }
        }
    }

    private static void Reverse(int currentRevStart, int revEnd)
    {
        int start = currentRevStart;
        int end = revEnd;

        while (start < end)
        {
            char buffer = output[start];
            output[start] = output[end];
            output[end] = buffer;

            end--;
            start++;
        }
    }
}
