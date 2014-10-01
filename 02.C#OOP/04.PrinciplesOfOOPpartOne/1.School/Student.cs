using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School
{
    public class Student : Person
    {
        private int uniqueClassNumber;
        private string commentOfStudent;

        public Student(string firstName, string lastName, int ucn) : base(firstName, lastName)
        {
            this.uniqueClassNumber = ucn;
            commentOfStudent = string.Empty;
        }

        public Student(string firstName, string lastName, int ucn, string commentOfStudent)
            : base(firstName, lastName)
        {
            this.uniqueClassNumber = ucn;
            this.commentOfStudent = commentOfStudent;
        }

        public int GetUniqueClassNumber
        {
            get
            {
                return this.uniqueClassNumber;
            }
        }

        public string GetCommentOfStudent
        {
            get
            {
                return this.commentOfStudent;
            }
            set
            {
                this.commentOfStudent = value;
            }
        }
    }
}
