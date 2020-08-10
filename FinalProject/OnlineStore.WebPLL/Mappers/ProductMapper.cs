using OnlineStore.BLL.Dtos.Models;
using OnlineStore.WebPLL.Models;
using OnlineStore.WebPLL.Models.ShortModels;

namespace OnlineStore.WebPLL.Mappers
{
    public static class ProductMapper
    {
        public static ProductShortViewModel ToViewModel(this ProductDto model)
        {
            return new ProductShortViewModel
            {
                Id = model.Id,
                ImgUrl = model.ImgUrl,
                Name = model.Name,
                CategoryId = model.CategoryId,
                Description = model.Description,
                ManafacturerId = model.ManafacturerId,
                Price = model.Price
            };
        }
        public static ProductDto ToDto(this ProductShortViewModel model)
        {
            return new ProductDto
            {
                Id = model.Id,
                ImgUrl = model.ImgUrl,
                Name = model.Name,
                CategoryId = model.CategoryId,
                Description = model.Description,
                ManafacturerId = model.ManafacturerId,
                Price = model.Price
            };
        }
    }
}
