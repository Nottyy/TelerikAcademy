//Using the extension methods OrderBy() and ThenBy() with lambda expressions sort the students by first name and last name in descending order. Rewrite the same with LINQ.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderStudents
{
    class OrderStudents
    {
        static void Main()
        {
            var students = new[]
            {
                new{firstName = "Petkan", lastName = "Ivanov", age = 18},
                new{firstName = "Gosho", lastName = "Petrow", age = 99},
                new{firstName = "Asparuh", lastName= "Iankov", age = 20},
                new{firstName = "Asparuh", lastName = "Penev", age = 33}
            };

            // LINQ
            var stOrder = from student in students orderby student.firstName, student.lastName select student;

            foreach (var st in stOrder)
            {
                Console.WriteLine(st.firstName + " " + st.lastName);
            }

            Console.WriteLine();
            // Lambda

            var studentsOrder = students.OrderBy(st => st.firstName).ThenBy(st => st.lastName);

            foreach (var st in studentsOrder)
            {
                Console.WriteLine(st.firstName + " " + st.lastName);
            }
        }
    }
}
