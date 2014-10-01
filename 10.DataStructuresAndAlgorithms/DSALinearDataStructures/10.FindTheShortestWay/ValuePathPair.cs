using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10.FindTheShortestWay
{
    public class ValuePathPair
    {
        public int Value { get; private set; }

        public string PathToHere { get; private set; }

        public ValuePathPair(int value, string path = null)
        {
            this.Value = value;
            if (path == null)
            {
                this.PathToHere = this.Value.ToString();
            }
            else
            {
                this.SavePath(path);
            }
        }

        public void SavePath(string path)
        {
            this.PathToHere = string.Format("{0} -> {1}", path, this.Value.ToString());
        }
    }
}
