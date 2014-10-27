namespace Utils
{
    using System;

    public static class StatisticalUtils
    {
        public static int Max(params int[] args)
        {
            if (args == null)
            {
                throw new ArgumentNullException("args is null.");
            }

            if (args.Length == 0)
            {
                throw new ArgumentException("No arguments specified.");
            }

            int max = int.MinValue;

            for (int i = 0; i < args.Length; i++)
            {
                if (args[i] > max)
                {
                    max = args[i];
                }
            }

            return max;
        }
    }
}
