using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstFourTasksPoint3D
{
    public class Path
    {
        public List<Point3D> path = new List<Point3D>();

        public List<Point3D> Paths
        {
            get
            {
                return this.path;
            }
            private set
            {
                this.path = value;
            }
        }
        public void AddPoint(Point3D point)
        {
            Paths.Add(point);
        }
        public void PrintPathList()
        {
            foreach (var i in path)
            {
                Console.WriteLine("({0},{1},{2})", i.X, i.Y, i.Z);
            }
        }
    }
}
