namespace SortingHomework
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class MergeSorter<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(IList<T> collection)
        {
            IList<T> sortedCollection = SplitElements(collection);
            for (int i = 0; i < sortedCollection.Count; i++)
            {
                collection[i] = sortedCollection[i];
            }
        }

        private IList<T> SplitElements(IList<T> array)
        {
            if (array.Count == 1)
            {
                return array;
            }

            int middle = array.Count / 2;
            IList<T> leftArr = new List<T>();
            IList<T> rightArr = new List<T>();

            for (int i = 0; i < middle; i++)
            {
                leftArr.Add(array[i]);
            }

            for (int i = middle, j=0; i < array.Count; j++, i++)
            {
                rightArr.Add(array[i]);
            }

            leftArr = SplitElements(leftArr);
            rightArr = SplitElements(rightArr);

            return MergeArrays(leftArr, rightArr);
        }

        private IList<T> MergeArrays(IList<T> leftArr, IList<T> rightArr)
        {
            int rightToIncrease = 0;
            int leftToIncrease = 0;
            IList<T> mergeArr = new List<T>();

            for (int i = 0; i < leftArr.Count + rightArr.Count; i++)
            {
                if (leftToIncrease == leftArr.Count ||
                    (rightToIncrease < rightArr.Count && rightArr[rightToIncrease].CompareTo(leftArr[leftToIncrease]) <= 0))
                {
                    mergeArr.Add(rightArr[rightToIncrease]);
                    rightToIncrease++;
                }
                else if (rightToIncrease == rightArr.Count ||
                    (leftToIncrease < leftArr.Count && leftArr[leftToIncrease].CompareTo(rightArr[rightToIncrease]) <= 0))
                {
                    mergeArr.Add(leftArr[leftToIncrease]);
                    leftToIncrease++;
                }
            }

            return mergeArr;
        }
    }
}
