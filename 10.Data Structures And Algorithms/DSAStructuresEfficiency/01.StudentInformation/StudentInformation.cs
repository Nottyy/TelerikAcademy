using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace StudentInformation
{
    public class StudentInformation
    {
        static void Main()
        {
            var students = new SortedDictionary<string, SortedSet<string>>();
            var allEntries = ParseStudentInformation();

            for (int i = 0; i < allEntries.Count; i++)
            {
                var currentStudentInfo = allEntries[i];
                var currentStudentName = currentStudentInfo[0] + " " + currentStudentInfo[1];
                var currentStudentCourse = currentStudentInfo[2];
                if (students.ContainsKey(currentStudentCourse))
                {
                    students[currentStudentCourse].Add(currentStudentName);
                }
                else
                {
                    students.Add(currentStudentCourse, new SortedSet<string> { currentStudentName });
                }
            }

            foreach (var student in students)
            {
                Console.WriteLine("{0} -> {1}", student.Key, string.Join(", ", student.Value));
            }
        }

        static List<string[]> ParseStudentInformation()
        {
            var sr = new StreamReader("..//..//students.txt");
            var allEntries = new List<string[]>();

            using (sr)
            {
                while (!sr.EndOfStream)
                {
                    string currentLine = sr.ReadLine();
                    string[] content = currentLine.Split('|');

                    for (int i = 0; i < content.Length; i++)
                    {
                        content[i] = content[i].Trim();
                    }
                    allEntries.Add(content);
                }
            }

            return allEntries;
        }
    }
}
