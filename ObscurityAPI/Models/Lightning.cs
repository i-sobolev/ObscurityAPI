using System;
using System.Collections.Generic;

#nullable disable

namespace ObscurityAPI.Models
{
    public partial class Lightning
    {
        public int Id { get; set; }
        public int Fuel { get; set; }

        public virtual Building IdNavigation { get; set; }
    }
}
