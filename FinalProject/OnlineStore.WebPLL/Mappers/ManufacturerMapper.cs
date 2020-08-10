using OnlineStore.BLL.Dtos.Models;
using OnlineStore.WebPLL.Models;
using OnlineStore.WebPLL.Models.ShortModels;

namespace OnlineStore.WebPLL.Mappers
{
    public static class ManufacturerMapper
    {
        public static ManufacturerShortViewModel ToViewModel(this ManufacturerDto manufacturer)
        {
            return new ManufacturerShortViewModel
            {
                Id = manufacturer.Id,
                ImgUrl = manufacturer.ImgUrl,
                Name = manufacturer.Name
            };
        }

        public static ManufacturerDto ToDto(this ManufacturerShortViewModel manufacturer)
        {
            return new ManufacturerDto
            {
                Id = manufacturer.Id,
                Name = manufacturer.Name,
                ImgUrl = manufacturer.ImgUrl
            };
        }
    }
}