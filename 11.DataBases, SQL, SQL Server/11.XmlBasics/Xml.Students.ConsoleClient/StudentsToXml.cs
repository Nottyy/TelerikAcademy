using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Xml.Students.ConsoleClient
{
    [XmlRoot("students")]
    public class StudentsToXml
    {
        [XmlElement("student")]
        public List<StudentFormat> Students { get; set; }
    }
}
