using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    public class ShapesTest
    {
        static void Main()
        {
            Shapes[] shapes = new Shapes[]
            {   new Circle(5.6),
                new Triangle(213,2),
                new Rectangle(2,212.2),
                new Circle(213.22)
            };

            foreach (var shape in shapes)
            {
                Console.WriteLine("Figure: {0} \nSurface: {1}", shape.GetType().Name, shape.CalculateSurface());
            }
        }
    }
}
