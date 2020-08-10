using System;

namespace FirstSubtask.Models
{
    [Serializable]
    public class Manufacturer : IContract
    {
        private string _name;

        public Manufacturer() { }

        public Manufacturer(string name)
        {
            Name = name;
        }

        public string Name
        {
            get => _name;
            set => _name = value ??
                throw new ArgumentNullException(nameof(_name), "The value cannot be null");
        }

    }
}
