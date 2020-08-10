using OnlineStore.DAL.Contracts;
using OnlineStore.DAL.Dtos.Models;
using OnlineStore.DAL.Mappers;
using System.Collections.Generic;
using System.Linq;

namespace OnlineStore.DAL.Repositories
{
    public class CategoryRepository : BaseRepository, ICategoryRepository
    {
        public CategoryRepository(StoreDbContext s) : base(s)
        {
        }

        public void Create(CategoryDto entity)
        {
            Context.Categories.Add(entity.ToEntityModel());
            Context.SaveChanges();
        }

        public void Delete(int id)
        {
            Context.Categories.Remove(Context.Categories.Single(e => e.Id == id));
            Context.SaveChanges();
        }

        public List<CategoryDto> GetAll(int skip, int take)
        {
            return Context.Categories
                .OrderBy(p => p.Name)
                .Skip(skip).Take(take)
                .ToList().Select(c => c.ToDataDto())
                .ToList();
        }

        public CategoryDto GetById(int id)
        {
            return Context.Categories.Single(e => e.Id == id).ToDataDto();
        }

        public void Update(CategoryDto entity)
        {
            var category = Context.Categories.Single(c => c.Id == entity.Id);

            category.Name = entity.Name;
            category.ImgUrl = entity.ImgUrl;

            Context.SaveChanges();
        }
    }
}
