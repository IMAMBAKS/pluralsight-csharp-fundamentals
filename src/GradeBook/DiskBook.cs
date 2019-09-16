using System;
using System.Collections.Generic;
using System.IO;

namespace GradeBook
{
    public class DiskBook : Book
    {
        private string Path;

        public DiskBook(string name) : base(name)
        {
            Name = name;
            var fileName = $"{Name}.txt";
            var basePath = $"/home/imambaks/gradebook/{fileName}";
            Path = @basePath;
        }

        public override void AddGrade(double grade)
        {
            if (!File.Exists(Path))
            {
                // Create a file to write to.
                using (var fs = File.Create(Path))
                {
                    
                }
            }

            using (StreamWriter sw = File.AppendText(Path))
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
            if (!File.Exists(Path)) return null;
            
            var grades = new List<double>();
            using (StreamReader sr = new StreamReader(Path))

            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    grades.Add(double.Parse(line));
                }

            } 
            return new Statistics(0.0, double.MaxValue, double.MinValue, grades);

        }

        public override event GradeAddedDelegate GradeAdded;
    }
}