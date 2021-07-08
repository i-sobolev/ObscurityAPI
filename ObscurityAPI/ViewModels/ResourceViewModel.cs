using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ObscurityAPI.ViewModels
{
    [Serializable]
    public class ResourceViewModel
    {
        public int Id { get; set; }
        public int Amount { get; set; }
    }
}
