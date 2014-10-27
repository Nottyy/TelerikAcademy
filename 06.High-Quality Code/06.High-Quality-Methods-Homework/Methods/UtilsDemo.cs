namespace Utils
{
    using System;

    internal class UtilsDemo
    {

        private static void Main()
        {
            Console.WriteLine(GeometryUtils.CalcTriangleArea(3, 4, 5));
            Console.WriteLine(LanguageUtils.DigitToText(5));
            Console.WriteLine(StatisticalUtils.Max(5, -1, 3, 2, 14, 2, 3));
            
            ConsolePrinter.PrintNumber(1.3, 2);
            ConsolePrinter.PrintPercent(0.75, 0);
            ConsolePrinter.PrintAligned(2.30, 8);

            Console.WriteLine(GeometryUtils.CalcDistance(3, -1, 3, 2.5));
            Console.WriteLine("Horizontal? " + GeometryUtils.IsLineHorizontal(3, -1, 3, 2.5));
            Console.WriteLine("Vertical? " + GeometryUtils.IsLineVertical(3, -1, 3, 2.5));

            Student peter = new Student() { FirstName = "Peter", LastName = "Ivanov", 
                                            BirthDate = new DateTime(1992, 03, 17) };

            Student stella = new Student() { FirstName = "Stella", LastName = "Markova", 
                                             BirthDate = new DateTime(1993, 11, 3) };

            Console.WriteLine(
                "Is {0} older than {1}? -> {2}",
                peter.FirstName,
                stella.FirstName,
                peter.BirthDate.IsOlderThan(stella.BirthDate));
        }
        private class Student
        {
            public string FirstName { get; set; }

            public string LastName { get; set; }

            public DateTime BirthDate { get; set; }
        }
    }
}
