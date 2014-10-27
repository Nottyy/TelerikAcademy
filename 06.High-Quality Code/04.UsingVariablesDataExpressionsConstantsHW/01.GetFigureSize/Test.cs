using System;

namespace GetFigureSize
{
    public class Test
    {
        public static void Main()
        {
            double width = 54.5;
            double height = 12.1;
            Size testFigureSize = new Size(width, height);

            double angleOfRotation = 22.44;
            Size calculationOfSize = Size.CalculateSize(testFigureSize, angleOfRotation);
        }
    }
}
