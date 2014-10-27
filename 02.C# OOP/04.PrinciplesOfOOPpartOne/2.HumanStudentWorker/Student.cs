using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanStudentWorker
{
    public class Student : Human
    {
        private double grade;

        public double Grade { get { return this.grade; } }

        public Student(string firstName, string lastName, double grade)
            : base(firstName, lastName)
        {
            this.grade = grade;
        }
    }
}
