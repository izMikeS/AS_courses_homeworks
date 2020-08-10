namespace OnlineStore.BLL.Mappers
{
    public static class CategoryMapper
    {
        public static DAL.Dtos.Models.CategoryDto ToDataDto(this Dtos.Models.CategoryDto model)
        {
            return new DAL.Dtos.Models.CategoryDto
            {
                Id = model.Id,
                Name = model.Name,
                ImgUrl = model.ImgUrl
            };
        }
        public static Dtos.Models.CategoryDto ToDto(this DAL.Dtos.Models.CategoryDto model)
        {
            return new BLL.Dtos.Models.CategoryDto
            {
                Id = model.Id,
                Name = model.Name,
                ImgUrl = model.ImgUrl
            };
        }
    }
}
