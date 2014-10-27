namespace Utils
{
    using System;

    public static class ConsolePrinter
    {
        public static void PrintNumber(double value, int decimals)
        {
            string format = "{0:F" + decimals + "}";
            Console.WriteLine(format, value);
        }

        public static void PrintPercent(double value, int decimals)
        {
            string format = "{0:P" + decimals + "}";
            Console.WriteLine(format, value);
        }

        public static void PrintAligned(object value, int totalWidth)
        {
            string format = "{0," + totalWidth + "}";
            Console.WriteLine(format, value);
        }
    }
}
