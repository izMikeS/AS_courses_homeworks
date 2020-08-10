using OnlineStore.BLL.Dtos.Models;
using System.Collections.Generic;

namespace OnlineStore.BLL.Contracts
{
    public interface IProductService : IService<ProductDto, int>
    {
        List<ProductDto> GetAllAtPageWithFilter(int page = 1, int countAtPage = 10, int? categoryId = null, int? manufacturerId = null);
        List<ProductDto> GetBySearchQuery(string searchQuery, int page = 1, int countAtPage = 10);
    }
}
