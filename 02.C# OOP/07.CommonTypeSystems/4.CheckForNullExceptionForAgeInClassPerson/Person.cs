using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckForNullExceptionForAgeInClassPerson
{

    public class Person
    {
        // fields
        private int? age;
        private string name;

        // properties
        public int? Age
        {
            get
            {
                return this.age;
            }
            set
            {
                if (value < 0 || value > 150)
                {
                    throw new ArgumentException("The age must be a positive number");
                }
                else
                {
                    this.age = value;
                }
            }
        }

        public string Name { get { return this.name; } set { this.name = value; } }

        // constructors
        
        public Person(string name, int? age)
        {
            this.Name = name;
            this.Age = age;
        }

        // method
        public override string ToString()
        {
            if (this.age == null)
            {
                return string.Format("Person name: {0}\nPerson age: Unknown age", this.Name);
            }
            else
            {
                return string.Format("Person name: {0}\nPerson age : {1}", this.Name, this.Age);
            }
        }
    }
}
