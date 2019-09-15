using System;
using System.Collections.Generic;


namespace GradeBook
{
    public delegate void GradeAddedDelegate(object sender, EventArgs args);

    public class NamedObject
    {
        public NamedObject(string name)
        {
            Name = name;
        }

        public string Name { get; set; }
    }

    public class Book : NamedObject
    {
        public Book(string name) : base(name)
        {
            grades = new List<double>();
            Name = name;
        }

        public void AddGrade(double grade)
        {
            if (grade <= 100 && grade >= 0)
            {
                grades.Add(grade);
                if (GradeAdded != null)
                {
                    GradeAdded(this, new EventArgs());
                }
            }
            else
            {
                throw new ArgumentException($"Invalid {nameof(grade)}");
            }
        }

        public event GradeAddedDelegate GradeAdded;

        public Statistics GetStatistics()
        {
            var result = new Statistics {Average = 0.0, Low = double.MaxValue, High = double.MinValue};

            foreach (var grade in grades)

            {
                result.Low = Math.Min(grade, result.Low);
                result.High = Math.Max(grade, result.High);
                result.Average += grade;
            }

            result.Average /= grades.Count;

            result.Letter = GetLetterFromAverageGrade(result.Average);


            return result;
        }

        public char GetLetterFromAverageGrade(double grade)
        {
            switch (grade)
            {
                case var d when d >= 90:
                    return 'A';
                    break;

                case var d when d >= 80:
                    return 'B';
                    break;

                case var d when d >= 70:
                    return 'C';
                    break;
                case var d when d >= 60:
                    return 'D';
                    break;
                default:
                    return 'F';
            }
        }

        private List<double> grades;
        private string _name;

        public string Name
        {
            get => _name;
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    _name = value;
                }
                else
                {
                    throw new ArgumentNullException();
                }
            }
        }
    }
}