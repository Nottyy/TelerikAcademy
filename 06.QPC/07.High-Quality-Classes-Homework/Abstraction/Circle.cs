namespace Figures
{
    using System;

    public class Circle : Figure
    {
        public Circle(double radius)
        {
            this.Radius = radius;
        }

        private double radius;

        public double Radius
        {
            get
            {
                return this.radius;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Radius cannot be negative!");
                }

                this.radius = value;
            }
        }

        public override double CalcPerimeter()
        {
            double perimeter = 2 * Math.PI * this.Radius;
            return perimeter;
        }

        public override double CalcSurface()
        {
            double surface = Math.PI * this.Radius * this.Radius;
            return surface;
        }
    }
}
