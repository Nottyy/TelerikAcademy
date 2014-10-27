//Write a method that from a given array of students finds all students whose first name is before its last name alphabetically. Use LINQ query operators.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class StudentWhoseFirstNameIsAlphabeticallyBeforeLastName
{
    static void Main()
    {
        var students = new[]
            {
                new{firstName = "Petkan", lastName = "Ivanov"},
                new{firstName = "Gosho", lastName = "Petrow"},
                new{firstName = "Chavdar", lastName= "Iankov"},
                new{firstName = "Asparuh", lastName = "Penev"}
            };

        var studentsSelect = from student in students where student.firstName.CompareTo(student.lastName) == -1 select student;

        foreach (var st in studentsSelect)
        {
            Console.WriteLine(st.firstName + " " + st.lastName);
        }
    }
}
