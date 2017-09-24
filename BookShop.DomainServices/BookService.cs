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

        public Book Get(long bookId)
        {
            return _bookRepo.Get(bookId);
        }

        public Book Add(Book book)
        {
            return _bookRepo.Add(book);
        }


        //public Book ReserveQuantity(Book book, int quantity)
        //{
        //    book.Quantity -= quantity;

        //    _bookRepo.Update(book);

        //    return book;
        //}
    }
}
