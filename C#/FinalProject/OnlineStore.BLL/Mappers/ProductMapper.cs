namespace OnlineStore.BLL.Mappers
{
    public static class ProductMapper
    {
        public static DAL.Dtos.Models.ProductDto ToDataDto(this Dtos.Models.ProductDto model)
        {
            return new DAL.Dtos.Models.ProductDto
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
        public static Dtos.Models.ProductDto ToDto(this DAL.Dtos.Models.ProductDto model)
        {
            return new BLL.Dtos.Models.ProductDto
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
