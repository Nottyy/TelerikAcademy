using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvalidRangeException
{
    public class InvalidExceptionRangeTest
    {
        static void Main()
        { 
            // InvalidRangeException<int> test
            PrintNumber();

            // InvalidRangeException<DateTime> test
            PrintDate();
        }

        private static void PrintNumber()
        {
            const int min = 0;
            const int max = 100;
            Console.WriteLine("Insert number in the range {0} - {1}", min, max);
            try
            {
                Console.WriteLine("Your number is: " + GetNumber(min, max));
            }
            catch (InvalidRangeException<int> catchedExc)
            {
                Console.WriteLine("The entered number {0} is not in the expected range : {1} - {2}",catchedExc.OutRangeValue, catchedExc.MinValue, catchedExc.MaxValue);
            }
        }

        private static int GetNumber(int min, int max)
        {
            int number = int.Parse(Console.ReadLine());

            if (number < min || number > max)
            {
                throw new InvalidRangeException<int>("Number not in range!", number, min, max);
            }
            else
            {
                return number;
            }
        }

        private static void PrintDate()
        {
            var minDate = new DateTime(1980, 1, 1);
            var maxDate = new DateTime(2013, 12, 31);

            Console.WriteLine("Enter date in the range: {0} - {1}", minDate.ToShortDateString(), maxDate.ToShortDateString());
            try
            {
                Console.WriteLine("Your date is: " + GetDate(minDate, maxDate).ToShortDateString());
            }
            catch (InvalidRangeException<DateTime> catchedExc)
            {
                Console.WriteLine("Your date - {0} is not in the range: {1} - {2}. Try again!", 
                    catchedExc.OutRangeValue.ToShortDateString(), catchedExc.MinValue.ToShortDateString(), catchedExc.MaxValue.ToShortDateString());
            }

        }

        private static DateTime GetDate(DateTime minDate, DateTime maxDate)
        {
            var date = DateTime.Parse(Console.ReadLine());

            if (date < minDate || date > maxDate)
            {
                throw new InvalidRangeException<DateTime>("Date not in range!",date,minDate,maxDate);
            }
            else
            {
                return date;
            }
        }
    }
}
