using OnlineStore.BLL.Dtos.Models;

namespace OnlineStore.BLL.Services
{
    public interface IReportProductStatisticService
    {
        ProductStatisticReportDto GetReportByProductId(int productId);
    }
}