namespace ExceptionsHomework
{
    using System;

    public class SimpleMathExam : Exam
    {
        private int problemsSolved;
        public int ProblemsSolved
        {
            get
            {
                return this.problemsSolved;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Solved problem must be positive number.");
                }
                if (value > 10)
                {
                    throw new ArgumentOutOfRangeException("Solved problem must be smaller than maximal problem number.");
                }
                problemsSolved = value;
            }
        }

        public SimpleMathExam(int problemsSolved)
        {
            this.ProblemsSolved = problemsSolved;
        }

        public override ExamResult Check()
        {
            switch (ProblemsSolved)
            {
                case 0: return new ExamResult(2, 2, 6, "Bad result: nothing done.");
                case 1:
                case 2:
                case 3: return new ExamResult(3, 2, 6, "Pass result: low problems done.");
                case 4:
                case 5: return new ExamResult(4, 2, 6, "Good result: avarage problems done.");
                case 6:
                case 7:
                case 8: return new ExamResult(5, 2, 6, "VeryGood result: more problems done.");
                case 9:
                case 10: return new ExamResult(6, 2, 6, "Excellent result: almost all problems done.");
                default: throw new ArgumentOutOfRangeException("Solved problems are out of range [0 10].");
            }
        }
    }
}
