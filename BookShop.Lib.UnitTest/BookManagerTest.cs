using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BookShop.Lib.Entities;
using System.Linq;

namespace BookShop.Lib.UnitTest
{
    [TestClass]
    public class BookManagerTest
    {
        [TestMethod]
        public void GetAllBooksShouldReturnResultOfBooks()
        {
            var bookManager = new BookManager();

            var books = bookManager.GetAllBooksAsync().Result;

            Assert.IsInstanceOfType(books.FirstOrDefault(), typeof(Book));
        }
    }
}
