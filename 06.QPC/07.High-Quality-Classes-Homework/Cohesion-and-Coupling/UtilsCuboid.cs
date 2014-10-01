namespace RefactoringCohesionAndCoupling
{
    using System;
    using System.Collections.Generic;

    public class UtilsCuboid
    {
        private double width;
        private double height;
        private double depth;

        public double Width
        {
            get { return width; }
            set
            {
                if (value > 0)
                {
                    width = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Width of the Cube must be positive number.");
                }
            }
        }

        public double Height
        {
            get { return height; }
            set
            {
                if (value > 0)
                {
                    height = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Height of the Cube must be positive number.");
                }
            }
        }

        public double Depth
        {
            get { return depth; }
            set
            {
                if (value > 0)
                {
                    depth = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Depth of the Cube must be positive number.");
                }
            }
        }

        public UtilsCuboid(double width, double height, double depth)
        {
            this.Width = width;
            this.Height = height;
            this.Depth = depth;
        }

        public double CalcVolume()
        {
            double volume = this.Width * this.Height * this.Depth;
            return volume;
        }

        public double CalcDiagonalXYZ()
        {
            double distance = UtilsGeometry.CalcDistance3D(0, 0, 0, this.Width, this.Height, this.Depth);
            return distance;
        }

        public double CalcDiagonalXY()
        {
            double distance = UtilsGeometry.CalcDistance2D(0, 0, this.Width, this.Height);
            return distance;
        }

        public double CalcDiagonalXZ()
        {
            double distance = UtilsGeometry.CalcDistance2D(0, 0, this.Width, this.Depth);
            return distance;
        }

        public double CalcDiagonalYZ()
        {
            double distance = UtilsGeometry.CalcDistance2D(0, 0, this.Height, this.Depth);
            return distance;
        }
    }
}