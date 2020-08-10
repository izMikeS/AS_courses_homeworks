using OnlineStore.DAL.Dtos.Models;
using System.Collections.Generic;

namespace OnlineStore.DAL.Contracts
{
    public interface IManufacturerRepository : IRepository<ManufacturerDto, int>
    {
        List<ManufacturerDto> GetManufacturersByCategory(int categoryId, int skip, int take);
    }
}
