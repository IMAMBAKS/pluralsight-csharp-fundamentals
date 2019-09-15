using System;
using System.IO;

namespace GradeBook
{
    public class DiskBook: Book
    {
        public DiskBook(string name): base(name)
        {
            Name = name;
        }

        public override void AddGrade(double grade)
        {
            string fileName = $"{Name}.txt";
            string basePath = $"/home/imambaks/gradebook/{fileName}";
            string path = @basePath;
                
            
            if (!File.Exists(path)) 
            {
                // Create a file to write to.
                File.Create(path);
            }
            using (StreamWriter sw = File.AppendText(path)) 
            {
                if (grade <= 100 && grade >= 0)
                {
                   sw.WriteLine(grade);
                }
                else
                {
                    throw new ArgumentException();
                }
            }
        }

        public override Statistics GetStatistics()
        {
            throw new System.NotImplementedException();
        }

        public string Name { get; }
        public override event GradeAddedDelegate GradeAdded;
    }
}