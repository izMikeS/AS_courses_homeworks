using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace OnlineStore.WebPLL.Models.ShortModels
{
    public class ManufacturerShortViewModel
    {
        public int Id { get; set; }

        [Required, StringLength(30, MinimumLength = 3)]
        public string Name { get; set; }

        [DisplayName("Logo")]
        public string ImgUrl { get; set; }

        public HttpPostedFileBase ImageFile { get; set; }
    }
}