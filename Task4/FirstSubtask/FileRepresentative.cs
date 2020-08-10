using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace FirstSubtask
{
    public class FileRepresentative<T> where T : IContract
    {
        private readonly XmlSerializer _formatter;
        public string FilePath { get; }
        public FileRepresentative(string filePath)
        {
            _formatter = new XmlSerializer(typeof(List<T>));
            FilePath = filePath;
        }

        public List<T> Load()
        {
            if (!File.Exists(FilePath))
            {
                return new List<T>();
            }

            using (StreamReader streamReader = new StreamReader(FilePath))
            {
                return (List<T>)_formatter.Deserialize(streamReader);
            }
        }

        public void SaveFromList(List<T> entities)
        {
            using (StreamWriter streamWriter = new StreamWriter(FilePath, false))
            {
                _formatter.Serialize(streamWriter, entities);
            }
        }

    }
}
