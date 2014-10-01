using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School
{
    public class School
    {
        Dictionary<string, SchoolClass> schoolClasses;

        public School()
        {
            schoolClasses = new Dictionary<string, SchoolClass>();
        }

        public void AddClass(SchoolClass newClass)
        {
            if (schoolClasses.ContainsKey(newClass.GetUnqID))
            {
                throw new ArgumentException("Existing class");
            }
            else
            {
                schoolClasses.Add(newClass.GetUnqID, newClass);
            }
        }

        public List<SchoolClass> ReturnAllClasses()
        {
            var allClasses = schoolClasses.Select(sc => sc.Value).ToList();
            return allClasses;
        }

        public SchoolClass GetClassByID(string key)
        {
            return schoolClasses[key];
        }

        public int GetStudentsInClass(string key)
        {
            return schoolClasses[key].GetNumberOfStudents;
        }
    }
}
