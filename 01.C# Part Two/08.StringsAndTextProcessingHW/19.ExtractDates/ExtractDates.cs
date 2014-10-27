//Write a program that extracts from a given text all dates that match the format DD.MM.YYYY. Display them in the standard date format for Canada.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;

namespace extractDates
{
    class dates
    {
        static void Main(string[] args)
        {
            string text = "some text and some date line 10.01.2015 and some more. text and 05.03.2051"
                + "some more mails line 22.12.2012 kraq na sveta 2k.12.2012";
            int indexDot = text.IndexOf('.');
            bool isNUmber = true;
            int number = 0;
            while (indexDot > -1)
            {
                if (isNUmber == int.TryParse(text.Substring(indexDot - 2, 2), out number))
                {
                    if (isNUmber == int.TryParse(text.Substring(indexDot + 1, 2), out number))
                    {
                        if (isNUmber == int.TryParse(text.Substring(indexDot + 4, 4), out number))
                        {
                            Console.WriteLine(text.Substring(indexDot - 2, 10));
                            DateTime date = DateTime.ParseExact(text.Substring(indexDot - 2, 10), "dd.mm.yyyy", CultureInfo.InvariantCulture);
                            Console.WriteLine(date.ToString(CultureInfo.GetCultureInfo("en-CA").DateTimeFormat.ShortDatePattern) + "  If we were in CA");
                        }
                    }
                }
                indexDot = text.IndexOf('.', indexDot + 7);

            }
        }
    }
}