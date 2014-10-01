using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanStudentWorker
{
    public abstract class Human
    {
        private string firstName, lastName;

        public string FirstName
        {
            get { return this.firstName; }
        }

        public string LastName
        {
            get { return this.lastName; }
        }

        public Human(string firstName, string lastName)
        {
            this.firstName = firstName;
            this.lastName = lastName;
        }
    }
}
