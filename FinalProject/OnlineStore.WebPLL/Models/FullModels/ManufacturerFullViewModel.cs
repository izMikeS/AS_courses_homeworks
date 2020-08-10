using OnlineStore.WebPLL.Models.ShortModels;
using System.Collections.Generic;

namespace OnlineStore.WebPLL.Models.FullModels
{
    public class ManufacturerFullViewModel
    {
        public ManufacturerShortViewModel Manufacturer { get; set; }
        public List<ProductShortViewModel> Products { get; set; }
    }
}