using BookShop.Data;
using BookShop.DomainEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace BookShopAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            InitTempData();
            

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }

        public static void InitTempData()
        {
            MemoryRepository<Book>.data = new List<Book>();
            MemoryRepository<Book>.data.Add(new Book { Author = "Auth 1", Price = 10, PublishedAt = DateTime.Now.Date, Quantity = 10, QuantityToOrder = 0, Title = "Book1" });
            MemoryRepository<Book>.data.Add(new Book { Author = "Auth 2", Price = 20, PublishedAt = DateTime.Now.Date, Quantity = 20, QuantityToOrder = 0, Title = "Book2" });
            MemoryRepository<Book>.data.Add(new Book { Author = "Auth 3", Price = 30, PublishedAt = DateTime.Now.Date, Quantity = 30, QuantityToOrder = 0, Title = "Book3" });
            MemoryRepository<Book>.data.Add(new Book { Author = "Auth 4", Price = 40, PublishedAt = DateTime.Now.Date, Quantity = 40, QuantityToOrder = 0, Title = "Book4" });
        }
    }
}
