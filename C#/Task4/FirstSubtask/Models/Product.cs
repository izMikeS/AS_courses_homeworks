using FirstSubtask.Managers;
using FirstSubtask.Models.Products;
using System;
using System.Xml.Serialization;

namespace FirstSubtask.Models
{
    [Serializable]
    [XmlInclude(typeof(Car))]
    [XmlInclude(typeof(Smartphone))]
    [XmlInclude(typeof(Table))]
    public abstract class Product : IContract
    {
        protected Manufacturer _manufacturer;
        protected string _name;
        protected string _description;
        protected string _type;
        protected decimal _price;

        public Product() { }

        public Product(Manufacturer manufacturer, string name, string description, string type, decimal price)
        {
            Manufacturer = manufacturer;
            Name = name;
            Description = description;
            Type = type;
            Price = price;
        }

        public Manufacturer Manufacturer
        {
            get => _manufacturer;
            set
            {
                _manufacturer = value ??
                throw new ArgumentNullException(nameof(_manufacturer), "The value cannot be null");
            }
        }

        public string Name
        {
            get => _name;
            set => _name = value ??
            throw new ArgumentNullException(nameof(_name), "The value cannot be null");
        }

        public string Description
        {
            get => _description;
            set => _description = value ??
                throw new ArgumentNullException(nameof(_description), "The value cannot be null");
        }

        public string Type
        {
            get => _type;
            set => _type = value ??
                throw new ArgumentNullException(nameof(_type), "The value cannot be null");
        }

        public decimal Price
        {
            get => _price;
            set => _price = value >= 0 ? value :
                throw new ArgumentException("The price must be greater than or equal to zero", nameof(_price));
        }

        public override string ToString()
        {
            return $"Manufacturer: {_manufacturer.Name}\nName: {_name}\nDescription: {_description}\nType: {_type}\nPrice: {_price}\n";
        }


    }
}
