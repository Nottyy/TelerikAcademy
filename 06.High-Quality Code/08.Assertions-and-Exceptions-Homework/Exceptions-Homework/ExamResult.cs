namespace ExceptionsHomework
{
    using System;

    public class ExamResult
    {
        private int grade;
        private int minGrade;
        private int maxGrade;
        private string comments;

        public int Grade
        {
            get { return grade; }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Grade must be positive number");
                }
                grade = value;
            }
        }

        public int MinGrade
        {
            get { return minGrade; }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Min grade must be positive number");
                }
                minGrade = value;
            }
        }

        public int MaxGrade
        {
            get { return maxGrade; }
            private set
            {
                if (value <= minGrade)
                {
                    throw new ArgumentOutOfRangeException("Max grade must be positive number");
                }
                maxGrade = value;
            }
        }

        public string Comments
        {
            get { return comments; }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Commnent must have almoust one charackter.");
                }
                comments = value;
            }
        }

        public ExamResult(int grade, int minGrade, int maxGrade, string comments)
        {
            this.Grade = grade;
            this.MinGrade = minGrade;
            this.MaxGrade = maxGrade;
            this.Comments = comments;
        }
    }
}