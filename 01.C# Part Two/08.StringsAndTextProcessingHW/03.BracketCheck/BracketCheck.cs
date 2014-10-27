//Write a program to check if in a given expression the brackets are put correctly.
//Example of correct expression: ((a+b)/5-d).
//Example of incorrect expression: )(a+b)).

using System;
using System.Collections.Generic;

class BracketCheck
{
    static void Main()
    {
        Console.WriteLine("Enter expresion:");
        string input = Console.ReadLine();
        List<char> bracket = new List<char>();
        foreach (char item in input)
        {
            if (item == '(')
            {
                bracket.Add(item);
            }
            else if (item == ')')
            {
                if (bracket.Count > 0)
                {
                    bracket.Remove('(');
                }
                else
                {
                    Console.WriteLine("Incorrect");
                    return;
                }
            }
        }
        if (bracket.Count == 0)
        {
            Console.WriteLine("Correct");
        }
        else
        {
            Console.WriteLine("Incorrect");
        }
    }
}
