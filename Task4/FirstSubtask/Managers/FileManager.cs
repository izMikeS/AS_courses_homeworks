using System.Collections.Generic;
using System.Linq;

namespace FirstSubtask.Managers
{
    public class FileManager<T> where T : IContract
    {
        private readonly FileRepresentative<T> _tFile;

        public FileManager(string filePath)
        {
            _tFile = new FileRepresentative<T>(filePath);
        }

        public void AddOrUpdate(T entity)
        {
            List<T> entities = _tFile.Load();

            if (!entities.Any(e => e.Name == entity.Name))
            {
                entities.Add(entity);
            }
            else
            {
                entities.RemoveAll(e => e.Name == entity.Name);
                entities.Add(entity);
            }
            _tFile.SaveFromList(entities);
        }

        public virtual T[] Search(string searchRequest)
        {
            var entities = Load();

            return entities.Where(e => e.Name.Contains(searchRequest)).ToArray();
        }

        public void Remove(T entity)
        {
            var entities = Load();
            entities.RemoveAll(e => e.Name == entity.Name);
            _tFile.SaveFromList(entities);
        }

        public List<T> Load()
        {
            return _tFile.Load();
        }
    }
}
