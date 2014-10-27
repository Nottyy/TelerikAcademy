using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EightNinthAndTenthTasksGenericMatrix
{
    public class MatrixException : SystemException
    {
        public MatrixException() { }
        public MatrixException(string message) : base(message) { }
        public MatrixException(string message, Exception innerException) : base(message, innerException) { }
    }
}
