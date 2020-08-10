namespace OnlineStore.BLL.Mappers
{
    public static class ManufacturerMapper
    {
        public static DAL.Dtos.Models.ManufacturerDto ToDataDto(this Dtos.Models.ManufacturerDto model)
        {
            return new DAL.Dtos.Models.ManufacturerDto
            {
                Id = model.Id,
                ImgUrl = model.ImgUrl,
                Name = model.Name
            };
        }
        public static Dtos.Models.ManufacturerDto ToDto(this DAL.Dtos.Models.ManufacturerDto model)
        {
            return new BLL.Dtos.Models.ManufacturerDto
            {
                Id = model.Id,
                ImgUrl = model.ImgUrl,
                Name = model.Name
            };
        }
    }
}
