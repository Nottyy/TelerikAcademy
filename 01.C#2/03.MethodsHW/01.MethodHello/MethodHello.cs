//Write a method that asks the user for his name and prints “Hello, <name>” (for example, “Hello, Peter!”). Write a program to test this method.

using System;

class MethodHello
{
    static void Main()
    {
        PrintName();
    }

    static void PrintName()
    {
        Console.WriteLine("Enter your name: ");
        string name = Console.ReadLine();
        Console.WriteLine("Hello, {0}.",name);
    }
}

