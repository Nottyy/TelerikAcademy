using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubstringForStringBuilder
{
    public static class Extensions
    {
        public static StringBuilder Substring(this StringBuilder sb, int index, int length)
        {
            StringBuilder tmp = new StringBuilder();
            string text = sb.ToString();
            text = text.Substring(index, length);
            return tmp.Append(text);
        }
    }
}
