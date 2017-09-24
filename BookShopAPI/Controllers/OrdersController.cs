using BookShop.DomainEntities;
using BookShop.DomainServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BookShopAPI.Controllers
{
    public class OrdersController : BaseApiController
    {
        public IHttpActionResult Get(long id)
        {
            try
            {
                var service = new OrderService();
                var order = service.Get(id);
                if (order != null)
                {
                    return Ok(service.Get(id));
                }

                return NotFound();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        public IHttpActionResult Post(long userId)
        {
            try
            {
                var service = new OrderService();

                return Ok(service.CreateOrder(userId));
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        public IHttpActionResult AddBook(long orderId, long bookId, int quantity)
        {
            try
            {
                var orderService = new OrderService();
                var bookService = new BookService();

                var order = orderService.Get(orderId);
                if (order == null)
                {
                    return BadRequest("Order Does Not Exist");
                }

                var book = bookService.Get(bookId);
                if (book == null)
                {
                    return BadRequest("Book Does Not Exist");
                }

                orderService.AddBook(order, book, quantity);

                return Ok(order);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}
