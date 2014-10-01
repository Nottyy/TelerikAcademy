using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animals
{
    public class AnimalsTestProgram
    {
        static void Main()
        {
            Frog[] frogs = 
            { 
                new Frog(2, "Pesho", "male"),
                new Frog(3, "Stamen", "male"),
                new Frog(4, "Ivanka", "female"),
                new Frog(5, "Minka", "female"),
                new Frog(6, "Asparuh", "male"),
                new Frog(7, "Nikodim", "male"),
            };

            Dog[] dogs =
            {
                new Dog(2, "Pesho", "male"),
                new Dog(3, "Stamen", "male"),
                new Dog(22, "Ivanka", "female"),
                new Dog(5, "Minka", "female"),
                new Dog(6, "Asparuh", "male"),
                new Dog(7, "Nikodim", "male"),
            };

            Cat[] cats =
            {
                new Cat(2, "Pesho", "male"),
                new Kitten(3, "Stamen"),
                new TomCat(111, "Ivanka"),
                new Cat(5, "Minka", "female"),
                new TomCat(6, "Asparuh"),
                new TomCat(7, "Nikodim"),
            };

            Console.WriteLine("Average age of dogs " + Animal.Average(dogs));
            Console.WriteLine("Average age of frogs " + Animal.Average(frogs));
            Console.WriteLine("Average age of cats " + Animal.Average(cats));
            Console.WriteLine();

            frogs[1].ProduceSound();
            cats[2].ProduceSound();
            dogs[4].ProduceSound();
        }
    }
}
