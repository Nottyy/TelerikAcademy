using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wintellect.PowerCollections;

namespace _06.Phonebook
{
    public class PhonebookProcess
    {
        MultiDictionary<string, PhonebookEntry> firstNames;
        MultiDictionary<string, PhonebookEntry> middleNames;
        MultiDictionary<string, PhonebookEntry> lastNames;
        MultiDictionary<string, PhonebookEntry> towns;
        MultiDictionary<string, PhonebookEntry> numbers;

        public PhonebookProcess(List<PhonebookEntry> entries)
        {
            firstNames = new MultiDictionary<string, PhonebookEntry>(true);
            middleNames = new MultiDictionary<string, PhonebookEntry>(true);
            lastNames = new MultiDictionary<string, PhonebookEntry>(true);
            towns = new MultiDictionary<string, PhonebookEntry>(true);
            numbers = new MultiDictionary<string, PhonebookEntry>(true);

            foreach (var entry in entries)
            {
                firstNames.Add(new KeyValuePair<string, ICollection<PhonebookEntry>>
                    (entry.FirstName, new PhonebookEntry[] { entry }));
                middleNames.Add(new KeyValuePair<string, ICollection<PhonebookEntry>>
                    (entry.MiddleName, new PhonebookEntry[] { entry }));
                lastNames.Add(new KeyValuePair<string, ICollection<PhonebookEntry>>
                    (entry.LastName, new PhonebookEntry[] { entry }));
                towns.Add(new KeyValuePair<string,ICollection<PhonebookEntry>>
                    (entry.Town, new PhonebookEntry[] { entry }));
            }
        }

        public List<PhonebookEntry> Find(string name)
        {
            List<PhonebookEntry> foundEntries = new List<PhonebookEntry>();

            foundEntries.AddRange(firstNames[name]);
            foundEntries.AddRange(middleNames[name]);
            foundEntries.AddRange(lastNames[name]);

            return foundEntries;
        }

        public List<PhonebookEntry> Find(string name, string town)
        {
            List<PhonebookEntry> foundEntries = new List<PhonebookEntry>();

            ICollection<PhonebookEntry> entry = firstNames[name];
            foundEntries.AddRange(entry.Where(x => x.Town == town));

            entry = middleNames[name];
            foundEntries.AddRange(entry.Where(x => x.Town == town));

            entry = lastNames[name];
            foundEntries.AddRange(entry.Where(x => x.Town == town));

            return foundEntries;
        }
    }
}
