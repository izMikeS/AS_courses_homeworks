using OnlineStore.Common;
using System.Collections.Generic;

namespace OnlineStore.BLL.Dtos.Models
{
    public class TopProductsReportDto
    {
        public ReportTimeType ReportTime { get; set; }
        public List<ReportProductForTopDto> Products { get; set; }
    }
}
