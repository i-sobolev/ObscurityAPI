using System;

namespace ObscurityAPI.ViewModels
{
    [Serializable]
    public class PlayerViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int WorldId { get; set; }
    }
}