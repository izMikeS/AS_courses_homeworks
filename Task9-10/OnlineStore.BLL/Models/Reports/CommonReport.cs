using OnlineStore.BL.Models.Entities;

namespace OnlineStore.BL.Models.Reports
{
    public class CommonReport : ReportBase
    {
        public decimal TotalSalesSum { get; set; }

        public string CategoryName { get; set; }

        public decimal TotalSalesSumAtCategory { get; set; }

        public uint SalesCountAtCategory { get; set; }

        public Product[] Products { get; set; }
    }
}
