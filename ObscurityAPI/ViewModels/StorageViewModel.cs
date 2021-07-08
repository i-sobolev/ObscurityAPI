using System;

namespace ObscurityAPI.ViewModels
{
    [Serializable]
    public class StorageViewModel
    {
        public int Id { get; set; }
        public bool IsLocked { get; set; }
    }
}
