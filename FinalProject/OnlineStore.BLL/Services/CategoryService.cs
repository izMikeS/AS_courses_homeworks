using System.Collections.Generic;
using System.Linq;
using OnlineStore.BLL.Contracts;
using OnlineStore.BLL.Dtos.Models;
using OnlineStore.BLL.Mappers;
using OnlineStore.DAL.Contracts;
namespace OnlineStore.BLL.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRep;

        public CategoryService(ICategoryRepository c)
        {
            _categoryRep = c;
        }

        public void Create(CategoryDto entity)
        {
            _categoryRep.Create(entity.ToDataDto());
        }

        public void Delete(int id)
        {
            _categoryRep.Delete(id);
        }

        public CategoryDto GetById(int id)
        {
            return _categoryRep.GetById(id).ToDto();
        }

        public void Update(CategoryDto entity)
        {
            _categoryRep.Update(entity.ToDataDto());
        }

        public List<CategoryDto> GetAllAtPage(int page = 1, int countAtPage = 10)
        {
            var skipTake = ProjectUtils.GetSkipAndTakeCounts(page, countAtPage);

            return _categoryRep.GetAll(skipTake.skip, skipTake.take)
                .Select(p => p.ToDto()).ToList();
        }
    }
}
