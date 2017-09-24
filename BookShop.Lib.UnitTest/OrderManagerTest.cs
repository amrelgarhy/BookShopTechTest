using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.Lib.UnitTest
{
    [TestClass]
    public class OrderManagerTest
    {
        [TestMethod]
        public void CreateNewOrderShouldReturnEmptyOrderObject()
        {
            var orderManager = new OrderManager();

            var order = orderManager.CreateOrder(1).Result;

            Assert.AreEqual(0, order.Books.Count);
        }

        [TestMethod]
        public void CreateNewOrderShouldReturnOrderWithSentUserId()
        {
            long userId = 10;
            var orderManager = new OrderManager();

            var order = orderManager.CreateOrder(userId).Result;

            Assert.AreEqual(userId, order.UserId);
        }

        [TestMethod]
        public void AddBookToANewOrderShoulReturnOrderWithOneBook()
        {
            long userId = 10;
            var orderManager = new OrderManager();

            var bookManager = new BookManager();
            var books = bookManager.GetAllBooksAsync().Result;

            var order = orderManager.CreateOrder(userId).Result;
            order = orderManager.AddBookToOrder(order.Id, books.First().Id, 1).Result;

            Assert.AreEqual(1, order.Books.Count);
        }

        [TestMethod]
        public void AddBookToANewOrderWithBigQunityShouldReturnOrderWithNoBooks()
        {
            long userId = 10;
            var orderManager = new OrderManager();

            var bookManager = new BookManager();
            var books = bookManager.GetAllBooksAsync().Result;

            var order = orderManager.CreateOrder(userId).Result;
            order = orderManager.AddBookToOrder(order.Id, books.First().Id, 100).Result;

            Assert.AreEqual(0, order.Books.Count);
        }

        [TestMethod]
        public void UpdateQuantityOfABookShouldUpdateTheQuantityToOrder()
        {
            long userId = 10;
            var orderManager = new OrderManager();

            var bookManager = new BookManager();
            var books = bookManager.GetAllBooksAsync().Result;
            long firstBookId = books.First().Id;

            var order = orderManager.CreateOrder(userId).Result;
            order = orderManager.AddBookToOrder(order.Id, firstBookId, 1).Result;
            order = orderManager.AddBookToOrder(order.Id, books.Last().Id, 1).Result;

            order = orderManager.AddBookToOrder(order.Id, firstBookId, 5).Result;

            Assert.AreEqual(5, order.Books.Single(x => x.Id == firstBookId).QuantityToOrder);
        }

        [TestMethod]
        public void RemoveBookFromOrderShouldRemoveTheBookFromOrderBooksList()
        {
            long userId = 10;
            var orderManager = new OrderManager();

            var bookManager = new BookManager();
            var books = bookManager.GetAllBooksAsync().Result;
            long firstBookId = books.First().Id;

            var order = orderManager.CreateOrder(userId).Result;
            order = orderManager.AddBookToOrder(order.Id, firstBookId, 100).Result;

            order = orderManager.RemoveBookFromOrder(order.Id, firstBookId).Result;

            Assert.IsNull(order.Books.FirstOrDefault(x => x.Id == firstBookId));
        }

        [TestMethod]
        public void ClearAllBooksFromOrderShouldReturnOrderWithZeroBooks()
        {
            long userId = 10;
            var orderManager = new OrderManager();

            var bookManager = new BookManager();
            var books = bookManager.GetAllBooksAsync().Result;
            long firstBookId = books.First().Id;

            var order = orderManager.CreateOrder(userId).Result;
            order = orderManager.AddBookToOrder(order.Id, firstBookId, 1).Result;
            order = orderManager.AddBookToOrder(order.Id, books.Last().Id, 1).Result;

            order = orderManager.AddBookToOrder(order.Id, firstBookId, 5).Result;

            order = orderManager.ClearOrder(order.Id).Result;

            Assert.AreEqual(0, order.Books.Count);
        }


    }
}
