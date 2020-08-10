using System.ComponentModel;
using System.Web;

namespace OnlineStore.WebPLL.Models.ShortModels
{
    public class ProductShortViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [DisplayName("Manufacturer")]
        public int ManafacturerId { get; set; } // todo: override
        [DisplayName("Category")]
        public int CategoryId { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        [DisplayName("Image")]
        public string ImgUrl { get; set; }

        public HttpPostedFileBase ImageFile { get; set; }

    }
}
