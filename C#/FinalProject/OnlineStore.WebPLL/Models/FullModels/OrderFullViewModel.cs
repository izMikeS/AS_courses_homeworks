using OnlineStore.WebPLL.Models.ShortModels;
using System.Collections.Generic;

namespace OnlineStore.WebPLL.Models.FullModels
{
    public class OrderFullViewModel
    {
        public OrderShortViewModel Order { get; set; }

        public List<ProductAtOrderFullViewModel> Products { get; set; }

        public decimal TotalPrice { get; set; }
    }
}