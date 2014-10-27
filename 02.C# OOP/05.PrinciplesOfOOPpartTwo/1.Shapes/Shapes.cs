using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    public abstract class Shapes
    {
        // Fields
        private double width, height;
        
        // Properties
        public double Width
        {
            get
            {
                return this.width;
            }
            protected set
            {
                if (this.width < 0)
                {
                    throw new ArgumentException("Width must be positive number");
                }
                this.width = value;
            }
        }

        public double Height
        {
            get
            {
                return this.height;
            }
            protected set
            {
                if (this.height < 0)
                {
                    throw new ArgumentException("Height must be positive number");
                }
                this.height = value;
            }
        }

        // Constructors
        public Shapes(double width, double height)
        {
            this.width = width;
            this.height = height;
        }
        // Methods
        public abstract double CalculateSurface();
    }
}
