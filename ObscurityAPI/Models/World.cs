using System;
using System.Collections.Generic;

#nullable disable

namespace ObscurityAPI.Models
{
    public partial class World
    {
        public World()
        {
            Buildings = new HashSet<Building>();
            Players = new HashSet<Player>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Building> Buildings { get; set; }
        public virtual ICollection<Player> Players { get; set; }
    }
}
