namespace SortingHomework
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class SelectionSorter<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(IList<T> collection)
        {
            for (int i = 0; i < collection.Count; i++)
            {
                T currentElement = collection[i];

                for (int j = i + 1; j < collection.Count; j++)
                {
                    T comparer = collection[j];

                    if (comparer.CompareTo(currentElement) < 0)
                    {
                        var tmp = currentElement;
                        collection[i] = comparer;
                        collection[j] = currentElement;
                        currentElement = collection[i];
                    }
                }
            }
        }
    }
}
