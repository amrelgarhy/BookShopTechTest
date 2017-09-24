using BookShop.DomainServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BookShopAPI.Controllers
{
    public class OrdersController : ApiController
    {
        public IHttpActionResult Get(long id)
        {
            var service = new OrderService();
            var order = service.Get(id);
            if (order != null)
            {
                return Ok(service.Get(id));
            }

            return NotFound();
        }

        public IHttpActionResult Post(long userId)
        {
            var service = new OrderService();

            return Ok(service.CreateOrder(userId));
        }
    }
}
