using System;
using System.Collections.Generic;
using System.Text;

namespace Termin33.DataAccess.Entities
{
    public class Group : Entity
    {
        public string Name { get; set; }


        public virtual ICollection<User> Users { get; set; } //grupa ima vise usera ima kolekciju usera
    }
}
