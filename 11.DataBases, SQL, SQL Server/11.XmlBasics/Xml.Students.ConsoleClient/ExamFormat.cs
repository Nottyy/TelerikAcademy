using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Xml.Students.ConsoleClient
{
    public class ExamFormat
    {
        [XmlElement("name")]
        public string Name { get; set; }

        [XmlElement("tutor")]
        public string Tutor { get; set; }

        [XmlElement("score")]
        public double Score { get; set; }
    }
}
