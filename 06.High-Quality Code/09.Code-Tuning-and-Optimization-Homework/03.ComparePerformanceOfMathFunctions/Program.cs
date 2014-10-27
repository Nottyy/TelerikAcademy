namespace ComparePerformanceOfMathFunctions
{
    using System;
    using System.Diagnostics;
    using System.Linq;
    using System.Text;
    public class ComparePerformanceOfMathFunctions
    {
        const int testValue = 1000000;
        public static void GenerateExecutionTime(Action method, string methodName)
        {
            Console.WriteLine(methodName + " starting: ");
            Stopwatch timer = new Stopwatch();
            timer.Start();
            method();
            timer.Stop();
            Console.WriteLine(methodName + " finished: " + timer.Elapsed.TotalMilliseconds + "ms");
            Console.WriteLine();
        }

        public static void SquareRootPerformance()
        {
            double result;
            for (int i = 0; i < testValue; i++)
            {
                result = Math.Sqrt(i);
            }
        }

        public static void NaturalLogarithmPerformance()
        {
            double result;
            for (int i = 0; i < testValue; i++)
            {
                result = Math.Sqrt(i);
            }
        }

        public static void SinusPerformance()
        {
            double result;
            for (int i = 0; i < testValue; i++)
            {
                result = Math.Sin(i);
            }
        }

        static void Main()
        {
            GenerateExecutionTime(() => SquareRootPerformance(), "SquareRoot Performance");
            GenerateExecutionTime(() => NaturalLogarithmPerformance(), "NaturalLogarithm Performance");
            GenerateExecutionTime(() => SinusPerformance(), "Sinus Performance");
        }
    }
}
