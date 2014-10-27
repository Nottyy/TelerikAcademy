namespace XmlStudents.Model
{
    using System;
    using System.Collections.Generic;

    public class Student
    {
        private ICollection<Exam> exams;
        public Student()
        {
            this.exams = new HashSet<Exam>();
        }

        public int StudentId { get; set; }

        public string Name { get; set; }

        public char Sex { get; set; }

        //public DateTime BirthDate { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public string Course { get; set; }

        public string Specialty { get; set; }

        public string FacultyNumber { get; set; }

        public virtual ICollection<Exam> Exams
        {
            get
            {
                return this.exams;
            }
            set
            {
                this.exams = value;
            }
        }
    }
}
