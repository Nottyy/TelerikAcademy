using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsTasks9_16
{
    public class Test
    {
        static void Main()
        {
            List<Student> students = new List<Student>()
            {
                new Student("Pavel", "Apostolov", "johnSmith@gmail.com", "(4441)-453-341", 2102, 5, new List<byte>() {5, 5, 4, 6, 4}),
                new Student("Stamen", "Krantev", "peshoto@mail.bg", "(3592)-923-23-11", 1206, 2, new List<byte>() {6, 6, 3, 5}),
                new Student("Jessica", "Parker", "jessTheMess@yahoo.com", "(9922)-23-44-11", 5305, 3, new List<byte>() {3, 5, 5, 5}),
                new Student("Asen", "Kalinov", "kalinov@gmail.com", "(35943)-23-122-12", 3401, 2, new List<byte>() {4, 5, 5, 3}),
                new Student("Jamie", "Trent", "theTrend@sugar.info", "(3233)-145-74-31", 2306, 6, new List<byte>() {6, 6, 2, 5}),
                new Student("Georgi", "Milenkov", "tomahawk@abv.bg", "(3592)-981-62-11", 1111, 9, new List<byte>() {2, 6, 6, 6, 2})
            };
            
            // Task 09 - Select only the students that are from group number 2. Use LINQ query. Order the students by FirstName.
            //Task09(students);

            // Task 10 - Implement the previous using the same query expressed with extension methods.
            //Task10(students);

            // Task 11 - Extract all students that have email in abv.bg. Use string methods and LINQ.
            Task11(students);

            // Task 12 - Extract all students with phones in Sofia. Use LINQ.
            //Task12(students);

            // Task 13 - Select all students that have at least one mark Excellent (6) into a new anonymous class that has properties – FullName and Marks. Use LINQ.
            //Task13(students);

            // Task 14 - Write down a similar program that extracts the students with exactly  two marks "2". Use extension methods.
            //Task14(students);

            // Task 15 - Extract all Marks of the students that enrolled in 2006. (The students from 2006 have 06 as their 5-th and 6-th digit in the FN).
            //Task15(students);

            // Task 16 - *  Create a class Group with properties GroupNumber and DepartmentName. Introduce a property Group in the Student class. Extract all students from                                     "Mathematics" department. Use the Join operator.
            //Task16(students);             

        }

        private static void Task16(List<Student> students)
        {
            List<Group> groups = new List<Group>()
            {
                new Group(1, "Physics"),
                new Group(2, "Arts"),
                new Group(3, "Mathematics"),
                new Group(4, "Law"),
                new Group(5, "Medicine"),
                new Group(6, "Biology"),
            };

            var StudentsFromGroupMathematics = from student in students
                                               join grp in groups on student.GroupNumber equals grp.GroupNumber
                                               where grp.DepartmentName == "Mathematics"
                                               select student;

            foreach (var student in StudentsFromGroupMathematics)
            {
                Console.WriteLine(student.FirstName + " " + student.Lastname + " " + student.GroupNumber);
            }
            Console.WriteLine();
        }

        private static void Task15(List<Student> students)
        {
            var extractAllMarks =
                from student in students
                where student.FacultyNumber.ToString()[2] == '0'
                      && student.FacultyNumber.ToString()[3] == '6'
                select student.Marks;

            Console.WriteLine("Task 15----Marks of students enrolled in 2006 with LINQ query-----");
            foreach (var stud in extractAllMarks)
            {
                Console.WriteLine(string.Join(", ", stud));
            }
            Console.WriteLine();
        }

        private static void Task14(List<Student> students)
        {
            var twoPoorMarks = students.Where(x => x.Marks.FindAll(y => y == 2).Count == 2);

            Console.WriteLine("Task 14----Students with exactly 2 poor marks with extensions-----");
            foreach (var stud in twoPoorMarks)
            {
                Console.WriteLine(stud.FirstName + " " + stud.Lastname + "->" + string.Join(" ", stud.Marks));
            }
            Console.WriteLine();
        }

        private static void Task13(List<Student> students)
        {
            var oneExcellentMark =
                from student in students
                where student.Marks.Contains(6)
                select new { FullName = student.FirstName + " " + student.Lastname, Marks = student.Marks };

            Console.WriteLine("-----Students with at least one 6 mark with LINQ query-----");
            foreach (var stud in oneExcellentMark)
            {
                Console.WriteLine(stud.FullName + "->" + string.Join(" ", stud.Marks));
            }
            Console.WriteLine();
        }

        private static void Task12(List<Student> students)
        {
            var phonesInSofia =
                from student in students
                where student.TelNumber.IndexOf("(3592)") != -1
                select student;

            Console.WriteLine("Task 12-----Students with telephones from Sofia with LINQ query-----");
            foreach (var stud in phonesInSofia)
            {
                Console.WriteLine(stud.FirstName + " " + stud.Lastname + " " + stud.TelNumber);
            }
            Console.WriteLine();
        }

        private static void Task11(List<Student> students)
        {
            Console.WriteLine();
            var emailAtAbv = students.Where(st => st.Email.Split('@').Last() == "abv.bg");
                //from student in students
                //where student.Email.Split('@').Last() == "abv.bg"
                //select student;

            Console.WriteLine("Task 11---Students with email at abv.bg with LINQ query-----");
            foreach (var stud in emailAtAbv)
            {
                Console.WriteLine(stud.FirstName + " " + stud.Lastname + " " + stud.Email);
            }
            Console.WriteLine();
        }

        private static void Task09(List<Student> students)
        {

            var stundentsGroupTwo = students.Where(st => st.GroupNumber == 2).OrderBy(st => st.FirstName);
                //from student in students
                //where student.GroupNumber == 2
                //orderby student.FirstName
                //select student;

            Console.WriteLine("Task 09----Group 2 with LINQ query-----");
            foreach (var stud in stundentsGroupTwo)
            {
                Console.WriteLine(stud.FirstName + " " + stud.Lastname + " " + stud.GroupNumber);
            }
            Console.WriteLine();
        }

        private static void Task10(List<Student> students)
        {
            

            var orderByGroup = students.Where(st => st.GroupNumber == 2).OrderBy(s => s.FirstName);
            Console.WriteLine("Task 10----Group 2 with extension-----");
            foreach (var stud in orderByGroup)
            {
                Console.WriteLine(stud.FirstName + " " + stud.Lastname + " " + stud.GroupNumber);
            }
        }
    }
}
