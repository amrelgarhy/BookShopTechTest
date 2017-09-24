﻿using BookShop.Lib.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.Lib
{
    public class OrderManager
    {
        static HttpClient client = new HttpClient();

        static async Task<Order> GetOrderAsync(string path)
        {
            Order order = null;
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                order = await response.Content.ReadAsAsync<Order>();
            }

            return order;
        }
    }
}