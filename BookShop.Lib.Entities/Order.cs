using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.Lib.Entities
{
    public class Order
    {
        public Order(long userId)
        {
            UserId = userId;
            if (Books == null)
            {
                Books = new List<Book>();
            }
        }

        public long Id { get; set; }

        public long UserId { get; private set; }

        public DateTime CreatedAt { get; set; }

        public DateTime AmendedAt { get; set; }

        public DateTime OrderedAt { get; set; }

        public ICollection<Book> Books { get; set; }
    }
}
