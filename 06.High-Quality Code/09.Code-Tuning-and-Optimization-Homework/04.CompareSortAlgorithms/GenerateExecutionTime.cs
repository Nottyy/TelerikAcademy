namespace SortPerformances
{
    using System;
    using System.Diagnostics;
    using System.Linq;

    public static class GenerateExecutionTime
    {
        public static void DisplayTime(Action action, string typeInfo)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            action();
            stopwatch.Stop();
            Console.WriteLine(typeInfo + " - " + stopwatch.Elapsed);
        }
    }
}
