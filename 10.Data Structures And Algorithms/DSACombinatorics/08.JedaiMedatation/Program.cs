using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.JedaiMedatation
{
    class Program
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());
            var sortedM = new LinkedList<string>();
            var sortedK = new LinkedList<string>();
            var sortedP = new LinkedList<string>();
            string[] commands = Console.ReadLine().Split(' ');

            for (int i = 0; i < commands.Length; i++)
            {
                if (commands[i].StartsWith("m"))
                {
                    sortedM.AddLast(commands[i]);
                }
                else if (commands[i].StartsWith("p"))
                {
                    sortedP.AddLast(commands[i]);
                }
                else if (commands[i].StartsWith("k"))
                {
                    sortedK.AddLast(commands[i]);
                }

            }
            StringBuilder sb = new StringBuilder();

            while (sortedM.Count > 0)
            {
                sb.Append(sortedM.First.Value + " ");
                sortedM.RemoveFirst();
            }

            while (sortedK.Count > 0)
            {
                sb.Append(sortedK.First.Value + " ");
                sortedK.RemoveFirst();
            }

            while (sortedP.Count > 0)
            {
                sb.Append(sortedP.First.Value + " ");
                sortedP.RemoveFirst();
            }

            string result = sb.ToString().Trim();

            Console.WriteLine(result);
        }
    }
}
