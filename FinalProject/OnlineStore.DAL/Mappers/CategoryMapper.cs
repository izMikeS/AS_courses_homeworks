using OnlineStore.DAL.Dtos.Models;

namespace OnlineStore.DAL.Mappers
{
    public static class CategoryMapper
    {
        public static CategoryDto ToDataDto(this Category model)
        {
            return new CategoryDto
            {
                Id = model.Id,
                Name = model.Name,
                ImgUrl = model.ImgUrl
            };
        }
        public static Category ToEntityModel(this CategoryDto model)
        {
            return new Category
            {
                Id = model.Id,
                Name = model.Name,
                ImgUrl = model.ImgUrl 
            };
        }
    }
}
