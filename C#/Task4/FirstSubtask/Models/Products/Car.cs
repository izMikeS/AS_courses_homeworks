using System;

namespace FirstSubtask.Models.Products
{
    public class Car : Product
    {
        private double _horsepower;
        private TransmissionType _transmission;

        public Car() { }

        public Car(Manufacturer manufacturer, string name, string description, string type, decimal price,
                   double horsepower, TransmissionType transmission)
            : base(manufacturer, name, description, type, price)
        {
            Horsepower = horsepower;
            Transmission = transmission;
        }

        public enum TransmissionType
        {
            None,
            Manual,
            Automatic
        }

        public double Horsepower
        {
            get => _horsepower;
            set => _horsepower = value > 0 ? value :
                throw new ArgumentException("This argument must be greater than or equal to zero", nameof(_horsepower));
        }

        public TransmissionType Transmission
        {
            get => _transmission;
            set => _transmission = value != TransmissionType.None ? value :
                throw new ArgumentException("The value cannot be none", nameof(_transmission));

        }

        public override string ToString()
        {
            return $"{base.ToString()}Horsepower: {_horsepower}\nTransmission: {_transmission}";
        }
    }
}
