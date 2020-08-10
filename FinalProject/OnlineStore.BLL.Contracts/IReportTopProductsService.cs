using OnlineStore.BLL.Dtos.Models;
using OnlineStore.Common;

namespace OnlineStore.BLL.Contracts
{
    public interface IReportTopProductsService
    {
        TopProductsReportDto GetReport(ReportTimeType timeSpan, int page = 1, int countAtPage = 10);
    }
}