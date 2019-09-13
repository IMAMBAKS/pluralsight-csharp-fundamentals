using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {

            var book = new Book("Scott");
            book.AddGrade(12.7);
            book.AddGrade(12.4);
            book.AddGrade(1.7);
            book.AddGrade(14.7);
            book.AddGrade(4.7);

            var result = book.GetStatistics();
            Console.WriteLine($"The Minimum grade: {result.Low}");
            Console.WriteLine($"The Maximum grade: {result.High}");
            Console.WriteLine($"The Average grade: {result.Average:N1}");




        }
    }


}
