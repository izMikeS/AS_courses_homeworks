using OnlineStore.BLL.Dtos.Models;
using System.Collections.Generic;

namespace OnlineStore.BLL.Contracts
{
    public interface IManufacturerService : IService<ManufacturerDto, int>
    {
        List<ManufacturerDto> GetManufacturersByCategory(int categoryId, int page = 1, int countAtPage = 10);
    }
}
