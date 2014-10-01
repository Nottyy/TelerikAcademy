using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtensionsForIEnumerable
{
    public static class ExtensionMethodsIEnumerable
    {
        public static T Product<T>(this IEnumerable<T> arr)
        {
            dynamic product = 1;
            foreach (var c in arr)
            {
                product *= (dynamic)c;
                if (product == 0)
                {
                    break;
                }
            }
            return product;
        }

        public static T Sum<T>(this IEnumerable<T> arr)
        {
            dynamic sum = 0;
            foreach (var c in arr)
            {
                sum += (dynamic)c;
            }

            return sum;
        }

        public static T Min<T>(this IEnumerable<T> arr)
        {
            dynamic minElement = int.MaxValue;

            foreach (var c in arr)
            {
                if (c < minElement)
                {
                    minElement = c;
                }
            }

            return minElement;
        }

        public static T Max<T>(this IEnumerable<T> arr)
        {
            dynamic maxElement = int.MinValue;

            foreach (var c in arr)
            {
                if (c > maxElement)
                {
                    maxElement = c;
                }
            }

            return maxElement;
        }

        public static T Average<T>(this IEnumerable<T> arr)
        {
            dynamic avg = 0;
            dynamic counter = 0;
            foreach (var c in arr)
            {
                avg += c;
                counter++;
            }
            if (counter == 0)
            {
                throw new ArgumentException("Empty collection");
            }
            return avg / counter;
        }
    }
}
