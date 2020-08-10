using System.Collections.Generic;
using System.Linq;
using OnlineStore.BLL.Contracts;
using OnlineStore.BLL.Dtos.Models;
using OnlineStore.BLL.Mappers;
using OnlineStore.DAL.Contracts;

namespace OnlineStore.BLL.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRep;

        public ProductService(IProductRepository p)
        {
            _productRep = p;
        }

        public void Create(ProductDto entity)
        {
            _productRep.Create(entity.ToDataDto());
        }

        public void Delete(int id)
        {
            _productRep.Delete(id);
        }

        public List<ProductDto> GetAllAtPage(int page = 1, int countAtPage = 10)
        {
            var skipTake = ProjectUtils.GetSkipAndTakeCounts(page, countAtPage);

            return _productRep.GetAll(skipTake.skip, skipTake.take).Select(p => p.ToDto()).ToList();
        }

        public List<ProductDto> GetBySearchQuery(string searchQuery, int page = 1, int countAtPage = 10)
        {
            var skipTake = ProjectUtils.GetSkipAndTakeCounts(page, countAtPage);

            return _productRep.GetBySearchQuery(searchQuery, skipTake.skip, skipTake.take)
                .Select(p => p.ToDto()).ToList();
        }

        public List<ProductDto> GetAllAtPageWithFilter(int page = 1, int countAtPage = 10,
            int? categoryId = null, int? manufacturerId = null)
        {
            IEnumerable<ProductDto> outputEnum;
            var skipTake = ProjectUtils.GetSkipAndTakeCounts(page, countAtPage);

            if (categoryId.HasValue && manufacturerId.HasValue)
            {
                outputEnum = _productRep.GetAllAtCategoryAndManufacturer(skipTake.skip, skipTake.take,
                    categoryId.Value, manufacturerId.Value).Select(p => p.ToDto());
            }
            else if (categoryId.HasValue)
            {
                outputEnum = _productRep.GetProductsByCategory(categoryId.Value, skipTake.skip, skipTake.take)
                .Select(p => p.ToDto());
            }
            else if (manufacturerId.HasValue)
            {
                outputEnum = _productRep.GetProductsByManufacturer(manufacturerId.Value, skipTake.skip, skipTake.take)
                .Select(p => p.ToDto());
            }
            else
            {
                outputEnum = _productRep.GetAll(skipTake.skip, skipTake.take)
                                    .Select(p => p.ToDto());
            }

            return outputEnum.ToList();
        }

        public ProductDto GetById(int id)
        {
            return _productRep.GetById(id).ToDto();
        }

        public void Update(ProductDto entity)
        {
            _productRep.Update(entity.ToDataDto());
        }
    }
}
