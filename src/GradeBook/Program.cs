using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            var book = new Book("Scott");



            Console.WriteLine("Please enter the grades: ");

            while (true)
            {
                var input = Console.ReadLine();
                if (input.ToLower() == "q")
                {
                    break;
                }

                try
                {
                    var grade = double.Parse(input);
                    book.AddGrade(grade);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Invalid input");
                    Console.WriteLine(e.Message);
                }
            }


            var result = book.GetStatistics();
            Console.WriteLine($"The Minimum grade: {result.Low}");
            Console.WriteLine($"The Maximum grade: {result.High}");
            Console.WriteLine($"The Average grade: {result.Average:N1}");
            Console.WriteLine($"The Average grade Letter: {result.Letter}");
        }
    }
}