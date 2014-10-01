using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Employee
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int Rank { get; set; }
    public string Position { get; set; }

}

class Employees
{
    static Dictionary<string, int> posAndRank = new Dictionary<string, int>();

    static void Main()
    {
        int numberOfPos = int.Parse(Console.ReadLine());

        for (int i = 0; i < numberOfPos; i++)
        {
            string[] rawInput = Console.ReadLine().Split(new string[] { " - " }, StringSplitOptions.RemoveEmptyEntries);

            if (!posAndRank.ContainsKey(rawInput[0]))
            {
                posAndRank.Add(rawInput[0], int.Parse(rawInput[1]));
            }
        }

        List<Employee> allWorkers = new List<Employee>();

        int numberOfWorkers = int.Parse(Console.ReadLine());

        for (int i = 0; i < numberOfWorkers; i++)
        {
            string[] rawInput = Console.ReadLine().Split(new string[] { " - " }, StringSplitOptions.RemoveEmptyEntries);
            string[] splittedName = rawInput[0].Split();
            Employee currentEmp = new Employee();
            currentEmp.FirstName = splittedName[0];
            currentEmp.LastName = splittedName[1];
            currentEmp.Position = rawInput[1];
            currentEmp.Rank = posAndRank[currentEmp.Position];

            allWorkers.Add(currentEmp);
        }

        var ebemBabi = allWorkers.OrderByDescending(em => em.Rank).ThenBy(em => em.LastName).ThenBy(em => em.FirstName);

        foreach (var worker in ebemBabi)
        {
            Console.WriteLine("{0} {1}", worker.FirstName, worker.LastName);
        }
    }
}

