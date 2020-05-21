using System;
using System.Collections.Generic;
using System.Text;

namespace Termin33.DataAccess.Entities
{
    public abstract class Entity 
    {
        //stavljamo kolone koje ce imati sve tabele
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedAt { get; set; }
        public bool IsActive { get; set; }
    }
}
