using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.DomainEntities
{
    public class Book : Entity
    {
        public string Title { get; set; }

        public DateTime PublishedAt { get; set; }

        public string Author { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }

        public int QuantityToOrder { get; set; }
    }
}
