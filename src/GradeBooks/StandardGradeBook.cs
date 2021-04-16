using GradeBook;

namespace GradeBook.GradeBooks
{
    class StandardGradeBook : BaseGardeBook
    {
        public StandardGradeBook(string name) : base(name)
        {
            this.Type = Enums.GradeBookType.Standard;
        }
    }
}