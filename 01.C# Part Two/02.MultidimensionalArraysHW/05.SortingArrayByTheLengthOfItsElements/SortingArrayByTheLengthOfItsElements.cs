//You are given an array of strings. Write a method that sorts the array by the length of its elements (the number of characters composing them).

using System;

class SortingArrayByTheLengthOfItsElements
{
    static void Main(string[] args)
    {
        string[] stringArray = { "ha", "haha", "hihihi", "hoh", "hohohohohohoh" };

        SortBySize(stringArray);
    }

    static void SortBySize(string[] stringArray)
    {
        int n = stringArray.Length;
        int[] sizes = new int[n];              //This will hold the size of each string

        for (int i = 0; i < n; i++)
        {
            sizes[i] = stringArray[i].Length;
        }

        Array.Sort(sizes, stringArray);       //Sorts the second array, according to the "keys" in the first (ascending)

        foreach (var element in stringArray)
        {
            Console.WriteLine(element);
        }
    }
}
