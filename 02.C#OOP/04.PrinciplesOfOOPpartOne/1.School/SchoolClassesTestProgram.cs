using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School
{
    class SchoolClassesTestProgram
    {
        static void Main()
        {
            
            List<Discipline> listOfDisciplines = new List<Discipline>();
            listOfDisciplines.Add(new Discipline("Physics", 10, 5));
            listOfDisciplines.Add(new Discipline("Football", 14, 53));
            listOfDisciplines.Add(new Discipline("Chemistry", 11, 2));
            listOfDisciplines.Add(new Discipline("Biology", 1, 20));
            listOfDisciplines.Add(new Discipline("Geography", 1, 5));

            List<Teacher> listOfTeachers = new List<Teacher>();
            listOfTeachers.Add(new Teacher("Pirinka", "Koleva", listOfDisciplines[4]));
            listOfTeachers[0].AddDiscipline(listOfDisciplines[2]);

            listOfTeachers.Add(new Teacher("Asparuh", "Senkov", listOfDisciplines[1]));
            listOfTeachers[1].AddDiscipline(listOfDisciplines[4]);

            listOfTeachers.Add(new Teacher("Pavel", "Apostolov", listOfDisciplines[0]));
            listOfTeachers[2].AddDiscipline(listOfDisciplines[3]);


            List<Student> allStudents = new List<Student>();
            allStudents.Add(new Student("ttt", "mmm", 1));
            allStudents.Add(new Student("mmm", "KKK", 2));
            allStudents.Add(new Student("ppp", "yyy", 3));
            allStudents.Add(new Student("aaa", "bbb", 4));
            allStudents.Add(new Student("www", "eee", 5));
            allStudents.Add(new Student("rrr", "ccc", 6));
            allStudents.Add(new Student("sss", "qqq", 7));
            allStudents.Add(new Student("zzz", "xxx", 8));

            List<SchoolClass> classes = new List<SchoolClass>();
            classes.Add(new SchoolClass("12a", new Teacher[] { listOfTeachers[0], listOfTeachers[1] },
                new Student[] { allStudents[0], allStudents[1], allStudents[2], allStudents[3] }));
            classes.Add(new SchoolClass("1a", new Teacher[] { listOfTeachers[2], listOfTeachers[0] },
                new Student[] { allStudents[5], allStudents[6], allStudents[7] }));

            School school = new School();
            school.AddClass(classes[0]);
            school.AddClass(classes[1]);

            SchoolClass getClass = school.GetClassByID("12a");
            Console.WriteLine("Original class: {0} \nNumber of students: {1}", getClass.GetUnqID, getClass.GetNumberOfStudents);
            getClass.AddStudent(allStudents[6]);
            Console.WriteLine("\nAdded a student to a class -\nclass: {0} \nNumber of students: {1} \nNumber of Teachers: {2}",
                getClass.GetUnqID, getClass.GetNumberOfStudents, getClass.GetNumberOfTeachers);
            getClass.RemoveStudent(allStudents[0]);
            Console.WriteLine("\nRemoved a student -\nclass: {0} \nstudents: {1}", getClass.GetUnqID, getClass.GetNumberOfStudents);
            getClass.Comment = "avoid eye contact";
            Console.WriteLine("\nClass: {0} \nNumber of students: {1}\nComment: {2}", getClass.GetUnqID, getClass.GetNumberOfStudents, getClass.Comment);

        }
    }
}
