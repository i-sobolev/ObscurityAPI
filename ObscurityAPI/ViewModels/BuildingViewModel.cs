using System;

namespace ObscurityAPI.ViewModels
{
    [Serializable]
    public class BuildingViewModel
    {
        public int Id { get; set; }
        public float XPosition { get; set; }
        public float YPosition { get; set; }
        public float ZPosition { get; set; }
        public string Owner { get; set; }
        public int TypeId { get; set; }
        public LightningViewModel Lightning { get; set; }
        public StorageViewModel Storage { get; set; }
        public float Rotation { get; set; }
        public int WorldId { get; set; }
    }
}