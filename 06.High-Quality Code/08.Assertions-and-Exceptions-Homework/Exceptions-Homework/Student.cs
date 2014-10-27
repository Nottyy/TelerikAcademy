
namespace ExceptionsHomework
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class Student
    {
        private string firstName;
        private string lastName;
        private IList<Exam> exams;

        public string FirstName
        {
            get { return firstName; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("First name must have almoust one charackter.");
                }
                firstName = value;
            }
        }

        public string LastName
        {
            get { return lastName; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Last name must have almoust one charackter.");
                }
                lastName = value;
            }
        }

        public IList<Exam> Exams
        {
            get { return exams; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Exam list can't be null");
                }

                if (value.Count == 0)
                {
                    throw new ArgumentOutOfRangeException("Exam list must have at least one exam.");
                }
                exams = value;
            }
        }

        public Student(string firstName, string lastName, IList<Exam> exams)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Exams = exams;
        }


        public IList<ExamResult> CheckExams()
        {
            IList<ExamResult> results = new List<ExamResult>();
            for (int i = 0; i < this.Exams.Count; i++)
            {
                results.Add(this.Exams[i].Check());
            }

            return results;
        }

        public double CalcAverageExamResultInPercents()
        {
            double[] examScore = new double[this.Exams.Count];
            IList<ExamResult> examResults = CheckExams();
            for (int i = 0; i < examResults.Count; i++)
            {
                examScore[i] =
                    ((double)examResults[i].Grade - examResults[i].MinGrade) /
                    (examResults[i].MaxGrade - examResults[i].MinGrade);
            }

            return examScore.Average();
        }
    }
}


