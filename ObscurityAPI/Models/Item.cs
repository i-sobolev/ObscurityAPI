using System;
using System.Collections.Generic;

#nullable disable

namespace ObscurityAPI.Models
{
    public partial class Item
    {
        public int Id { get; set; }
        public int TypeId { get; set; }
        public int StorageId { get; set; }

        public virtual Storage Storage { get; set; }
        public virtual Resource Resource { get; set; }
    }
}
