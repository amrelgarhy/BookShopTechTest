using BookShop.DomainServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BookShopAPI.Controllers
{
    public class BooksController : BaseApiController
    {

        public IHttpActionResult Get()
        {
            try
            {
                var service = new BookService();

                return Ok(service.GetAll());
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}
