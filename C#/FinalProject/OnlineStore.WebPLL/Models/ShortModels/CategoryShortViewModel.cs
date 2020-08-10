using System.ComponentModel;
using System.Web;

namespace OnlineStore.WebPLL.Models.ShortModels
{
    public class CategoryShortViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [DisplayName("Image")]
        public string ImgUrl { get; set; }

        public HttpPostedFileBase ImageFile { get; set; }
    }
}
