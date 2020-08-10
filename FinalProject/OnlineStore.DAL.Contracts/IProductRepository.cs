using OnlineStore.DAL.Dtos.Models;
using System;
using System.Collections.Generic;

namespace OnlineStore.DAL.Contracts
{
    public interface IProductRepository : IRepository<ProductDto, int>
    {
        List<ProductDto> GetProductsByManufacturer(int manufacturerId, int skip, int take);
        List<ProductDto> GetProductsByCategory(int categoryId, int skip, int take);
        List<ProductDto> GetAllAtCategoryAndManufacturer(int skip, int take, int categoryId, int manufacturerId);
        List<ProductDto> GetBySearchQuery(string query, int skip, int take);
    }
}
