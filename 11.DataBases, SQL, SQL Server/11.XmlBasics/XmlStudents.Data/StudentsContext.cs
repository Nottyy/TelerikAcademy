namespace XmlStudents.Data
{
    using System.Data.Entity;
    using XmlStudents.Model;
    public class StudentsContext : DbContext
    {
        public StudentsContext() 
            : base("StudentsDb")
        {

        }

        public IDbSet<Student> Students { get; set; }

        public IDbSet<Exam> Exams { get; set; }
    }
}
