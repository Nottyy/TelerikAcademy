//Write a program that reads a date and time given in the format: day.month.year hour:minute:second and prints the date and time after 6 hours and 30 minutes (in the same format) along with the day of week in Bulgarian.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class AddHoursToDate
{
    static void Main()
    {
        Console.Write("Enter date: ");
        string strDate = Console.ReadLine();

        DateTime date = DateTime.ParseExact(strDate, "d.MM.yyyy HH:mm:ss", CultureInfo.InvariantCulture);

        DateTime newDate = date.AddSeconds(6 * 3600 + 30 * 60);

        Console.WriteLine("Date after 6 hrs 30 mins: {1} {0:d.MM.yyyy HH:mm:ss}", newDate, newDate.DayOfWeek);
    }
}
