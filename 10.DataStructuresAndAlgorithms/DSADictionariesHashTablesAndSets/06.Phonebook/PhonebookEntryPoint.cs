using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.Phonebook
{
    class PhonebookEntryPoint
    {
        static void Main(string[] args)
        {
            List<PhonebookEntry> entries = new List<PhonebookEntry>();
            entries.Add(new PhonebookEntry("Gosho", "Sofiq", "999", "Goshov", "Ivanov"));
            entries.Add(new PhonebookEntry("Stanko", "Sofiq", "222", "Penchov", "Stamenov"));
            entries.Add(new PhonebookEntry("Gosho", "Vraca", "111", "Bolqrov"));
            entries.Add(new PhonebookEntry("Asparuh", "Tulbuhin", "999"));

            PhonebookProcess phonebookProcess = new PhonebookProcess(entries);
            var findPeopleWithNameGosho = phonebookProcess.Find("Gosho");

            Console.WriteLine("People with name Gosho: ");
            foreach (var entry in findPeopleWithNameGosho)
            {
                Console.WriteLine(entry.ToString());
            }
            Console.WriteLine();

            var findPeopleWithNameGoshoFromSofiq = phonebookProcess.Find("Gosho", "Sofiq");
            Console.WriteLine("People with name Gosho from town Sofiq: ");
            foreach (var entry in findPeopleWithNameGoshoFromSofiq)
            {
                Console.WriteLine(entry.ToString());
            }
            Console.WriteLine();
        }
    }
}
