using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryPasswordsAlgoOct2012
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = Console.ReadLine();

            var stars = pattern.Count(x => x == '*');
            int k = 2; //  0 or 1
            long result = 1;
            for (int i = 0; i < stars; i++)
            {
                result *= k;  
            }
            Console.WriteLine(result);
        }
    }
}
