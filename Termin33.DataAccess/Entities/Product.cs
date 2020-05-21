using System;
using System.Collections.Generic;
using System.Text;

namespace Termin33.DataAccess.Entities
{
    public class Product : Entity
    {
        public string Name { get; set; }
        public decimal Price { get; set; }

        public string Description { get; set; }

        public virtual ICollection<OrderProduct> ProductOrfers { get; set; } = new HashSet<OrderProduct>();
    }
}
