using System;

namespace FirstSubtask
{
    public class Product
    {
        public string Name { get; }
        public string Description { get; }
        public string Type { get; }
        public decimal Price { get; }

        public Product(string name, string description, string type, decimal price)
        {
            this.Name = name ?? 
                throw new ArgumentNullException(nameof(name), "The value cannot be null");
            this.Description = description ?? 
                throw new ArgumentNullException(nameof(description), "The value cannot be null");
            this.Type = type ?? 
                throw new ArgumentNullException(nameof(type), "The value cannot be null");
            this.Price = price >=0 ? price : 
                throw new ArgumentException("The price must be greater than or equal to zero", nameof(price));
        }
    }
}
