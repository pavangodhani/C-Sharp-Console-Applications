using System.Collections.Generic;
using GradeBook.Enums;
using GradeBoook.Student;

namespace GradeBook
{
    public class BaseGardeBook
    {
        public string Name { get; set; }

        public List<Student> Students { get; set; }

        public BaseGardeBook(string name)
        {
            Name = name;
            Students = new List<Student>();
        }

    }
}