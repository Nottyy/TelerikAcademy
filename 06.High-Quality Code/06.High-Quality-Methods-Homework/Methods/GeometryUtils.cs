namespace Utils
{
    using System;

    public static class GeometryUtils
    {
        public static double CalcTriangleArea(double a, double b, double c)
        {
            if (a <= 0 || b <= 0 || c <= 0)
            {
                throw new ArgumentException("Side lengths must be positive.");
            }

            if (!FormTriangle(a, b, c))
            {
                throw new ArgumentOutOfRangeException(
                    "A triangle cannot be formed by the given three lines " +
                    "if any of them is longer than the sum of the other two.");
            }
           
            double semiPerimeter = (a + b + c) / 2;
            double area = Math.Sqrt(semiPerimeter * (semiPerimeter - a) * (semiPerimeter - b) * (semiPerimeter - c));

            return area;
        }

        public static double CalcDistance(double x1, double y1, double x2, double y2)
        {
            double distance = Math.Sqrt(((x1 - x2) * (x1 - x2)) + ((y1 - y2) * (y1 - y2)));

            return distance;
        }

        public static bool IsLineVertical(double x1, double y1, double x2, double y2)
        {
            if (PointsCoincide(x1, y1, x2, y2))
            {
                throw new ArgumentException("The points shouldn't coincide. A single point cannot define a line.");
            }

            return x1 == x2;
        }

        public static bool IsLineHorizontal(double x1, double y1, double x2, double y2)
        {
            if (PointsCoincide(x1, y1, x2, y2))
            {
                throw new ArgumentException("The points shouldn't coincide. A single point cannot define a line.");
            }

            return y1 == y2;
        }

        private static bool FormTriangle(double a, double b, double c)
        {
            return a + b > c && a + c > b && b + c > a;
        }

        private static bool PointsCoincide(double x1, double y1, double x2, double y2)
        {
            return x1 == x2 && y1 == y2;
        }
    }
}
