using System;
using System.Collections.Generic;

#nullable disable

namespace ObscurityAPI.Models
{
    public partial class Building
    {
        public int Id { get; set; }
        public double Xposition { get; set; }
        public double Yposition { get; set; }
        public double Zposition { get; set; }
        public string Owner { get; set; }
        public int TypeId { get; set; }
        public int WorldId { get; set; }
        public double Rotation { get; set; }

        public virtual World World { get; set; }
        public virtual Lightning Lightning { get; set; }
        public virtual Storage Storage { get; set; }
    }
}
