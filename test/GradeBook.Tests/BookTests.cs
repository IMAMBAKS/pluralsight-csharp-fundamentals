using System;
using Xunit;

namespace GradeBook.Tests
{
    public class BookTests
    {
        [Fact]
        public void BookCalculatesAnAverageGrade()
        {

            // arrange
            var book = new Book("Scott");
            book.AddGrade(30);
            book.AddGrade(20);
            book.AddGrade(40);

            // act
            var result = book.GetStatistics();

            // assert
            Assert.Equal(30, result.Average);
            Assert.Equal(40, result.High);
            Assert.Equal(20, result.Low);
            Assert.Equal('F', result.Letter);

        }

        [Fact]
        public void GradeShouldBeValid()
        {
            // arrange
            var book = new Book("Scott");
            book.AddGrade(20);
            book.AddGrade(-100);
            book.AddGrade(1000);
            
            // act
            var result = book.GetStatistics();

            // assert
            Assert.Equal(20, result.Average);
            Assert.Equal(20, result.High);
            Assert.Equal(20, result.Low);
        }
    }
}
