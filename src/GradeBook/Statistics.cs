using System;
using System.Collections.Generic;

namespace GradeBook
{
    public class Statistics
    {
        
        public double Average;
        public double High;
        public double Low;
        public char Letter;
        private List<double> Grades;

        public Statistics(double average, double high, double low, List<double> grades)
        {
            Average = average;
            High = high;
            Low = low;
            Grades = grades;
            Calculate();
        }

        public Statistics Calculate()
        {

            foreach (var grade in Grades)

            {
                Low = Math.Min(grade, High);
                High = Math.Max(grade, Low);
                Average += grade;
            }

            Average /= Grades.Count;

            Letter = GetLetterFromAverageGrade(Average);


            return null;
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
        
        
    }
}