using System.Collections.Generic;
using System.Linq;
using OnlineStore.BLL.Contracts;
using OnlineStore.BLL.Dtos.Models;
using OnlineStore.BLL.Mappers;
using OnlineStore.DAL.Contracts;

namespace OnlineStore.BLL.Services
{
    public class ManufacturerService : IManufacturerService
    {
        private readonly IManufacturerRepository _manufacturerRep;

        public ManufacturerService(IManufacturerRepository m)
        {
            _manufacturerRep = m;
        }

        public void Create(ManufacturerDto entity)
        {
            _manufacturerRep.Create(entity.ToDataDto());
        }

        public void Delete(int id)
        {
            _manufacturerRep.Delete(id);
        }

        public ManufacturerDto GetById(int id)
        {
            return _manufacturerRep.GetById(id).ToDto();
        }

        public void Update(ManufacturerDto entity)
        {
            _manufacturerRep.Update(entity.ToDataDto());
        }

        public List<ManufacturerDto> GetAllAtPage(int page = 1, int countAtPage = 10)
        {
            var skipTake = ProjectUtils.GetSkipAndTakeCounts(page, countAtPage);

            return _manufacturerRep.GetAll(skipTake.skip, skipTake.take).Select(p => p.ToDto()).ToList();
        }

        public List<ManufacturerDto> GetManufacturersByCategory(int categoryId, int page = 1, int countAtPage = 10)
        {
            var skipTake = ProjectUtils.GetSkipAndTakeCounts(page, countAtPage);

            return _manufacturerRep.GetManufacturersByCategory(categoryId, skipTake.skip, skipTake.take)
                .Select(m => m.ToDto()).ToList();
        }
    }
}
