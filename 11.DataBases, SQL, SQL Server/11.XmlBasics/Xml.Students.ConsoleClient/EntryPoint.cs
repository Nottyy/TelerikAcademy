namespace Xml.Students.ConsoleClient
{
    using XmlStudents.Data;
    using XmlStudents.Model;
    using System.Linq;
    using System.Xml.Linq;
    using System.Collections.Generic;
    using System.IO;
    using System.Xml.Serialization;

    public class EntryPoint
    {
        //The xml,schema,xls and html are saved in the '..\..\..\XML_export\test.xml' directory.
        //Delete the xml file before running the main method.
        static void Main()
        {
            var stContext = new StudentsContext();
            PopulateStudentsDb(stContext);
            stContext.SaveChanges();
            StudentsToXml xmlStudents = new StudentsToXml();
            xmlStudents.Students = new List<StudentFormat>();

            ParseStudentData(stContext, xmlStudents);
            SerializeToXml(xmlStudents, @"..\..\..\XML_export\test.xml");

            XmlToHTML.ConverXmlToHtml();
        }

        private static void ParseStudentData(StudentsContext stContext, StudentsToXml xmlStudents)
        {
            stContext.Students.ToList().ForEach(st =>
            {
                var studentFormat = new StudentFormat();
                studentFormat.Name = st.Name;
                studentFormat.eMail = st.Email;
                studentFormat.Course = st.Course;
                studentFormat.FacultyNumber = st.FacultyNumber;
                studentFormat.Phone = st.Phone;
                studentFormat.Specialty = st.Specialty;

                var exams = new List<ExamFormat>();
                st.Exams.ToList().ForEach(e =>
                {
                    var studentExam = new ExamFormat();
                    studentExam.Name = e.Name;
                    studentExam.Score = e.Score;
                    studentExam.Tutor = e.Tutor;

                    exams.Add(studentExam);
                });
                studentFormat.Exams = exams;

                xmlStudents.Students.Add(studentFormat);
            });
        }
        public static void SerializeToXml<T>(T obj, string filePath)
        {
            using (var fileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write))
            {
                var ser = new XmlSerializer(typeof(T));
                var xns = new XmlSerializerNamespaces();
                xns.Add("default","defaultNS");
                ser.Serialize(fileStream, obj, xns);
            }
        }
        static void PopulateStudentsDb(StudentsContext stContext)
        {
            for (int i = 0; i < 10; i++)
            {
                var student = new Student
                {
                    Name = "Minko" + i,
                    Course = "Maths",
                    Phone = "2109" + i,
                    Sex = 'm',
                    Email = "minko.minkov" + i + "@abv.bg",
                    FacultyNumber = "10101010" + i,
                    Specialty = "Economics",
                    Exams =
                    {
                        new Exam 
                        {
                            Name = "Physics" + i,
                            Score = i,
                            Tutor = "Penko" + i
                        }
                    }
                };

                stContext.Students.Add(student);
            }
        }
    }
}
