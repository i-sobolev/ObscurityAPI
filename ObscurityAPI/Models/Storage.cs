using System;
using System.Collections.Generic;

#nullable disable

namespace ObscurityAPI.Models
{
    public partial class Storage
    {
        public Storage()
        {
            Items = new HashSet<Item>();
        }

        public int Id { get; set; }
        public bool IsLocked { get; set; }

        public virtual Building IdNavigation { get; set; }
        public virtual ICollection<Item> Items { get; set; }
    }
}
