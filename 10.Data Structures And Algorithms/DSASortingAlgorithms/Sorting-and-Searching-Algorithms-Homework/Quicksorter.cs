namespace SortingHomework
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Quicksorter<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(IList<T> collection)
        {
            QuickSort(collection, 0, collection.Count - 1);
        }

        private void QuickSort(IList<T> collection,int left, int right)
        {
            T pivot = collection[(right + left) / 2];
            int i = left;
            int j = right;

            while (i <= j)
            {
                while (collection[i].CompareTo(pivot) < 0)
                {
                    i++;
                }

                while (collection[j].CompareTo(pivot) > 0)
                {
                    j--;
                }

                if (i <= j)
                {
                    var tmp = collection[i];
                    collection[i] = collection[j];
                    collection[j] = tmp;

                    i++;
                    j--;
                }
            }

            if (left < j)
            {
                QuickSort(collection, left, j);
            }

            if (i < right)
            {
                QuickSort(collection, i, right);
            }
        }
    }
}
