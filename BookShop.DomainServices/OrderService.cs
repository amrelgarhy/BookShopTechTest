using BookShop.Data;
using BookShop.DomainEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.DomainServices
{
    public class OrderService
    {
        private readonly IRepository<Book> _bookRepo;
        private readonly IRepository<Order> _orderRepo;

        public OrderService() : this(new MemoryRepository<Book>(), new MemoryRepository<Order>())
        {

        }

        public OrderService(IRepository<Book> bookRepo, IRepository<Order> orderRepo)
        {
            _bookRepo = bookRepo;
            _orderRepo = orderRepo;
        }

        public Order Get(long orderId)
        {
            return _orderRepo.Get(orderId); ;
        }

        public Order CreateOrder(long userId)
        {
            var order = new Order(userId);
            return _orderRepo.Add(order);
        }

        public Order AddBook(Order order, Book book, int qty)
        {
            if (order != null)
            {
                if (book != null)
                {
                    if ((book.Quantity - qty) > 0)
                    {
                        var existingBookRecord = order.Books.FirstOrDefault(x => x.Id == book.Id);
                        if (existingBookRecord != null)
                        {
                            existingBookRecord.QuantityToOrder = qty;
                        }
                        else
                        {
                            book.QuantityToOrder = qty;
                            order.Books.Add(book);
                        }

                        _orderRepo.Update(order);

                        //var bookService = new BookService(_bookRepo);
                        //bookService.ReserveQuantity(book, qty);
                    }
                }
            }

            return order;
        }


        public Order RemoveBook(Order order, Book book)
        {
            if (order != null)
            {
                var orderBook = order.Books.FirstOrDefault(x => x.Id == book.Id);
                if (orderBook != null)
                {
                    order.Books.Remove(orderBook);

                    _orderRepo.Update(order);
                }
            }

            return order;
        }

        public Order Clear(Order order)
        {
            if (order != null)
            {
                order.Books.Clear();

                _orderRepo.Update(order);
            }

            return order;
        }

        public IEnumerable<Order> GetAll()
        {
            return _orderRepo.GetAll();
        }
    }
}
