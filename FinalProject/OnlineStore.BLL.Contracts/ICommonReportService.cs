using OnlineStore.BLL.Dtos.Models;
using OnlineStore.Common;

namespace OnlineStore.BLL.Contracts
{
    public interface ICommonReportService
    {
        CommonReportDto GetReport(ReportTimeType timeSpan, int categoryId,
            int productsPage = 1, int countAtPage = 10);
    }
}
