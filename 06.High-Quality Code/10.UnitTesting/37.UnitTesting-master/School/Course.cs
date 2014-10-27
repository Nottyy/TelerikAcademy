namespace Schools
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Course
    {
        public const int MaxNumberOfStudentsInCourse = 30;

        private string name;
        private List<Student> studentsList;

        public Course(string name)
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
                    throw new ArgumentNullException("Please enter a course name! The filed cannot be null or empty!");
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

        public void Join(Student student)
        {
            if (this.IsStudentFound(student))
            {
                throw new ArgumentException(
                    string.Format(
                    "The student {0} {1} has already joined this course!", 
                    student.StudentId, 
                    student.Name));
            }
            else if (this.IsCourseFull())
            {
                throw new ArgumentOutOfRangeException("The course is full at the moment and doesn't accept new students!");
            }
            else
            {
                this.StudentsList.Add(student);
            }
        }

        public void Leave(Student student)
        {
            if (this.IsStudentFound(student))
            {
                this.StudentsList.Remove(student);
            }
            else
            {
                throw new ArgumentException(
                    string.Format(
                    "The student {0} {1} cannot leave the course because he/she hasn't joined this course!",
                    student.StudentId,
                    student.Name));               
            }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.AppendFormat("Course: {0}", this.Name);
            result.AppendLine();
            if (this.StudentsList != null)
            {
                result.AppendFormat("Subscribed students");
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

        private bool IsCourseFull()
        {
            if (this.StudentsList == null)
            {
                return false;
            }
            else if (this.StudentsList.Count >= MaxNumberOfStudentsInCourse)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
