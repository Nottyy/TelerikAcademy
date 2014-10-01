using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Indices
{
    class Indices
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());

            string[] arr = Console.ReadLine().Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
            int[] array = new int[arr.Length];

            bool[] visited = new bool[array.Length];

            for (int i = 0; i < arr.Length; i++)
            {
                array[i] = int.Parse(arr[i]);
            }

            int currentIndex = 0;

            StringBuilder result = new StringBuilder();

            int loopStart = -1;

            while (true)
            {
                if (currentIndex < 0 || currentIndex >= array.Length)
                {
                    break;
                }
                if (visited[currentIndex])
                {
                    loopStart = currentIndex;
                    break;
                }

                result.Append(currentIndex);
                result.Append(' ');
                visited[currentIndex] = true;
                currentIndex = array[currentIndex];
            }


            if (loopStart >= 0)
            {
                int index = result.ToString().IndexOf((" " + loopStart + " ").ToString());
                if (index < 0)
                {
                    result.Insert(0, '(');
                }
                else
                {
                    result[index] = '(';
                }
                result[result.Length - 1] = ')';
                
            }

            Console.WriteLine(result.ToString().Trim());
        }
    }
}
