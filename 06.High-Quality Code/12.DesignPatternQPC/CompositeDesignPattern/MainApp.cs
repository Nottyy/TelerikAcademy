using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompositeDesignPattern
{
    public class MainApp
    {
        public static void Main()
        {
            Worker Tom = new Worker("Worker Tom", 5);
            Supervisor Mary = new Supervisor("Supervisor Mary", 6);
            Supervisor Jerry = new Supervisor("Supervisor Jerry", 7);
            Supervisor Bob = new Supervisor("Supervisor Bob", 9);
            Worker Jimmy = new Worker("Worker Jimmy", 8);

            //set up the relationships
            Mary.AddSubordinate(Tom); //Tom works for Mary
            Jerry.AddSubordinate(Mary); //Mary works for Jerry
            Jerry.AddSubordinate(Bob); //Bob works for Jerry
            Bob.AddSubordinate(Jimmy); //Jimmy works for Bob

            //Jerry shows his happiness and asks everyone else to do the same
            if (Jerry is IEmployee)
            {
                (Jerry as IEmployee).ShowHappiness();
            }
                
        }
    }
}
