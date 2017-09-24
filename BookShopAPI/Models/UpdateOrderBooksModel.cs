using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookShopAPI.Models
{
    public class UpdateOrderBooksModel
    {
        public long OrderId { get; set; }

        public long BookId { get; set; }

        public int Quantity { get; set; }
    }
}