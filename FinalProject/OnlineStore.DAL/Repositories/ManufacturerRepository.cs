using OnlineStore.DAL.Dtos.Models;
using OnlineStore.DAL.Contracts;
using OnlineStore.DAL.Mappers;
using System.Linq;
using System.Collections.Generic;

namespace OnlineStore.DAL.Repositories
{
    public class ManufacturerRepository : BaseRepository, IManufacturerRepository
    {
        public ManufacturerRepository(StoreDbContext s) : base(s)
        {
        }

        public void Create(ManufacturerDto entity)
        {
            Context.Manufacturers.Add(entity.ToEntityModel());
            Context.SaveChanges();
        }

        public void Delete(int id)
        {
            Context.Manufacturers.Remove(Context.Manufacturers.Single(e => e.Id == id));
            Context.SaveChanges();
        }

        public List<ManufacturerDto> GetAll(int skip, int take)
        {
            return Context.Manufacturers
                .OrderBy(p => p.Name)
                .Skip(skip).Take(take)
                .ToList().Select(c => c.ToDataDto())
                .ToList();
        }

        public ManufacturerDto GetById(int id)
        {
            return Context.Manufacturers.Single(e => e.Id == id).ToDataDto();
        }

        public void Update(ManufacturerDto entity)
        {
            var manufacturer = Context.Manufacturers.Single(c => c.Id == entity.Id);

            manufacturer.Name = entity.Name;
            manufacturer.ImgUrl = entity.ImgUrl;
            Context.SaveChanges();
        }

        public List<ManufacturerDto> GetManufacturersByCategory(int categoryId, int skip, int take)
        {
            return Context.Manufacturers.Join(Context.Products,
                m => m.Id,
                p => p.ManufacturerId,
                (Manufacturer, p) => new { Manufacturer, p.CategoryId })
                 .Where(e => e.CategoryId == categoryId)
                 .OrderBy(e => e.Manufacturer.Name)
                 .Skip(skip).Take(take).ToList()
                 .Select(e => e.Manufacturer.ToDataDto())
                 .ToList();

            //todo: test
        }

    }
}
