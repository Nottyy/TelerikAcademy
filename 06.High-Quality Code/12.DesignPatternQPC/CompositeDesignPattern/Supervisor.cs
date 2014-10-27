using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompositeDesignPattern
{
    public class Supervisor : IEmployee
    {
        private string name;
        private int happiness;

        private List<IEmployee> subordinates = new List<IEmployee>();

        public Supervisor(string name, int happiness)
        {
            this.name = name;
            this.happiness = happiness;
        }
        public void ShowHappiness()
        {
            Console.WriteLine(name + " showed happiness level of " + happiness);
            //show all the subordinate's happiness level
            foreach (IEmployee employee in subordinates)
            {
                employee.ShowHappiness();
            }
        }

        public void AddSubordinate(IEmployee employee)
        {
            subordinates.Add(employee);
        }
    }
}
