using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School
{
    public class Discipline
    {
        private string commentOfDiscipline, name;
        private int lecturesCount, numberOfExercises;

        public Discipline(string name, int lecturesCount, int numOfExercises)
        {
            this.name = name;
            this.lecturesCount = lecturesCount;
            this.numberOfExercises = numOfExercises;
        }

        public Discipline(string name, int lecturesCount, int numOfExercises, string comment)
            : this(name, lecturesCount, numOfExercises)
        {
            this.commentOfDiscipline = comment;
        }

        public string Comment
        {
            get { return this.commentOfDiscipline; }
            set { this.commentOfDiscipline = value; }
        }
    }
}
