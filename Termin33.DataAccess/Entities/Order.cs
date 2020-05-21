using System;
using System.Collections.Generic;
using System.Text;

namespace Termin33.DataAccess.Entities
{
    public class Order : Entity
    {
        public DateTime OrderDate { get; set; }
        public int UserId { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<OrderProduct> OrderProducts { get; set; } = new HashSet<OrderProduct>();
    }
}
