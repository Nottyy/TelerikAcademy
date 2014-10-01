using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12.ZigzagLines
{
    class Program
    {
        static int k;
        static int n;
        static int[] arr;
        static int counter = 0;
        static bool[] used;
        static void Main(string[] args)
        {
            string[] lines = Console.ReadLine().Split(' ');
            k = int.Parse(lines[1]);
            n = int.Parse(lines[0]);
            arr = new int[k];
            used = new bool[n];
            GenerateVariationsNoReps(0);

            Console.WriteLine(counter);
        }

        static void GenerateVariationsNoReps(int index)
        {

            if (index >= k)
            {
                counter++;
            }
            else
            {
                for (int i = 0; i < n; i++)
                {

                    if (!used[i])
                    {
                        used[i] = true;
                        if (index == 0)
                        {
                            arr[index] = i;
                            GenerateVariationsNoReps(index + 1);
                        }
                        else
                        {
                            bool isIndexEven = index % 2 == 0 ? true : false;
                            if (!isIndexEven)
                            {
                                if (i < arr[index - 1])
                                {
                                    arr[index] = i;
                                    GenerateVariationsNoReps(index + 1);
                                }
                            }
                            else
                            {
                                if (i > arr[index - 1])
                                {
                                    arr[index] = i;
                                    GenerateVariationsNoReps(index + 1);
                                }
                            }
                        }
                        used[i] = false;
                    }
                }
            }
        }
    }
}
