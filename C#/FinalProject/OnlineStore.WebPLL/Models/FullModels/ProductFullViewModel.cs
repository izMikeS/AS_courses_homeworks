using OnlineStore.WebPLL.Models.ShortModels;

namespace OnlineStore.WebPLL.Models.FullModels
{
    public class ProductFullViewModel
    {
        public ProductShortViewModel Product { get; set; }
        public CategoryShortViewModel Category { get; set; }
        public ManufacturerShortViewModel Manufacturer  { get; set; }
    }
}