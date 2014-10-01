using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvalidRangeException
{
    public class InvalidRangeException<T> : Exception
    {
        private T minValue;
        private T maxValue;
        private T outRangeValue;

        public T MinValue { get { return this.minValue; } set { this.minValue = value; } }
        public T MaxValue { get { return this.maxValue; } set { this.maxValue = value; } }
        public T OutRangeValue { get { return this.outRangeValue; } set { this.outRangeValue = value; } }

        public InvalidRangeException(string message, T outRangeValue, T minValue, T maxValue, Exception innerException = null)
            : base(message, innerException)
        {
            this.OutRangeValue = outRangeValue;
            this.MaxValue = maxValue;
            this.MinValue = minValue;
        }

        public InvalidRangeException()
        {
        }

        public InvalidRangeException(string message, Exception innerException = null)
            : this(message, default(T), innerException)
        {
        }

        public InvalidRangeException(string message, T outRangeValue, Exception innerException = null)
            : this(message, outRangeValue, default(T), default(T), innerException)
        {
        }
    }
}
