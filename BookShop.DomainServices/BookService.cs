using BookShop.Data;
using BookShop.DomainEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.DomainServices
{
    public class BookService
    {
        private readonly IRepository<Book> _bookRepo;

        public BookService() : this(new MemoryRepository<Book>())
        {

        }

        public BookService(IRepository<Book> bookRepo)
        {
            _bookRepo = bookRepo;
        }

        public IEnumerable<Book> GetAll()
        {
            return _bookRepo.GetAll();
        }

    }
}
