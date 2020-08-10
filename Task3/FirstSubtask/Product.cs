using System;

namespace FirstSubtask
{
    [Serializable]
    public class Product : IContract
    {
        private string name;
        private string description;
        private string type;
        private decimal price;
        public string Name
        {
            get => name;
            set => name = value ??
            throw new ArgumentNullException(nameof(name), "The value cannot be null");
        }
        public string Description 
        { 
            get => description; 
            set => description = value ??
                throw new ArgumentNullException(nameof(description), "The value cannot be null"); 
        }
        public string Type 
        { 
            get => type; 
            set => type = value ??
                throw new ArgumentNullException(nameof(type), "The value cannot be null");
        }
        public decimal Price 
        {
            get => price;
            set => price = value >= 0 ? value :
                throw new ArgumentException("The price must be greater than or equal to zero", nameof(price));
        }


        public Product() { }
        public Product(string name, string description, string type, decimal price)
        {
            Name = name;
            Description = description;
            Type = type;
            Price = price;
        }

    }
}
