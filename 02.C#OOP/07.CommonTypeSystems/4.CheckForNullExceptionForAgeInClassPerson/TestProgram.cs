using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckForNullExceptionForAgeInClassPerson
{
    public class TestProgram
    {
        static void Main()
        {
            Person stancho = new Person("stancho", 123);
            Console.WriteLine(stancho);
            //stancho.Age = 151;
            //Console.WriteLine(stancho);
            stancho.Age = null;
            Console.WriteLine(stancho);
        }
    }
}
