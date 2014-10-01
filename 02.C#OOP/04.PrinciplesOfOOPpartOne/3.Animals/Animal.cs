using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animals
{
    public abstract class Animal
    {
        public int Age { get; set; }
        public string Name { get; set; }
        public string Sex { get; set; }

        public Animal(int age, string name, string sex)
        {
            this.Age = age;
            this.Name = name;
            this.Sex = sex;
        }

        public static double Average(Animal[] animal)
        {
            double sum = 0;
            foreach (var an in animal)
            {
                sum += an.Age;
            }

            return sum / animal.Length;
        }
    }
}
