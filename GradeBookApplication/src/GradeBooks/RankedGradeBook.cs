using System;
using System.Collections.Generic;
using System.Linq;
using GradeBook.Enums;
using GradeBook.Students;

namespace GradeBook.GradeBooks
{
    class RankedGradeBook : BaseGradeBook
    {

        public RankedGradeBook(string name, bool isWeighted) : base(name, isWeighted)
        {
            this.Type = GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            if (this.Students.Count < 5)
            {
                throw new InvalidOperationException("Ranked-grading requires a minimum 5 students to work.");
            }

            IEnumerable<Student> studentsQuery = Students.OrderByDescending(x => x.AverageGrade);

            var studentAverageGrades = new List<double>();


            foreach (var student in studentsQuery)
            {
                studentAverageGrades.Add(student.AverageGrade);
            }

            int topXPercent = Convert.ToInt32(Students.Count * 0.2);



            int bandItr = 1;
            int[] currentGrade = new int[] { 'A', 'B', 'C', 'D', 'F' };
            int gradeIndex = 0;
            char gradeStore = 'F';



            for (; topXPercent * bandItr < Students.Count; bandItr++)
            {

                if (topXPercent * bandItr >= studentAverageGrades.IndexOf(averageGrade) && gradeIndex < currentGrade.Length)
                {
                    gradeStore = (char)currentGrade[gradeIndex];

                    break;
                }

                gradeIndex++;

            }



            return gradeStore;

            // var top20 = Convert.ToInt32(this.Students.Count * 0.2);


            // var topXPercent = Convert.ToInt32(Students.Count * 0.2);

            // int letterGrades = 'A';

            // for (int i = 1; topXPercent * i < Students.Count - 1; i++)
            // {
            //     if (topXPercent * i > studentAverageGrades.IndexOf(averageGarde))
            //     {
            //         return (char)letterGrades;
            //     }
            //     letterGrades = letterGrades + 1;
            // }
            // return (char)letterGrades;


            // if (studentAverageGrades.IndexOf(averageGarde) < top20)
            // {
            //     return 'A';
            // }
            // else if (studentAverageGrades.IndexOf(averageGarde) < 2 * top20)
            // {
            //     return 'B';
            // }
            // else if (studentAverageGrades.IndexOf(averageGarde) < 3 * top20)
            // {
            //     return 'C';
            // }
            // else if (studentAverageGrades.IndexOf(averageGarde) < 4 * top20)
            // {
            //     return 'D';
            // }
            // else
            // {
            //     return 'F';
            // }

            // char[] letterGrades = new[] {'A', 'B', 'C', 'D', 'F'};



        }

        public override void CalculateStudentStatistics(string studentName)
        {
            if (this.Students.Count < 5)
            {
                System.Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");

                return;
            }

            base.CalculateStudentStatistics(studentName);
        }

        public override void CalculateStatistics()
        {
            if (this.Students.Count < 5)
            {
                System.Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");

                return;
            }

            base.CalculateStatistics();
        }
    }
}