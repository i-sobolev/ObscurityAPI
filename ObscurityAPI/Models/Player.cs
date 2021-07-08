using System;
using System.Collections.Generic;

#nullable disable

namespace ObscurityAPI.Models
{
    public partial class Player
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int WorldId { get; set; }

        public virtual World World { get; set; }
    }
}
