using System;
using System.Collections.Generic;
using System.Linq;
using GradeBook.Enums;
using GradeBoook.Student;

namespace GradeBook.GradeBooks
{
    public class BaseGradeBook
    {
        public string Name { get; set; }

        public List<Student> Students { get; set; }

        public BaseGradeBook(string name)
        {
            Name = name;
            Students = new List<Student>();
        }

        public void AddStudent(Student student)
        {
            if (string.IsNullOrEmpty(student.Name))
                throw new ArgumentException("A Name is required to add a student to a gradebook.");

            Students.Add(student);
        }

        public void RemoveStudent(string studentName)
        {
            if (string.IsNullOrEmpty(studentName))
                throw new ArgumentException("A Name is required to remove a student from a gradebook.");

            var student = Students.FirstOrDefault(e => e.Name == studentName);

            if (student == null)
            {
                Console.WriteLine("student {0} was not found, try again.", studentName);
                return;
            }

            Students.Remove(student);
            Console.WriteLine($"Removed {studentName} from the gradebook.");
        }

        public void ListStudents()
        {
            System.Console.WriteLine("Student Name : Student Type : Student Enrollment\n");

            foreach (var student in Students)
            {
                Console.WriteLine($"{student.Name} : {student.Type} : {student.Enrollment}");
            }
        }

        public void AddGrade(string studentName, double grade)
        {
            if (string.IsNullOrEmpty(studentName))
                throw new ArgumentException("A Name is required to add a grade to a student.");

            var student = Students.FirstOrDefault(e => e.Name == studentName);

            if (student == null)
            {
                Console.WriteLine($"student {studentName} was not found, try again.");
                return;
            }

            student.AddGrade(grade);
        }

        public void RemoveGrade(string studentName, double score)
        {
            if (string.IsNullOrEmpty(studentName))
                throw new ArgumentException("A Name is required to remove a grade from a student.");

            var student = Students.FirstOrDefault(e => e.Name == studentName);

            if (student == null)
            {
                Console.WriteLine("student {0} was not found, try again.", studentName);
                return;
            }
            student.RemoveGrade(score);
        }
    }
}