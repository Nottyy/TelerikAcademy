namespace SortingHomework
{
    using System;
    using System.Collections.Generic;

    public class SortableCollection<T> where T : IComparable<T>
    {
        private IList<T> items;

        public SortableCollection()
        {
            this.items = new List<T>();
        }

        public SortableCollection(IEnumerable<T> items)
        {
            this.items = new List<T>(items);
        }

        public IList<T> Items
        {
            get
            {
                return this.items;
            }
            set
            {
                this.items = value;
            }
        }

        public void Sort(ISorter<T> sorter)
        {
            sorter.Sort(this.items);
        }

        public bool LinearSearch(T item)
        {
            bool itemExists = false;

            for (int i = 0; i < items.Count; i++)
            {
                if (items[i].CompareTo(item) == 0)
                {
                    itemExists = true;
                    break;
                }
            }

            return itemExists;
        }

        public bool BinarySearch(T item)
        {
            int left = 0;
            int right = this.items.Count - 1;
            

            while (left <= right)
            {
                int middle = (left + right) / 2;

                if (items[middle].CompareTo(item) == 0)
                {
                    return true;
                }

                if (items[middle].CompareTo(item) > 0)
                {
                    right = middle - 1;
                }
                else
                {
                    left = middle + 1;
                }
            }

            return false;
        }


        public void Shuffle()
        {
            Random rand = new Random();
            for (int i = items.Count - 1; i >= 0; i--)
            {
                int j = (int)(rand.Next(items.Count));

                var tmp = items[j];
                items[j] = items[i];
                items[i] = tmp;
             }
        }

        public void PrintAllItemsOnConsole()
        {
            for (int i = 0; i < this.items.Count; i++)
            {
                if (i == 0)
                {
                    Console.Write(this.items[i]);
                }
                else
                {
                    Console.Write(" " + this.items[i]);
                }
            }

            Console.WriteLine();
        }
    }
}
