using BookShop.Lib.Entities;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.Lib
{
    public class OrderManager
    {
        public OrderManager()
        {
            client.BaseAddress = new Uri("http://localhost:57363/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        HttpClient client = new HttpClient();


        public async Task<Order> CreateOrder(long userId)
        {
            HttpResponseMessage response = await client.PostAsJsonAsync("api/Orders/", userId);
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsAsync<Order>();
        }


        public async Task<Order> AddBookToOrder(long orderId, long bookId, int quantity)
        {
            HttpResponseMessage response = await client.PutAsJsonAsync("api/Orders/", new { OrderId = orderId, BookId = bookId, Quantity = quantity });
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsAsync<Order>();
        }

        public async Task<Order> RemoveBookFromOrder(long orderId, long bookId)
        {
            HttpResponseMessage response = await client.PutAsJsonAsync("api/Orders/", new { OrderId = orderId, BookId = bookId, Quantity = 0 });
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsAsync<Order>();
        }

        public async Task<Order> ClearOrder(long orderId)
        {
            HttpResponseMessage response = await client.DeleteAsync($"api/Orders/{orderId}");
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsAsync<Order>();
        }
    }
}
