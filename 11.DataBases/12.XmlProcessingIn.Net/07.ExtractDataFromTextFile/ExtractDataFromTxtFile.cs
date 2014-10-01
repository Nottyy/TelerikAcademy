using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace ExtractDataFromTextFile
{
    public class Program
    {
        public static void Main()
        {
            StreamReader reader = new StreamReader("..\\..\\data.txt", Encoding.UTF8);

            using(reader)
            {
                var line = reader.ReadLine();
                XElement people = new XElement("people");

                string name = "";
                string address = "";
                string phone = "";

                int index = 1;

                while (line != null)
                {
                    if (index % 3 == 1)
                    {
                        name = line;
                    }
                    else if(index % 3 == 2)
                    {
                        address = line;
                    }
                    else
                    {
                        phone = line;

                        var person = new XElement("person");
                        person.Add(new XElement("name", name));
                        person.Add(new XElement("address", address));
                        person.Add(new XElement("phone", phone));
                        people.Add(person);
                    }

                    index++;
                    line = reader.ReadLine();
                }

                Console.WriteLine("Extraction finished!");
                people.Save("..\\..\\personInfo.xml");
            }
        }
    }
}
