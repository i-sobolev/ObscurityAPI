using System;
using System.Collections.Generic;

#nullable disable

namespace ObscurityAPI.Models
{
    public partial class Resource
    {
        public int Id { get; set; }
        public int Amount { get; set; }

        public virtual Item IdNavigation { get; set; }
    }
}
