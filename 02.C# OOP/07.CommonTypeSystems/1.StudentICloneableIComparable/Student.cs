using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentICloneableIComparable
{
    public class Student : ICloneable, IComparable<Student>
    {
        // Automatic Properties
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public uint SSN { get; set; }
        public string Adress { get; set; }
        public uint MobilePhone { get; set; }
        public string Email { get; set; }
        public uint Course { get; set; }
        public Specialties Specialty { get; set; }
        public Universities University { get; set; }
        public Faculties Faculty { get; set; }

        // Constructors
        public Student(string firstName, string middleName, string lastName, uint SSN, string adress, uint mobilePhone, string email, uint course, Specialties specialty,
            Universities university, Faculties faculty)
        {
            this.FirstName = firstName;
            this.MiddleName = middleName;
            this.LastName = lastName;
            this.SSN = SSN;
            this.Adress = adress;
            this.MobilePhone = mobilePhone;
            this.Email = email;
            this.Course = course;
            this.Specialty = specialty;
            this.University = university;
            this.Faculty = faculty;
        }

        //Methods

        public override bool Equals(object param)
        {
            Student student = param as Student;

            // Check if we have valid Student object
            if ((object)student == null)
            {
                return false;
            }
            // Compare the reference type member fields
            if (!object.Equals(this.FirstName, student.FirstName))
            {
                return false;
            }
            // Compare the value types member fields
            if (this.MiddleName != student.MiddleName)
            {
                return false;
            }
            if (this.LastName != student.LastName)
            {
                return false;
            }
            if (this.SSN != student.SSN)
            {
                return false;
            }

            return true;
        }

        public static bool operator ==(Student student, Student student1)
        {
            return student.Equals(student1);
        }

        public static bool operator !=(Student student, Student student1)
        {
            return student.Equals(student1);
        }

        public override int GetHashCode()
        {
            return this.FirstName.GetHashCode() ^ this.MiddleName.GetHashCode() ^ this.LastName.GetHashCode() ^ this.SSN.GetHashCode();
        }

        public override string ToString()
        {
            return string.Format("Student Names: \n{0} {1} {2} \nStudent SSN: \n{3} \nAddress: \n{4} \nMobilePhone : {5}\nUniversity: \n{6}", this.FirstName, this.MiddleName, this.LastName, this.SSN,this.Adress , this.MobilePhone, this.University);
        }

        public int CompareTo(Student otherStudent)
        {
            if (this.FirstName != otherStudent.FirstName)
            {
                return string.Compare(this.FirstName, otherStudent.FirstName);
            }
            if (this.MiddleName != otherStudent.MiddleName)
            {
                return string.Compare(this.MiddleName, otherStudent.MiddleName);
            }
            if (this.LastName != otherStudent.LastName)
            {
                return string.Compare(this.LastName, otherStudent.LastName);
            }
            if (this.SSN != otherStudent.SSN)
            {
                return (int)(this.SSN - otherStudent.SSN);
            }
            return 0;
        }

        public Student Clone()
        {
            Student newStudent = new Student(this.FirstName, this.MiddleName, this.LastName, this.SSN, this.Adress,
                this.MobilePhone, this.Email, this.Course, this.Specialty, this.University, this.Faculty);
            return newStudent;
        }
        object ICloneable.Clone()
        {
            return this.Clone();
        }
    }
}
