using System.Collections.Generic;
using GradeBook.Enums;

namespace GradeBook
{
    public abstract class BaseGardeBook
    {
        private List<double> grades;
        private string name;
        
        public BaseGardeBook(string name)
        {
            this.name = name;
            grades = new List<double>();
        }

        public GradeBookType Type
        {
            get;
            set;
        }

        public abstract char GetLatterGrade(double averageGarde);
        public abstract void AddGrade(double grade);


    }
}