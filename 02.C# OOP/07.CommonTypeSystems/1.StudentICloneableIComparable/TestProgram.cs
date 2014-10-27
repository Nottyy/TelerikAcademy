//Define a class Student, which contains data about a student – first, middle and last name, SSN, permanent address, mobile phone e-mail, course, specialty, university, faculty. Use an enumeration for the specialties, universities and faculties. Override the standard methods, inherited by  System.Object: Equals(), ToString(), GetHashCode() and operators == and !=.
//Add implementations of the ICloneable interface. The Clone() method should deeply copy all object's fields into a new object of type Student.
//Implement the  IComparable<Student> interface to compare students by names (as first criteria, in lexicographic order) and by social security number (as second criteria, in increasing order).

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentICloneableIComparable
{
    public class TestProgram
    {
        static void Main()
        {
            Student asparuh = new Student("Asparuh", "Krantev", "Apostolov", 123456789, "Ul.NemaPari",
                8888888, "asparuhcho@abv.bg", 3, Specialties.English, Universities.Lesoto, Faculties.EnglishFaculty);
            Console.WriteLine(asparuh);
            Console.WriteLine();

            // Test Clone
            Student stamat = asparuh.Clone();
            stamat.FirstName = "Nikodim";
            Console.WriteLine(stamat.FirstName);
            Console.WriteLine(asparuh.FirstName);

            // Test CompareTo

            Console.WriteLine(asparuh.CompareTo(stamat));
            stamat.FirstName = "Asparuh";
            Console.WriteLine(asparuh.CompareTo(stamat));
        }
    }
}
