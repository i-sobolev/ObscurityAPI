using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ObscurityAPI.ViewModels
{
    [Serializable]
    public class ItemViewModel
    {
        public int Id { get; set; }
        public int TypeId { get; set; }
        public int StorageId { get; set; }

        public ResourceViewModel Resource { get; set; }
    }
}
