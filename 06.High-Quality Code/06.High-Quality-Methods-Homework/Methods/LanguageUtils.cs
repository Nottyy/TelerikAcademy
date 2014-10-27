namespace Utils
{
    using System;

    public static class LanguageUtils
    {
        public static string DigitToText(int value)
        {
            switch (value)
            {
                case 0: return "zero";
                case 1: return "one";
                case 2: return "two";
                case 3: return "three";
                case 4: return "four";
                case 5: return "five";
                case 6: return "six";
                case 7: return "seven";
                case 8: return "eight";
                case 9: return "nine";
                default: throw new ArgumentOutOfRangeException("The value was not in the range [0...9].");
            }
        }
    }
}
