using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsSystem
{
    public class Student
    {
        private ICollection<Courses> courses;
        private ICollection<Homework> homeworks;
        private ICollection<Student> trainees;
        public Student()
        {
            this.courses = new HashSet<Courses>();
            this.homeworks = new HashSet<Homework>();
            this.ContactInfo = new StudentContactInfo();
            this.trainees = new HashSet<Student>();
        }

        public int Id { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(20)]
        public string FirstName { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(20)]
        public string LastName { get; set; }

        public int Age { get; set; }

        public StudentContactInfo ContactInfo { get; set; }

        public StudentStatus StudentStatus { get; set; }

        public virtual Student Assistant { get; set; }

        [InverseProperty("Assistant")]
        public virtual ICollection<Student> Trainees
        {
            get
            {
                return this.trainees;
            }
            set
            {
                this.trainees = value;
            }
        }
        public virtual ICollection<Courses> Courses
        {
            get
            {
                return this.courses;
            }
            set
            {
                this.courses = value;
            }
        }

        public virtual ICollection<Homework> Homeworks
        {
            get
            {
                return this.homeworks;
            }
            set
            {
                this.homeworks = value;
            }
        }
    }
}
