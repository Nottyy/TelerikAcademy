using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColorfulRabitsAlgoOct2012
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<int, int> rabbitsValues = new Dictionary<int, int>();

            for (int i = 0; i < n; i++)
            {
                int answer = int.Parse(Console.ReadLine());

                if (rabbitsValues.ContainsKey(answer + 1))
                {
                    rabbitsValues[answer + 1]++;
                }
                else
                {
                    rabbitsValues.Add(answer + 1, 1);
                }
            }

            int rabbitsCount = 0;

            foreach (var rabbit in rabbitsValues)
            {
                if (rabbit.Key >= rabbit.Value)
                {
                    rabbitsCount += rabbit.Key;
                }
                else
                {
                    rabbitsCount += (rabbit.Value / rabbit.Key) * rabbit.Key;
                    if (rabbit.Value % rabbit.Key != 0)
                    {
                        rabbitsCount += rabbit.Key;
                    }
                }
            }

            Console.WriteLine(rabbitsCount);
        }
    }
}
