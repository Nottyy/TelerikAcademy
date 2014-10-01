//Write a program to return the string with maximum length from an array of strings. Use LINQ.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class ReturnTheStringWithMaxLength
{
    static void Main()
    {
        
        string[] stringSequence = new string[] 
        {
            "asdasdsaddsdasaqweqwadaseqweqwdd",
            "asdasdasda",
            "wenfonaeofnoaef",
            " s ss",
            "asdaseweqweewewqeqas",
        };

        //sort strings by length in descending order and then get the first one.
        string stringWithMaximalLength = stringSequence.OrderBy(x => x.Length).Last();

        Console.WriteLine(stringWithMaximalLength);
    }
}

