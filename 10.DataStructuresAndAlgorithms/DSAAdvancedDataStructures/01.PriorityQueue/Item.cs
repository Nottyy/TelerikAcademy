using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriorityQueue
{
    public class Item : IComparable
    {
        public int priority;

        public Item(int priority)
        {
            this.priority = priority;
        }

        public override string ToString()
        {
            return priority.ToString();
        }

        public int CompareTo(object item)
        {
            if (this.priority < (item as Item).priority)
                return -1;
            else if (this.priority > (item as Item).priority)
                return 1;
            return 0;
        }
    }
}
