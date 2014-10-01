namespace SoftwareAcademy
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    public abstract class Course
    {
        private string name;
        private string teacherName;
        private IList<string> students { get; set; }

        public string Name
        {
            get { return this.name; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Course name must have at least one letter");
                }
                this.name = value;
            }
        }
        public string TeacherName
        {
            get { return this.teacherName; }
            set { this.teacherName = value; }
        }

        public IList<string> Students
        {
            get { return new ReadOnlyCollection<string>(this.students); }
            set
            {
                this.students = new List<string>();
                foreach (var item in value)
                {
                    this.students.Add(item);
                }
            }
        }

        public Course(string name)
            : this(name, null, new List<string>())
        {
        }

        public Course(string name, string teacherName)
            : this(name, teacherName, new List<string>())
        {
        }

        public Course(string name, string teacherName, IList<string> students)
        {
            this.Name = name;
            this.TeacherName = teacherName;
            this.Students = students;
        }

        public void AddStudent(string student)
        {
            if (this.students == null)
            {
                this.students = new List<string>();
            }
            this.students.Add(student);
        }

        protected string GetStudentsAsString()
        {
            if (this.Students == null || this.Students.Count == 0)
            {
                return "{ }";
            }
            else
            {
                return "{ " + string.Join(", ", this.Students) + " }";
            }
        }
    }
}