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

        public override void CalculateStatistics()
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
                return;
            }

            base.CalculateStatistics();
            
        }

        public override void CalculateStudentStatistics(string name)
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
                return;
            }
            
            base.CalculateStudentStatistics(name);
        }

        public override char GetLetterGrade(double averageGrade)
        {
            var students = Students;

            if (students.Count < 5)
            {
                throw new System.InvalidOperationException();
            }

            students.Sort((x, y) => y.AverageGrade.CompareTo(x.AverageGrade));

            if (averageGrade >= students[(int)Math.Ceiling(Convert.ToDouble(students.Count) * 0.2) - 1].AverageGrade)
                return 'A';
            else if (averageGrade >= students[(int)Math.Ceiling(Convert.ToDouble(students.Count) * 0.4) - 1].AverageGrade)
                return 'B';
            else if (averageGrade >= students[(int)Math.Ceiling(Convert.ToDouble(students.Count) * 0.6) - 1].AverageGrade)
                return 'C';
            else if (averageGrade >= students[(int)Math.Ceiling(Convert.ToDouble(students.Count) * 0.8) - 1].AverageGrade)
                return 'D';
            else
                return 'F';
        }
    }
}