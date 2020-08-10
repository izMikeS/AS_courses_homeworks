using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace FirstSubtask
{
    public class FileManager<T> where T : IContract
    {
        public string FilePath { get;}
        private XmlSerializer formatter;
        public FileManager(string filePath)
        {
            FilePath = filePath;
            formatter = new XmlSerializer(typeof(T[]));
        }

        public T[] Load()
        {
            if (!File.Exists(FilePath))
                return new T[0];

            using (StreamReader streamReader = new StreamReader(FilePath))
            {
                return (T[])formatter.Deserialize(streamReader);
            }
        }
        public void AddOrUpdate(T entity)
        {
            T[] entities = Load();

            if (entities.FirstOrDefault(e => e.Name == entity.Name) == null)
            {
                entities = entities.Append(entity).ToArray();
            }
            else
            {
                entities = entities.Where(e => e.Name != entity.Name).Append(entity).ToArray();
            }
            using (StreamWriter streamWriter = new StreamWriter(FilePath, false))
            {
                formatter.Serialize(streamWriter, entities);
            }
        }
        public void SaveFromArray(T[] entities)
        {
            using (StreamWriter streamWriter = new StreamWriter(FilePath, false))
            {
                formatter.Serialize(streamWriter, entities);
            }
        }

    }
}
