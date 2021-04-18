using System;
using System.Collections.Generic;
using System.Linq;
using GradeBook.Enums;
using GradeBook.Students;

namespace GradeBook.GradeBooks
{
    class RankedGradeBook : BaseGradeBook
    {

        public RankedGradeBook(string name) : base(name)
        {
            this.Type = GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGarde)
        {
            if (this.Students.Count < 5)
            {
                throw new InvalidOperationException("Ranked-grading requires a minimum of 5 students to work.");
            }

            IEnumerable<Student> studentsQuery = Students.OrderByDescending(x => x.AverageGrade);

            var studentAverageGrades = new List<double>();


            foreach (var student in studentsQuery)
            {
                studentAverageGrades.Add(student.AverageGrade);
            }

            var top20 = Convert.ToInt32(this.Students.Count * 0.2);

            if (studentAverageGrades.IndexOf(averageGarde) < top20)
            {
                return 'A';
            }
            else if (studentAverageGrades.IndexOf(averageGarde) < 2 * top20)
            {
                return 'B';
            }
            else if (studentAverageGrades.IndexOf(averageGarde) < 3 * top20)
            {
                return 'C';
            }
            else if (studentAverageGrades.IndexOf(averageGarde) < 4 * top20)
            {
                return 'D';
            }
            else
            {
                return 'F';
            }
        }

    }
}