namespace SortPerformances
{
    using System;
    using System.Diagnostics;
    using System.Linq;
    using System.Text;

    public class CompareSortAlgorithms
    {
        private static readonly Random rnd = new Random();
        private static readonly char[] alphabet = Enumerable.Range('a', 'z' - 'a' + 1).Select(i => (Char)i).ToArray();
        private static readonly StringBuilder wordGeneratorHolder = new StringBuilder();

        #region InsertionSort Comparing Perfomances

        private static void IntInsertionSort(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                for (int k = i; k > 0 && array[k] < array[k - 1]; k--)
                {
                    int t = array[k];
                    array[k] = array[k - 1];
                    array[k - 1] = t;
                }
            }
        }

        private static void DoubleInsertionSort(double[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                for (int k = i; k > 0 && array[k] < array[k - 1]; k--)
                {
                    double t = array[k];
                    array[k] = array[k - 1];
                    array[k - 1] = t;
                }
            }
        }

        private static void StringInsertionSort(string[] array)
        {
            int i, j;

            for (i = 1; i < array.Length; i++)
            {
                string value = array[i];
                j = i - 1;
                while ((j >= 0) && (array[j].CompareTo(value) > 0))
                {
                    array[j + 1] = array[j];
                    j--;
                }
                array[j + 1] = value;
            }
        }

        static void InsertionSortInt(int[] intArrayUnsorted, int[] intArraySorted, int[] intArraySortedReversed)
        {
            GenerateExecutionTime.DisplayTime(() =>
            {
                IntInsertionSort(intArrayUnsorted);
            }, "Int unsorted Array");

            GenerateExecutionTime.DisplayTime(() =>
            {
                IntInsertionSort(intArraySorted);
            }, "Int sorted Array]");

            GenerateExecutionTime.DisplayTime(() =>
            {
                IntInsertionSort(intArraySortedReversed);
            }, "Int reverse sorted Array");
        }

        static void InsertionSortDouble(double[] doubleArrayUnsorted, double[] doubleArraySorted, double[] doubleArraySortedReversed)
        {
            GenerateExecutionTime.DisplayTime(() =>
            {
                DoubleInsertionSort(doubleArrayUnsorted);
            }, "Double unsorted Array");

            GenerateExecutionTime.DisplayTime(() =>
            {
                DoubleInsertionSort(doubleArraySorted);
            }, "Double sorted Array");

            GenerateExecutionTime.DisplayTime(() =>
            {
                DoubleInsertionSort(doubleArraySortedReversed);
            }, "Double reversed sorted Array");
        }

        static void InsertionSortString(string[] stringArrayUnsorted, string[] stringArraySorted, string[] stringArraySortedReversed)
        {
            GenerateExecutionTime.DisplayTime(() =>
            {
                StringInsertionSort(stringArrayUnsorted);
            }, "String unsorted Array");

            GenerateExecutionTime.DisplayTime(() =>
            {
                StringInsertionSort(stringArraySorted);
            }, "String sorted Array");

            GenerateExecutionTime.DisplayTime(() =>
            {
                StringInsertionSort(stringArraySortedReversed);
            }, "String reversed sorted Array");
        }

        #endregion

        #region SelectionSort Comparing Performances

        private static void IntSelectionSort(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                int low = i;
                for (int k = i + 1; k < array.Length; k++)
                    if (array[k] < array[low])
                        low = k;
                int t = array[i];
                array[i] = array[low];
                array[low] = t;
            }
        }

        private static void DoubleSelectionSort(double[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                int low = i;
                for (int k = i + 1; k < array.Length; k++)
                    if (array[k] < array[low])
                        low = k;
                double t = array[i];
                array[i] = array[low];
                array[low] = t;
            }
        }

        private static void StringSelectionSort(string[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                int low = i;
                for (int k = i + 1; k < array.Length; k++)
                    if (array[k].CompareTo(array[low]) > 0)
                        low = k;
                string t = array[i];
                array[i] = array[low];
                array[low] = t;
            }
        }

        static void SelectionSortInt(int[] intArrayUnsorted, int[] intArraySorted, int[] intArraySortedReversed)
        {
            GenerateExecutionTime.DisplayTime(() =>
            {
                IntSelectionSort(intArrayUnsorted);
            }, "Int unsorted Array");

            GenerateExecutionTime.DisplayTime(() =>
            {
                IntSelectionSort(intArraySorted);
            }, "Int sorted Array");

            GenerateExecutionTime.DisplayTime(() =>
            {
                IntSelectionSort(intArraySortedReversed);
            }, "Int reverse sorted Array");
        }

        static void SelectionSortDouble(Double[] doubleArrayUnsorted, Double[] doubleArraySorted, Double[] doubleArraySortedReversed)
        {
            GenerateExecutionTime.DisplayTime(() =>
            {
                DoubleSelectionSort(doubleArrayUnsorted);
            }, "Double unsorted Array");

            GenerateExecutionTime.DisplayTime(() =>
            {
                DoubleSelectionSort(doubleArraySorted);
            }, "Double sorted Array");

            GenerateExecutionTime.DisplayTime(() =>
            {
                DoubleSelectionSort(doubleArraySortedReversed);
            }, "Double reverse sorted Array");
        }

        static void SelectionSortString(String[] stringArrayUnsorted, String[] stringArraySorted, String[] stringArraySortedReversed)
        {
            GenerateExecutionTime.DisplayTime(() =>
            {
                StringSelectionSort(stringArrayUnsorted);
            }, "String unsorted Array");

            GenerateExecutionTime.DisplayTime(() =>
            {
                StringSelectionSort(stringArraySorted);
            }, "String sorted Array");

            GenerateExecutionTime.DisplayTime(() =>
            {
                StringSelectionSort(stringArraySortedReversed);
            }, "String reverse sorted Array");
        }

        #endregion

        #region QuickSort Comparing Perfomances

        private static void QuicksortString(String[] array, int left, int right)
        {
            int i = left, j = right;
            String temp = array[(left + right) / 2];

            while (i <= j)
            {
                while (array[i].CompareTo(temp) < 0)
                {
                    i++;
                }
                while (array[j].CompareTo(temp) > 0)
                {
                    j--;
                }
                if (i <= j)
                {
                    String tmp = array[i];
                    array[i] = array[j];
                    array[j] = tmp;
                    i++;
                    j--;
                }
            }
            if (left < j)
            {
                QuicksortString(array, left, j);
            }
            if (i < right)
            {
                QuicksortString(array, i, right);
            }
        }

        private static void Swap(int[] array, int left, int right)
        {
            int temp = array[right];
            array[right] = array[left];
            array[left] = temp;
        }

        private static void QuicksortInt(int[] array, int left, int right)
        {
            int currentLeftHolder = left;
            int currentRightHolder = right;
            int pivot = left;
            left++;

            while (right >= left)
            {
                if (array[left] >= array[pivot] &&
                    array[right] < array[pivot])
                    Swap(array, left, right);
                else if (array[left] >= array[pivot])
                    right--;
                else if (array[right] < array[pivot])
                    left++;
                else
                {
                    right--;
                    left++;
                }
            }

            Swap(array, pivot, right);
            pivot = right;
            if (pivot > currentLeftHolder)
                QuicksortInt(array, currentLeftHolder, pivot);
            if (currentRightHolder > pivot + 1)
                QuicksortInt(array, pivot + 1, currentRightHolder);
        }

        private static void SwapDouble(double[] array, int left, int right)
        {
            double temp = array[right];
            array[right] = array[left];
            array[left] = temp;
        }

        private static void QuicksortDouble(double[] array, int left, int right)
        {
            int currentLeftHolder = left;
            int currentRightHolder = right;
            int pivot = left;
            left++;

            while (right >= left)
            {
                if (array[left] >= array[pivot] &&
                    array[right] < array[pivot])
                    SwapDouble(array, left, right);
                else if (array[left] >= array[pivot])
                    right--;
                else if (array[right] < array[pivot])
                    left++;
                else
                {
                    right--;
                    left++;
                }
            }

            SwapDouble(array, pivot, right);
            pivot = right;
            if (pivot > currentLeftHolder)
                QuicksortDouble(array, currentLeftHolder, pivot);
            if (currentRightHolder > pivot + 1)
                QuicksortDouble(array, pivot + 1, currentRightHolder);
        }

        static void QuickSortInt(int[] intArrayUnsorted, int[] intArraySorted, int[] intArraySortedReversed)
        {
            GenerateExecutionTime.DisplayTime(() =>
            {
                QuicksortInt(intArrayUnsorted, 0, intArrayUnsorted.Length - 1);
            }, "Int unsorted Array");

            GenerateExecutionTime.DisplayTime(() =>
            {
                QuicksortInt(intArraySorted, 0, intArraySorted.Length - 1);
            }, "Int sorted Array");

            GenerateExecutionTime.DisplayTime(() =>
            {
                QuicksortInt(intArraySortedReversed, 0, intArraySortedReversed.Length - 1);
            }, "Int reverse sorted Array");

        }

        static void QuickSortDouble(double[] doubleArrayUnsorted, double[] doubleArraySorted, double[] doubleArraySortedReversed)
        {
            GenerateExecutionTime.DisplayTime(() =>
            {
                QuicksortDouble(doubleArrayUnsorted, 0, doubleArrayUnsorted.Length - 1);
            }, "Double unsorted Array");

            GenerateExecutionTime.DisplayTime(() =>
            {
                QuicksortDouble(doubleArraySorted, 0, doubleArraySorted.Length - 1);
            }, "Double sorted Array");

            GenerateExecutionTime.DisplayTime(() =>
            {
                QuicksortDouble(doubleArraySortedReversed, 0, doubleArraySortedReversed.Length - 1);
            }, "Double reverse sorted Array");

        }

        static void QuickSortString(string[] stringArrayUnsorted, string[] stringArraySorted, string[] stringArraySortedReversed)
        {
            GenerateExecutionTime.DisplayTime(() =>
            {
                QuicksortString(stringArrayUnsorted, 0, stringArrayUnsorted.Length - 1);
            }, "String unsorted Array");

            GenerateExecutionTime.DisplayTime(() =>
            {
                QuicksortString(stringArraySorted, 0, stringArraySorted.Length - 1);
            }, "String sorted Array");

            GenerateExecutionTime.DisplayTime(() =>
            {
                QuicksortString(stringArraySortedReversed, 0, stringArraySortedReversed.Length - 1);
            }, "String reverse sorted Array");
        }

        #endregion


        static void Main(string[] args)
        {
            //preparation for int Sorting
            int[] intArrayUnsorted = new int[10000];
            for (int i = 0, length = intArrayUnsorted.Length; i < length; i++)
            {
                intArrayUnsorted[i] = rnd.Next(int.MinValue, int.MaxValue);
            }

            int[] intArraySorted = intArrayUnsorted.OrderBy(x => x).ToArray();
            int[] intArraySortedReversed = intArrayUnsorted.OrderBy(x => x).ToArray();
            Array.Reverse(intArraySortedReversed);

            //preparation for double Sorting
            double[] doubleArrayUnsorted = new double[10000];
            for (int i = 0, length = doubleArrayUnsorted.Length; i < length; i++)
            {
                doubleArrayUnsorted[i] = rnd.Next(short.MinValue, short.MaxValue) + rnd.NextDouble();
            }

            double[] doubleArraySorted = doubleArrayUnsorted.OrderBy(x => x).ToArray();
            double[] doubleArraySortedReversed = doubleArrayUnsorted.OrderBy(x => x).ToArray();
            Array.Reverse(doubleArraySortedReversed);

            //preparation for String Sorting
            string[] stringArrayUnsorted = new string[10000];
            for (int i = 0, length = stringArrayUnsorted.Length; i < length; i++)
            {
                for (int j = 0, rndLength = rnd.Next(2, 10); j < rndLength; j++)
                {
                    wordGeneratorHolder.Append(alphabet[rnd.Next(0, alphabet.Length - 1)]);
                }
                stringArrayUnsorted[i] = wordGeneratorHolder.ToString();
                wordGeneratorHolder.Clear();
            }

            string[] stringArraySorted = stringArrayUnsorted.OrderBy(x => x).ToArray();
            string[] stringArraySortedReversed = stringArrayUnsorted.OrderBy(x => x).ToArray();
            Array.Reverse(stringArraySortedReversed);

            //actual tests

            Console.WriteLine("Insertion Sort : \n");
            InsertionSortInt((int[])intArrayUnsorted.Clone(),
                (int[])intArraySorted.Clone(), (int[])intArraySortedReversed.Clone());

            Console.WriteLine();
            InsertionSortDouble((double[])doubleArrayUnsorted.Clone(),
                (double[])doubleArraySorted.Clone(), (double[])doubleArraySortedReversed.Clone());

            Console.WriteLine();
            InsertionSortString(stringArrayUnsorted.Select(a => (string)a.Clone()).ToArray(),
                stringArraySorted.Select(a => (string)a.Clone()).ToArray(),
                stringArraySortedReversed.Select(a => (string)a.Clone()).ToArray());

            Console.WriteLine("\nSelection Sort : \n");
            SelectionSortInt((int[])intArrayUnsorted.Clone(),
                (int[])intArraySorted.Clone(), (int[])intArraySortedReversed.Clone());

            Console.WriteLine();
            SelectionSortDouble((double[])doubleArrayUnsorted.Clone(),
                (double[])doubleArraySorted.Clone(), (double[])doubleArraySortedReversed.Clone());

            Console.WriteLine();
            SelectionSortString(stringArrayUnsorted.Select(a => (string)a.Clone()).ToArray(),
                stringArraySorted.Select(a => (string)a.Clone()).ToArray(),
                stringArraySortedReversed.Select(a => (string)a.Clone()).ToArray());

            Console.WriteLine("\nQuick Sort : \n");
            QuickSortInt((int[])intArrayUnsorted.Clone(),
                (int[])intArraySorted.Clone(), (int[])intArraySortedReversed.Clone());

            Console.WriteLine();
            QuickSortDouble((double[])doubleArrayUnsorted.Clone(), (double[])doubleArraySorted.Clone(),
                (double[])doubleArraySortedReversed.Clone());

            Console.WriteLine();
            QuickSortString(stringArrayUnsorted.Select(a => (string)a.Clone()).ToArray(),
                stringArraySorted.Select(a => (string)a.Clone()).ToArray(),
                stringArraySortedReversed.Select(a => (string)a.Clone()).ToArray());
        }
    }
}