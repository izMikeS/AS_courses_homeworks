using OnlineStore.BLL.Dtos.Models;
using OnlineStore.WebPLL.Models.ShortModels;

namespace OnlineStore.WebPLL.Mappers
{
    public static class CategoryMapper
    {
        public static CategoryShortViewModel ToViewModel(this CategoryDto model)
        {
            return new CategoryShortViewModel
            {
                Id = model.Id,
                Name = model.Name,
                ImgUrl = model.ImgUrl
            };
        }
        public static CategoryDto ToDto(this CategoryShortViewModel model)
        {
            return new CategoryDto
            {
                Id = model.Id,
                Name = model.Name,
                ImgUrl = model.ImgUrl
            };
        }
    }
}
