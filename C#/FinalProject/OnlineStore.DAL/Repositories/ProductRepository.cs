using OnlineStore.DAL.Dtos.Models;
using OnlineStore.DAL.Contracts;
using System.Linq;
using OnlineStore.DAL.Mappers;
using System.Collections.Generic;
using System;

namespace OnlineStore.DAL.Repositories
{
    public class ProductRepository : BaseRepository, IProductRepository
    {
        public ProductRepository(StoreDbContext s) : base(s)
        {
        }

        public void Create(ProductDto entity)
        {
            Context.Products.Add(entity.ToEntityModel());
            Context.SaveChanges();
        }

        public void Delete(int id)
        {
            Context.Products.Remove(Context.Products.Single(e => e.Id == id));
            Context.SaveChanges();
        }

        public List<ProductDto> GetAll(int skip, int take)
        {
            return Context.Products.OrderBy(p => p.Name)
                .Skip(skip).Take(take).ToList()
                .Select(c => c.ToDataDto()).ToList();
        }

        public ProductDto GetById(int id)
        {
            return Context.Products.Single(e => e.Id == id).ToDataDto();
        }

        public void Update(ProductDto entity)
        {
            var product = Context.Products.Single(c => c.Id == entity.Id);

            product.Name = entity.Name;
            product.ManufacturerId = entity.ManafacturerId;
            product.Price = entity.Price;
            product.CategoryId = entity.CategoryId;
            product.Description = entity.Description;
            product.ImgUrl = entity.ImgUrl;

            Context.SaveChanges();
        }

        public List<ProductDto> GetAllAtCategoryAndManufacturer(int skip, int take, int categoryId, int manufacturerId)
        {
            return Context.Products.Where(p => p.CategoryId == categoryId
             && p.ManufacturerId == manufacturerId)
                  .OrderBy(c => c.Name)
                  .Skip(skip).Take(take)
                  .ToList().Select(p => p.ToDataDto())
                  .ToList();
        }

        public List<ProductDto> GetProductsByCategory(int categoryId, int skip, int take)
        {
            return Context.Products.Where(p => p.CategoryId == categoryId)
                .OrderBy(c => c.Name)
                .Skip(skip).Take(take)
                .ToList()
                .Select(p => p.ToDataDto())
                .ToList();
        }

        public List<ProductDto> GetProductsByManufacturer(int manufacturerId, int skip, int take)
        {
            return Context.Products.Where(p => p.ManufacturerId == manufacturerId)
                .OrderBy(m => m.Name)
                .Skip(skip).Take(take)
                .ToList()
                .Select(p => p.ToDataDto())
                .ToList();
        }

        public List<ProductDto> GetBySearchQuery(string query, int skip, int take)
        {
            return Context.Products.Where(p =>
              p.Name.Trim().ToUpper().Contains(query.ToUpper()))
                .OrderBy(p => p.Name)
                .Skip(skip).Take(take).ToList()
                .Select(p => p.ToDataDto())
                .ToList();

        }
    }
}
