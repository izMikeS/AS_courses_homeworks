using OnlineStore.Common;
using System.Collections.Generic;

namespace OnlineStore.BLL.Dtos.Models
{
    public class CommonReportDto
    {
        public ReportTimeType ReportTime { get; set; }

        public decimal TotalSalesSum { get; set; }

        public string CategoryName { get; set; }

        public decimal TotalSalesSumAtCategory { get; set; }

        public uint SalesCountAtCategory { get; set; }

        public List<ReportProductDto> Products { get; set; }

    }
}
