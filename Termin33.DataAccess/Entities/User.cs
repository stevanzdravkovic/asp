using System;
using System.Collections.Generic;
using System.Text;

namespace Termin33.DataAccess.Entities
{
    public class User : Entity
    {
        public string FirstName { get; set; }
        public string Lastname { get; set; }
        public string Username { get; set; }


        public int GroupId { get; set; }
        public virtual Group Group { get; set; } //user moze da ima jednu grupu // virtual je zbog lejziloading
        public virtual ICollection<Order> Orders { get; set; } = new HashSet<Order>();
    }
}
