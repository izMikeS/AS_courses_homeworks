using OnlineStore.DAL.Dtos.Models;

namespace OnlineStore.DAL.Mappers
{
    public static class ProductMapper
    {
        public static ProductDto ToDataDto(this Product model)
        {
            return new ProductDto
            {
                Id = model.Id,
                ImgUrl = model.ImgUrl,
                Name = model.Name,
                CategoryId = model.CategoryId,
                Description = model.Description,
                ManafacturerId = model.ManufacturerId,
                Price = model.Price
            };
        }
        public static Product ToEntityModel(this ProductDto model)
        {
            return new Product
            {
                Id = model.Id,
                ImgUrl = model.ImgUrl,
                Name = model.Name,
                CategoryId = model.CategoryId,
                Description = model.Description,
                ManufacturerId = model.ManafacturerId,
                Price = model.Price,
            };
        }
    }
}
