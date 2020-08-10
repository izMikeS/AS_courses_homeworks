using OnlineStore.WebPLL.Models.ShortModels;
using System.Collections.Generic;

namespace OnlineStore.WebPLL.Models.FullModels
{
    public class CustomerFullViewModel
    {
        public CustomerShortViewModel Customer { get; set; }
        public List<OrderShortViewModel> Orders { get; set; }
    }
}