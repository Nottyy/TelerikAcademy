using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School
{
    public class SchoolClass
    {
        // Fields

        private string uniqueTextId;
        private string commentOfClass;
        private List<Teacher> setOfTeachers;
        private List<Student> setOfStudents;

        // Constructors
        public SchoolClass(string unqID)
        {
            this.uniqueTextId = unqID;
            this.commentOfClass = string.Empty;
            setOfStudents = new List<Student>();
            setOfTeachers = new List<Teacher>();
        }

        public SchoolClass(string unqID, Teacher[] teachers, Student[] students)
        {
            this.uniqueTextId = unqID;
            this.commentOfClass = string.Empty;
            setOfStudents = new List<Student>();
            setOfTeachers = new List<Teacher>();

            foreach (var teacher in teachers)
            {
                setOfTeachers.Add(teacher);
            }
            foreach (var student in students)
            {
                setOfStudents.Add(student);
            }
        }

        public SchoolClass(string unqID, Teacher[] teachers, Student[] students, string comment)
            : this(unqID, teachers, students)
        {
            this.commentOfClass = comment;
        }

        // Properties

        public string GetUnqID
        {
            get
            {
                return this.uniqueTextId;
            }
        }

        public string Comment
        {
            get { return this.commentOfClass; }
            set { this.commentOfClass = value; }
        }

        public int GetNumberOfTeachers
        {
            get { return setOfTeachers.Count; }
        }

        public int GetNumberOfStudents
        {
            get { return setOfStudents.Count; }
        }

        // Methods

        public void AddStudent(Student student)
        {
            if (setOfStudents.Contains(student))
            {
                throw new ArgumentException("Existing student");
            }
            else
            {
                setOfStudents.Add(student);
            }
        }

        public void RemoveStudent(Student student)
        {
            if (!setOfStudents.Contains(student))
            {
                throw new ArgumentException("There is no such student!");
            }
            else
            {
                setOfStudents.Remove(student);
            }
        }

        public void AddTeacher(Teacher teacher)
        {
            if (setOfTeachers.Contains(teacher))
            {
                throw new ArgumentException("Existing teacher");
            }
            else
            {
                setOfTeachers.Add(teacher);
            }
        }

        public void RemoveTeacher(Teacher teacher)
        {
            if (!setOfTeachers.Contains(teacher))
            {
                throw new ArgumentException("There is no such teacher!");
            }
            else
            {
                setOfTeachers.Remove(teacher);
            }
        }

    }
}
