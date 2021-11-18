using GradeBook.Enums;
using System;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name) : base(name)
        {
            Type = GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            if (this.Students.Count < 5)
            {
                throw new System.InvalidOperationException();
            }

            this.Students.Sort((x, y) => y.AverageGrade.CompareTo(x.AverageGrade));

            if (averageGrade >= this.Students[(int)Math.Ceiling(Convert.ToDouble(this.Students.Count) * 0.2) - 1].AverageGrade)
                return 'A';
            else if (averageGrade >= this.Students[(int)Math.Ceiling(Convert.ToDouble(this.Students.Count) * 0.4) - 1].AverageGrade)
                return 'B';
            else if (averageGrade >= this.Students[(int)Math.Ceiling(Convert.ToDouble(this.Students.Count) * 0.6) - 1].AverageGrade)
                return 'C';
            else if (averageGrade >= this.Students[(int)Math.Ceiling(Convert.ToDouble(this.Students.Count) * 0.8) - 1].AverageGrade)
                return 'D';
            else
                return 'F';
        }
    }
}