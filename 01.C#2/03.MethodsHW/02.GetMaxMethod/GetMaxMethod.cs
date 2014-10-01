//Write a method GetMax() with two parameters that returns the bigger of two integers. Write a program that reads 3 integers from the console and prints the biggest of them using the method GetMax().

using System;

class GetMaxMethod
{
    static void Main()
    {
        int num1 = int.Parse(Console.ReadLine());
        int num2 = int.Parse(Console.ReadLine());
        int num3 = int.Parse(Console.ReadLine());

        int biggest = GetMax(GetMax(num1, num2) , num3);

        Console.WriteLine("The biggest number is: {0}", biggest);
    }

    static int GetMax(int num1, int num2)
    {
        int bigger = num1;
        if (num2 > bigger)
        {
            bigger = num2;
        }
        return bigger;
    }
}

