using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School
{
    public class Teacher : Person
    {
        private List<Discipline> disciplines;
        private string commentOfTeacher;

        public Teacher(string firstName, string lastName)
            : base(firstName, lastName)
        {
            disciplines = new List<Discipline>();
            commentOfTeacher = string.Empty;
        }

        public Teacher(string firstName, string lastName, string comment)
            : base(firstName, lastName)
        {
            disciplines = new List<Discipline>();
            commentOfTeacher = comment;
        }

        public Teacher(string firstName, string lastName, Discipline disc)
            : base(firstName, lastName)
        {
            disciplines = new List<Discipline>();
            disciplines.Add(disc);
            commentOfTeacher = string.Empty;
        }

        public Teacher(string firstName, string lastName, Discipline disc, string comment)
            : base(firstName, lastName)
        {
            disciplines = new List<Discipline>();
            disciplines.Add(disc);
            commentOfTeacher = comment;
        }

        public void AddDiscipline(Discipline disc)
        {
            disciplines.Add(disc);
        }

        public void RemoveDiscipline(Discipline disc)
        {
            disciplines.Remove(disc);
        }

        public string Comment
        {
            get
            {
                return this.commentOfTeacher;
            }
            set
            {
                this.commentOfTeacher = value;
            }
        }
    }
}
