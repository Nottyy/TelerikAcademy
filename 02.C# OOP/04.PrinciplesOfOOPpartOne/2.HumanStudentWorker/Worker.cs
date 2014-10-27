using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanStudentWorker
{
    public class Worker : Human
    {
        private double weekSalary;
        private int workHoursPerDay;

        public double WeekSalary
        {
            get
            {
                return this.weekSalary;
            }
        }

        public int WorkHoursPerDay
        {
            get
            {
                return this.workHoursPerDay;
            }
        }

        public Worker(string firstName, string lastName, double weekSalary, int workHoursPerDay)
            : base(firstName, lastName)
        {
            this.workHoursPerDay = workHoursPerDay;
            this.weekSalary = weekSalary;
        }

        public double MoneyPerHour()
        {
            return weekSalary / (workHoursPerDay * 5);
        }
    }
}
