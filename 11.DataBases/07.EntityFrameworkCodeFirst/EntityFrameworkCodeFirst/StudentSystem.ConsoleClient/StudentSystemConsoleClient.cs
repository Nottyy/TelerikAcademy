namespace StudentSystem.ConsoleClient
{
    using StudentSystem.Data;
    using StudentsSystem;
    using System.Linq;
    using System.Data.Entity;
    using StudentSystem.Data.Migrations;
    using System;
    using System.Collections.Generic;

    public class StudentSystemConsoleClient
    {
        public static void Main()
        {
            var db = new StudentSystemDBContext();

            string[] courses = new string[5] { "Biology", "Chemistry", "Physics", "Maths", "Astronomy"};
            string[] studentFirstNames = new string[5] {"Ivan", "Gancho", "Stavri", "Jechko", "Asparuh"};
            string[] studentLastNames = new string[5] {"Ivanov", "Ganchov", "Stavrov", "Jechkov", "Asparuhov"};

            for (int i = 0; i < 5; i++)
            {
                var course = new Courses
                {
                    Name = courses[i],
                };

                var student = new Student
                {
                    FirstName = studentFirstNames[i],
                    LastName = studentLastNames[i],
                    Age = 20 + i,
                    ContactInfo = new StudentContactInfo
                    {
                        Skype = studentFirstNames[i] + i,
                        Email = studentFirstNames[i] + "@gmail.com",
                        Facebook = studentFirstNames[i] + "_" + studentLastNames[i] + "@facebook.com"
                    },
                    Courses = { course },
                    StudentStatus = i % 2 == 0 ? StudentStatus.Online : StudentStatus.Onsite,
                    Homeworks = new HashSet<Homework> 
                    {
                        new Homework
                        {
                            Content = "Homework" + i,
                            CoursesId = i + 1
                        }
                    },
                };

                db.Students.Add(student);
            }

            db.SaveChanges();

            db.Students.Where(s => s.FirstName == "Jechko").First().Assistant = db.Students.Where(s => s.FirstName == "Asparuh").First();

            db.Courses.Add(new Courses
            {
                Name = "NewCourse",
                Description = "NewCourseInserted",
                Materials = "Materials For the New Course"
            });
            db.SaveChanges();

            foreach (var student in db.Students.ToArray())
            {
                Console.Write("FirstName - {0}, LastName - {1}, Age - {2}, Facebook - {3}", 
                    student.FirstName, student.LastName, student.Age, student.ContactInfo.Facebook);
                if (student.Homeworks.Count() != 0)
                {
                    foreach (var homework in student.Homeworks)
                    {
                        Console.Write(", Homework - {0}", homework.Content);
                    }
                }

                if (student.Courses.Count() != 0)
                {
                    foreach (var course in student.Courses)
                    {
                        Console.Write(", Course - {0}", course.Name);
                    }
                }
                
                Console.WriteLine();
                Console.WriteLine("-----------------------------------------");
            }
        }
    }
}
