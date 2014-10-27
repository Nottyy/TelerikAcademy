using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsSystem
{
    [ComplexType]
    public class StudentContactInfo
    {
        [Column("E-mail")]
        public string Email { get; set; }

        [Column("Skype")]
        public string Skype { get; set; }

        [Column("Facebook")]
        public string Facebook { get; set; }
    }
}
