using FirstSubtask.Models;

namespace FirstSubtask.Managers
{
    public class ManufacturersManager : FileManager<Manufacturer>
    {
        public ManufacturersManager(string manufacturersFilePath)
            : base(manufacturersFilePath) { }

    }
}
