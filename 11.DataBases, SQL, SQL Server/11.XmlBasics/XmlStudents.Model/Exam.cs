using System.Collections.Generic;
namespace XmlStudents.Model
{
    public class Exam
    {
        private ICollection<Student> students;

        public Exam()
        {
            this.students = new HashSet<Student>();
        }

        public int ExamId { get; set; }

        public string Name { get; set; }

        public string Tutor { get; set; }

        public double Score { get; set; }

        public virtual ICollection<Student> Students
        {
            get
            {
                return this.students;
            }
            set
            {
                this.students = value;
            }
        }
    }
}
