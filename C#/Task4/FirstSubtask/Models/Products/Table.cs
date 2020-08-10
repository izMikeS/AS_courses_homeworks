using System;

namespace FirstSubtask.Models.Products
{
    public class Table : Product
    {
        private string _material;
        private double _height;
        private double _width;

        public Table() { }

        public Table(Manufacturer manufacruter, string name, string description, string type, decimal price,
                     string material, double height, double width)
            : base(manufacruter, name, description, type, price)
        {
            Material = material;
            Height = height;
            Width = width;
        }

        public string Material
        {
            get => _material;
            set => _material = value ??
                throw new ArgumentNullException(nameof(_material), "The value cannot be null");
        }

        public double Height
        {
            get => _height;
            set => _height = value > 0 ? value :
                throw new ArgumentException("This argument must be greater than zero", nameof(_height));

        }

        public double Width
        {
            get => _width;
            set => _width = value > 0 ? value :
                throw new ArgumentException("This argument must be greater than zero", nameof(_width));
        }

        public override string ToString()
        {
            return $"{base.ToString()}Material: {_material}\nHeight: {_height}\nWidth: {Width}";
        }
    }
}