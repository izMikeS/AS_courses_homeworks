using OnlineStore.DAL.Dtos.Models;

namespace OnlineStore.DAL.Mappers
{
    public static class ManufacturerMapper
    {
        public static ManufacturerDto ToDataDto(this Manufacturer model)
        {
            return new ManufacturerDto
            {
                Id = model.Id,
                ImgUrl = model.ImgUrl,
                Name = model.Name
            };
        }
        public static Manufacturer ToEntityModel(this ManufacturerDto model)
        {
            return new Manufacturer
            {
                Id = model.Id,
                ImgUrl = model.ImgUrl,
                Name = model.Name
            };
        }
    }
}
