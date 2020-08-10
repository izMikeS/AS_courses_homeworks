using OnlineStore.BL.Models.Entities;

namespace OnlineStore.BL.Models.Reports
{
    public class TopNReport : ReportBase
    {
        public ProductForTop[] Products { get; set; }
    }
}
