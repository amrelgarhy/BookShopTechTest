using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.DomainEntities
{
    public class Order : Entity
    {
        public string UserId { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime AmendedAt { get; set; }

        public DateTime OrderedAt { get; set; }

        public ICollection<Book> Books { get; set; }

    }
}
