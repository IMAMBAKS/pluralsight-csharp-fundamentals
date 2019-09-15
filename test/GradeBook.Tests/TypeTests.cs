using System;
using Xunit;

namespace GradeBook.Tests
{
    public class TypeTests
    {
        
        [Fact]
        public void Test1()
        {

            // arrange
            var book1 = GetBook("book 1");
            SetName(book1, "New Name");
                

            // assert
            Assert.Equal("New Name", book1.Name);

        }

        private void SetName(InMemoryBook inMemoryBook, string name)
        {
            inMemoryBook.Name = name;
        }

        [Fact]
        public void GetBookReturnsDifferentObjects()
        {

            // arrange
            var book1 = GetBook("book 1");
            var book2 = GetBook("book 2");
                

            // assert
            Assert.Equal("book 1", book1.Name);
            Assert.Equal("book 2", book2.Name);

        }

        private InMemoryBook GetBook(string name)
        {
            return new InMemoryBook(name);
        }
    }
}
