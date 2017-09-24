using BookShop.DomainEntities;
using BookShop.DomainServices;
using BookShopAPI.Models;
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
        public IHttpActionResult Get()
        {
            try
            {
                var service = new OrderService();
                var orders = service.GetAll();

                return Ok(orders);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        public IHttpActionResult Get(long id)
        {
            try
            {
                var service = new OrderService();
                var order = service.Get(id);
                if (order != null)
                {
                    return Ok(order);
                }

                return NotFound();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpPost]
        public IHttpActionResult Post([FromBody]long userId)
        {
            try
            {
                var service = new OrderService();

                var order = service.CreateOrder(userId);
                return Created(Request.RequestUri + order.Id.ToString(), order);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        public IHttpActionResult Put(UpdateOrderBooksModel orderToUpdate)
        {
            try
            {
                var orderService = new OrderService();
                var bookService = new BookService();

                var order = orderService.Get(orderToUpdate.OrderId);
                if (order == null)
                {
                    return BadRequest("Order Does Not Exist");
                }

                var book = bookService.Get(orderToUpdate.BookId);
                if (book == null)
                {
                    return BadRequest("Book Does Not Exist");
                }

                if (orderToUpdate.Quantity == 0)
                {
                    orderService.RemoveBook(order, book);
                }
                else
                {
                    orderService.AddBook(order, book, orderToUpdate.Quantity);
                }
                return Ok(order);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }


        public IHttpActionResult Delete(long id)
        {
            try
            {
                var orderService = new OrderService();

                var order = orderService.Get(id);
                if (order == null)
                {
                    return BadRequest("Order Does Not Exist");
                }

                order = orderService.Clear(order);

                return Ok(order);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}
