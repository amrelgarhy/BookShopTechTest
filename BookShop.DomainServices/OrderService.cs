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


    }
}
