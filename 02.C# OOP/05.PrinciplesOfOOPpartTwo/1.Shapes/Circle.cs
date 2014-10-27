using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    public class Circle : Shapes
    {
        private double radius;

        public Circle(double radius)
            : base(radius, height: radius)
        {
            if (radius <= 0)
            {
                throw new ArgumentException("Radius must be > 0");
            }
            else
            {
                this.radius = radius;
            }
        }

        public override double CalculateSurface()
        {
            return Math.PI * radius * radius;
        }
    }
}
