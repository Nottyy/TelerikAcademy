namespace Schools
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class School
    {
        private string name;
        private List<Student> studentsList;

        public School(string name)
        {
            this.Name = name;
            this.StudentsList = new List<Student>();
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
                    throw new ArgumentNullException("Please enter a school name! The filed cannot be null or empty!");
                }
            }
        }
        
        public List<Student> StudentsList
        {
            get 
            { 
                return this.studentsList; 
            }

            protected set 
            { 
                this.studentsList = value; 
            }
        }

        public void AddStudent(Student student)
        {
            if (this.IsStudentFound(student))
            {
                throw new ArgumentException(
                    string.Format(
                    "The student ID {0} already exists in the school's students list! Please choose a differnet student ID for student {1}",
                    student.StudentId,
                    student.Name)); 
            }
            else
            {
                this.StudentsList.Add(student);
            }
        }

        public void RemoveStudent(Student student)
        {
            if (this.IsStudentFound(student))
            {
                this.StudentsList.Remove(student);
            }
            else
            {
                throw new ArgumentException(
                    string.Format(
                    "Student not removed! The student ID {0} for student {1} dosn't exsit in the school's records!",
                    student.StudentId,
                    student.Name));            
            }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.AppendFormat("School: {0}", this.Name);
            result.AppendLine();

            if (this.StudentsList != null)
            {
                result.AppendFormat("Student ID Name");
                result.AppendLine();
                foreach (var student in this.StudentsList)
                {
                    result.AppendLine(student.ToString());
                }
            }

            return result.ToString();
        }

        private bool IsStudentFound(Student student)
        {
            for (int i = 0; i < this.StudentsList.Count; i++)
            {
                if (student.StudentId == this.StudentsList[i].StudentId)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
