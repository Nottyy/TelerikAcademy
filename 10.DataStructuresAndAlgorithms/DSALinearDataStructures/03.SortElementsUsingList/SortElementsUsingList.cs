using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.SortElementsUsingList
{
    class SortElementsUsingList
    {
        static void Main(string[] args)
        {
            var elements = new List<int>() { 34, 55, 2, 5, 1, 0, 101 };
            Console.WriteLine("Initial elements: {0}", string.Join(" ", elements));

            QuickSortRecursive(elements, 0, elements.Count - 1);
            Console.WriteLine("After sorting with QuickSort algorithm elements: {0}", string.Join(" ", elements));
        }

        static public int Partition(IList<int> numbers, int left, int right)
        {
            int pivot = numbers[left];
            while (true)
            {
                while (numbers[left] < pivot)
                    left++;

                while (numbers[right] > pivot)
                    right--;

                if (left < right)
                {
                    int temp = numbers[right];
                    numbers[right] = numbers[left];
                    numbers[left] = temp;
                }
                else
                {
                    return right;
                }
            }
        }

        static public void QuickSortRecursive(IList<int> arr, int left, int right)
        {
            // For Recusrion
            if (left < right)
            {
                int pivot = Partition(arr, left, right);

                if (pivot > 1)
                    QuickSortRecursive(arr, left, pivot - 1);

                if (pivot + 1 < right)
                    QuickSortRecursive(arr, pivot + 1, right);
            }
        }
    }
}
