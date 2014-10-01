using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class FindStudentsWithAgeBetween18and24
{
    static void Main(string[] args)
    {
        var students = new[]
            {
                new{firstName = "Petkan", lastName = "Ivanov", age = 18},
                new{firstName = "Gosho", lastName = "Petrow", age = 99},
                new{firstName = "Chavdar", lastName= "Iankov", age = 20},
                new{firstName = "Asparuh", lastName = "Penev", age = 33}
            };

        var studentsSelect = from student in students where student.age >= 18 && student.age <= 24 select student;

        foreach (var st in studentsSelect)
        {
            Console.WriteLine(st.firstName + " " + st.lastName + " " + st.age);
        }
    }
}

