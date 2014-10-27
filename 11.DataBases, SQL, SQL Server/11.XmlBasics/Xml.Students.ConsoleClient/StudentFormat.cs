using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Xml.Students.ConsoleClient
{
    public class StudentFormat
    {
        [XmlElement("name")]
        public string Name { get; set; }

        [XmlElement("sex")]
        public string Sex { get; set; }
        //[XmlElement("birthdate")]
        //public DateTime Birthdate { get; set; }
        [XmlElement("phone")]
        public string Phone { get; set; }

        [XmlElement("email")]
        public string eMail { get; set; }

        [XmlElement("course")]
        public string Course { get; set; }

        [XmlElement("specialty")]
        public string Specialty { get; set; }

        [XmlElement("faculty-number")]
        public string FacultyNumber { get; set; }

        [XmlArray("exams")]
        public List<ExamFormat> Exams { get; set; }
    }
}
