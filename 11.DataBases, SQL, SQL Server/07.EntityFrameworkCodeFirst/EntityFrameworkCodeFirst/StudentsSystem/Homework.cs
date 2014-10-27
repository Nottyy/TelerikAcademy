using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsSystem
{
    public class Homework
    {
        public int Id { get; set; }

        [MaxLength(50)]
        public string Content { get; set; }

        //public DateTime TimeSent { get; set; }

        public int CoursesId { get; set; }

        public virtual Courses Course { get; set; }

        public int StudentId { get; set; }

        public virtual Student Student { get; set; }
    }
}
