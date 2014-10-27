using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanStudentWorker
{
    public class TestProgramHumanStudentWorker
    {
        static void Main()
        {
            List<Student> students = new List<Student>();
            students.Add(new Student("ASPARUH", "NIKODIMOV", 4.54));
            students.Add(new Student("MILENKO", "PETKOV", 2.54));
            students.Add(new Student("NIKODIM", "STANKOV", 3.54));
            students.Add(new Student("STAMAT", "APOSTOLOV", 4.89));
            students.Add(new Student("STAVRI", "GOUGOV", 6));
            students.Add(new Student("PAVEL", "TONKOV", 3.33));
            students.Add(new Student("TONKO", "PITONKOV", 5.99));
            students.Add(new Student("SENATORA", "KEVORKQN", 4.54));
            students.Add(new Student("ANI", "SALICH", 4.66));
            students.Add(new Student("METODI", "MILADINOVICH", 3.14));

            var orderByGrade = students.OrderBy(st => st.Grade);

            foreach (var stud in orderByGrade)
            {
                Console.WriteLine(stud.FirstName + " " + stud.LastName + " " + stud.Grade);
            }
            Console.WriteLine(); Console.WriteLine();

            List<Worker> workers = new List<Worker>();
            workers.Add(new Worker("ASPARUH", "NIKODIMOV", 234.54, 21));
            workers.Add(new Worker("MILENKO", "PETKOV", 2112.54, 2));
            workers.Add(new Worker("NIKODIM", "STANKOV", 3.54, 2));
            workers.Add(new Worker("STAMAT", "APOSTOLOV", 3234.89, 4));
            workers.Add(new Worker("STAVRI", "GOUGOV", 6, 44));
            workers.Add(new Worker("PAVEL", "TONKOV", 123.33, 1));
            workers.Add(new Worker("TONKO", "PITONKOV", 33335.99, 10));
            workers.Add(new Worker("SENATORA", "KEVORKQN", 1214.54, 11));
            workers.Add(new Worker("ANI", "SALICH", 44.66, 23));
            workers.Add(new Worker("METODI", "MILADINOVICH", 43.14, 55));

            var orderByMoneyPerHour = workers.OrderBy(wks => wks.MoneyPerHour());
            foreach (var worker in orderByMoneyPerHour)
            {
                Console.WriteLine(worker.FirstName + " " + worker.LastName + " " + worker.MoneyPerHour());
            }
            Console.WriteLine(); Console.WriteLine();

            var mergedList = new List<dynamic>();

            foreach (var item in students)
            {
                mergedList.Add(item);
            }
            foreach (var item in workers)
            {
                mergedList.Add(item);
            }

            //var sortedMergeList = from x in mergedList orderby x.FirstName, x.LastName select x;
            var sortedMergeList = mergedList.OrderBy(x => x.FirstName).ThenBy(x => x.LastName);

            foreach (var item in sortedMergeList)
            {
                Console.WriteLine(item.FirstName + " " + item.LastName);
            }
            
        }
    }
}
