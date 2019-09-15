namespace GradeBook
{
    public class DiskBook: Book, IBook
    {
        public DiskBook(string name): base(name)
        {
            Name = name;
        }

        public override void AddGrade(double grade)
        {
            throw new System.NotImplementedException();
        }

        public override Statistics GetStatistics()
        {
            throw new System.NotImplementedException();
        }

        public string Name { get; }
        public event GradeAddedDelegate GradeAdded;
    }
}