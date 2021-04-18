using System;
using System.Collections.Generic;
using System.Linq;
using GradeBook.Enums;

namespace GradeBook.Students
{
    public class Student : IComparable<Student>
    {
        public string Name { get; set; }
        public StudentType Type { get; set; }
        public EnrollmentType Enrollment { get; set; }
        public List<double> Grades { get; set; }
        public double AverageGrade
        {
            get
            {
                return Grades.Average();
            }
        }
        public char LetterGrade { get; set; }
        public double GPA { get; set; }

        public Student(string studentName, StudentType studentType, EnrollmentType studentEnrollmentType)
        {
            Name = studentName;
            Type = studentType;
            Enrollment = studentEnrollmentType;

            Grades = new List<double>();
        }

        public void AddGrade(double grade)
        {
            if (grade < 0 || grade > 100)
                throw new ArgumentException("Grades must be between 0 and 100.");

            Grades.Add(grade);
        }

        public void RemoveGrade(double grade)
        {
            if (Grades.Contains(grade))
            {
                Grades.Remove(grade);

                Console.WriteLine($"Removed a grade of {grade} from {Name}'s grades");
            }
            else
            {
                System.Console.WriteLine($"Garde {grade} is not prasent in {Name}'s grades");
            }

        }

        public int CompareTo(Student obj)
        {
            return AverageGrade.CompareTo(obj.AverageGrade);

        }
    }
}