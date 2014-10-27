namespace Schools
{
    using System;
    using System.Text;

    public class Student
    {
        private string name;
        private int studentId;

        public Student(string name, int studentID)
        {
            this.Name = name;
            this.StudentId = studentID;
        }

        public string Name
        {
            get 
            { 
                return this.name; 
            }

            set 
            {
                if (!string.IsNullOrEmpty(value))
                {
                    this.name = value; 
                }
                else
                {
                    throw new ArgumentNullException("Please enter a student name! The filed cannot be null or empty!");
                }
            }
        }
        
        public int StudentId
        {
            get 
            { 
                return this.studentId; 
            }

            set 
            {
                if (value >= 10000 && value <= 99999)
                {
                    this.studentId = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("The student ID should be a number in the range [10000, 99999]!");
                } 
            }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.AppendFormat("{0} {1}", this.StudentId, this.Name);

            return result.ToString();
        }
    }
}
