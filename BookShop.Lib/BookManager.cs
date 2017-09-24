using BookShop.Lib.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.Lib
{
    public class BookManager
    {
        HttpClient client = new HttpClient();

        public BookManager()
        {
            client.BaseAddress = new Uri("http://localhost:57363/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        }

        public async Task<IEnumerable<Book>> GetAllBooksAsync()
        {
            IEnumerable<Book> books = new List<Book>();
            HttpResponseMessage response = await client.GetAsync("api/Books");
            if (response.IsSuccessStatusCode)
            {
                books = await response.Content.ReadAsAsync<IEnumerable<Book>>();
            }

            return books;
        }
    }
}
