namespace ExceptionsHomework
{
    using System;

    public class CSharpExam : Exam
    {
        private int score;
        public int Score
        {
            get
            {
                return this.score;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("The score cannot be a negative number!");
                }

                score = value;
            }
        }

        public CSharpExam(int score)
        {
            this.Score = score;
        }

        public override ExamResult Check()
        {
            if (Score < 0 || Score > 100)
            {
                throw new InvalidOperationException("The score must be in the range 0-100");
            }
            else
            {
                return new ExamResult(this.Score, 0, 100, "Exam results calculated by score.");
            }
        }
    }
}