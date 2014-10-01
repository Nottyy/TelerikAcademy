using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11.LinkedListImplementation
{
    public class ListItem<T>
    {
        private ListItem<T> nextItem=null;

        public ListItem(T value, ListItem<T> nextItem = null)
        {
            this.Value = value;
            this.NextItem = nextItem;
        }

        public T Value { get; set; }

        public ListItem<T> NextItem
        {
            get
            {
                return this.nextItem;
            }
            set
            {
                this.nextItem = value;
            }
        }

        
    }
}
