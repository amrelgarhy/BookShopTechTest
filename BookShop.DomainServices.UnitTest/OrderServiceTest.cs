using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BookShop.Data;
using BookShop.DomainEntities;
using System.Linq;

namespace BookShop.DomainServices.UnitTest
{
    [TestClass]
    public class OrderServiceTest
    {
        BookService bookService;
        OrderService orderService;
        Book book;
        Book highQuantityBook;

        [TestInitialize]
        public void init()
        {
            bookService = new BookService(new MemoryRepository<Book>());
            orderService = new OrderService(new MemoryRepository<Book>(), new MemoryRepository<Order>());

            book = new Book { Author = "Amr", Id = 999, Price = 10, Quantity = 2, Title = "Low Availability" };

            highQuantityBook = new Book { Author = "Another Amr :)", Id = 99, Price = 10, Quantity = 200, Title = "High Availability" };
        }

        [TestMethod]
        public void CreateNewOrderShouldIncreaseNumberOfOrdersByOne()
        {
            orderService.CreateOrder(1);
            int count = orderService.GetAll().Count();

            Assert.AreEqual(1, count);

            orderService.CreateOrder(1);
            count = orderService.GetAll().Count();

            Assert.AreEqual(2, count);
        }

        [TestMethod]
        public void AddALowAvailabilityBookToOrderShouldNotAddTheBookToOrder()
        {
            
            bookService.Add(book);

            var order = orderService.CreateOrder(1);
            orderService.AddBook(order, book, 10);

            Assert.AreEqual(0, order.Books.Count);
        }

        [TestMethod]
        public void AddABookToOrderShouldDecreaseTheBookQuantityWithOrderedQuantity()
        {
            bookService.Add(book);

            var order = orderService.CreateOrder(1);
            orderService.AddBook(order, book, 1);

            Assert.AreEqual(1, book.Quantity);
        }

        [TestMethod]
        public void RemoveABookShouldDecreaseNumberOfOrderBooksByOne()
        {
            bookService.Add(book);

            var order = orderService.CreateOrder(1);
            orderService.AddBook(order, book, 1);

            orderService.RemoveBook(order,book);

            Assert.AreEqual(0, order.Books.Count);
            
        }


        [TestMethod]
        public void ClearOrderBooksShouldRemoveAllOrderBooks()
        {
            bookService.Add(book);
            bookService.Add(highQuantityBook);

            var order = orderService.CreateOrder(1);
            orderService.AddBook(order, book, 1);
            orderService.AddBook(order, highQuantityBook, 10);

            orderService.Clear(order);

            Assert.AreEqual(0, order.Books.Count);

        }

    }
}
