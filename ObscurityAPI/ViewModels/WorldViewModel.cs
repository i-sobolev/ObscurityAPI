using System;

namespace ObscurityAPI.ViewModels
{
    [Serializable]
    public class WorldViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string[] PlayerNames { get; set; }
    }
}
