using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstFourTasksPoint3D
{
    class FirstFourTasksPoint3D
    {
        static void Main()
        {
            Path path = new Path();
            
            path.AddPoint(new Point3D(1, 222323, 3));
            path.AddPoint(new Point3D(4, 9, 7));
            path.AddPoint(new Point3D(21, 7, 8));
            path.AddPoint(new Point3D(12, 32, 4));
            path.AddPoint(new Point3D(1, 22, 2));

            double distCalc = CalculateDistance.DistanceCalculation(new Point3D(1, 22, 3), new Point3D(2, 223, 4));

            Console.WriteLine(distCalc);

            PathStorage.SavePath(path);

            Path final = PathStorage.LoadPath();
            final.PrintPathList();
            
            Point3D startPoint = Point3D.ReturnZeroCoord;

            Console.WriteLine(startPoint.ToString());
        }
    }
}
