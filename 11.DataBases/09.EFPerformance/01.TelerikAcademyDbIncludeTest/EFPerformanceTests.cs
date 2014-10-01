using System;
using System.Diagnostics;
using System.Linq;

namespace TelerikAcademyDbIncludeTest
{
    public class Program
    {
        public static void Main()
        {
            // Uncomment the first task to see the results.

            ////01. Using Entity Framework write a SQL query to select all employees from the Telerik Academy database and later print their name, department and town. Try the both variants: with and without .Include(…). Compare the number of executed SQL statements and the performance.

            var db = new TelerikAcademyEntities();

            //var employees = db.Employees;

            ////With Include.
            //foreach (var employee in employees.Include("Address.Town").Include("Department"))
            //{
            //    Console.WriteLine("Name: {0}, Town: {1}, Department: {2}", employee.FirstName, employee.Address.Town.Name, employee.Department.Name);
            //}

            ////Without Include.
            //foreach (var employee in employees)
            //{
            //    Console.WriteLine("Name: {0}, Town: {1}, Department: {2}", employee.FirstName, employee.Address.Town.Name, employee.Department.Name);
            //}

            ////In the first case, using the include extension, there is only one sql query. 
            ////In the second case, we can see in the profiler, that the program is executing a query for every single employee, which is slow and unefficient.


            //02. Using Entity Framework write a query that selects all employees from the Telerik Academy database, then invokes ToList(), then selects their addresses, then invokes ToList(), then selects their towns, then invokesToList() and finally checks whether the town is "Sofia". Rewrite the same in more optimized way and compare the performance.

            var sw = new Stopwatch();
            sw.Start();

            var slowQuery = db.Employees.ToList()
                            .Select(a => a.Address).ToList()
                            .Select(t => t.Town).ToList()
                            .Where(t => t.Name == "Sofia"); // made ~1000 queries
            foreach (var item in slowQuery)
            {
                Console.WriteLine(item.Name);
            }

            sw.Stop();
            Console.WriteLine("-------------------------------");
            Console.WriteLine("Elapsed time -> {0}", sw.Elapsed);
            Console.WriteLine("-------------------------------");

            sw.Reset();
            sw.Start();

            var fastQuery = db.Employees
                            .Select(a => a.Address)
                            .Select(t => t.Town)
                            .Where(t => t.Name == "Sofia"); // made 2 queries
            foreach (var item in fastQuery)
            {
                Console.WriteLine(item.Name);
            }

            sw.Stop();
            Console.WriteLine("-------------------------------");
            Console.WriteLine("Elapsed time -> {0}", sw.Elapsed);
            Console.WriteLine("-------------------------------");
        }
    }
}
