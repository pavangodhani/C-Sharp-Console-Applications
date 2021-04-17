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

        public void RemoveStudent(string name)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentException("A Name is required to remove a student from a gradebook.");
            var student = Students.FirstOrDefault(e => e.Name == name);
            if (student == null)
            {
                Console.WriteLine("student {0} was not found, try again.", name);
                return;
            }
            Students.Remove(student);
        }


    }
}