
namespace FirstFourTasksPoint3D
{
    using System;

    public static class CalculateDistance
    {
        public static double DistanceCalculation(Point3D firstPoint, Point3D secondPoint)
        {
            double result = Math.Sqrt(((firstPoint.X - secondPoint.X) * (firstPoint.X - secondPoint.X)) +
                                      ((firstPoint.Y - secondPoint.Y) * (firstPoint.Y - secondPoint.Y)) +
                                      ((firstPoint.Z - secondPoint.Z) * (firstPoint.Z - secondPoint.Z)));

            return result;
        }
    }
}
