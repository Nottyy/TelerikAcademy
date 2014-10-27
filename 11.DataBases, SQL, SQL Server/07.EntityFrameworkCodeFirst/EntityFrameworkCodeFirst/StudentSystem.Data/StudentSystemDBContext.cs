using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentsSystem;
using StudentSystem.Data.Migrations;

namespace StudentSystem.Data
{
    public class StudentSystemDBContext : DbContext
    {
        public StudentSystemDBContext() : base("StudentSystem")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<StudentSystemDBContext, Configuration>());
        }

        public IDbSet<Student> Students { get; set; }

        public IDbSet<Courses> Courses { get; set; }

        public IDbSet<Homework> Homeworks { get; set; }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{

        //    base.OnModelCreating(modelBuilder);
        //}
    }
}
