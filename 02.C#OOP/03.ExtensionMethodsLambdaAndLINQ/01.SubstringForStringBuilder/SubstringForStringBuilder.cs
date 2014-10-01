// Implement an extension method Substring(int index, int length) for the class StringBuilder that returns new StringBuilder 
// and has the same functionality as Substring in the class String.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubstringForStringBuilder
{
    class SubstringForStringBuilder
    {
        static void Main()
        {
            string text = "Arsenal are the new champions";
            StringBuilder sb = new StringBuilder();
            sb.Append(text);
            StringBuilder sbSplit = sb.Substring(0, 7);
            Console.WriteLine(sbSplit.ToString());
        }
    }
}
