namespace Utils
{
    using System;

    public static class ChronologyUtils
    {
        public static bool IsOlderThan(this DateTime thisValue, DateTime value)
        {
            return thisValue < value;
        }
    }
}
