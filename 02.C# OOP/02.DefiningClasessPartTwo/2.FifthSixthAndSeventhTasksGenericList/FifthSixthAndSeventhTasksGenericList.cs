using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FifthSixthAndSeventhTasksGenericList
{
    class FifthSixthAndSeventhTasksGenericList
    {
        static void Main()
        {
            GenericList<double> list1 = new GenericList<double>(4);
            list1.Add(1);
            list1.Add(2);
            list1.Add(3);
            list1.Add(4);
            list1.Add(5);

            Console.WriteLine(list1);

            list1.RemoveAt(2);

            Console.WriteLine(list1);

            list1.Insert(0, 20);
            list1.Insert(5, 100);

            Console.WriteLine(list1);

            int value = 5;

            int pos = list1.FindIndex(i => i == value);

            Console.WriteLine("{0} is at index {1}", value, pos);

            // using the member methods
            double min1 = list1.Min();

            Console.WriteLine("Min: {0}", min1);

            double max1 = list1.Max();

            Console.WriteLine("Max: {0}", max1);

            
        }
    }
}
