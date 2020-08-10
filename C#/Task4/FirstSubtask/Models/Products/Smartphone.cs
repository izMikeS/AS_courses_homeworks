using System;

namespace FirstSubtask.Models.Products
{
    public class Smartphone : Product
    {
        private float _screenDiagonal;
        private float _mainCameraMp;
        private float _frontCameraMp;

        public Smartphone() { }

        public Smartphone(Manufacturer manufacturer, string name, string description, string type,
                          decimal price, float screenDiagonal, float mainCameraMp, float frontCameraMp)
            : base(manufacturer, name, description, type, price)
        {
            ScreenDiagonal = screenDiagonal;
            MainCameraMp = mainCameraMp;
            FrontCameraMp = frontCameraMp;
        }

        public float ScreenDiagonal
        {
            get => _screenDiagonal;
            set => _screenDiagonal = value > 0 ? value :
                throw new ArgumentException("This argument must be greater than zero", nameof(_screenDiagonal));
        }

        public float MainCameraMp
        {
            get => _mainCameraMp;
            set => _mainCameraMp = value > 0 ? value :
                throw new ArgumentException("This argument must be greater than zero", nameof(_mainCameraMp));
        }

        public float FrontCameraMp
        {
            get => _frontCameraMp;
            set => _frontCameraMp = value > 0 ? value :
                throw new ArgumentException("This argument must be greater than zero", nameof(_frontCameraMp));
        }


        public override string ToString()
        {
            return $"{base.ToString()}Screen diagonal: {_screenDiagonal}\nMain camera mp: {_mainCameraMp}\nfrontcameramp: {_frontCameraMp}";
        }

    }
}
