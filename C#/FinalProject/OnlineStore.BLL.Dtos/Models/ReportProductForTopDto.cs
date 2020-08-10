namespace OnlineStore.BLL.Dtos.Models
{
    public class ReportProductForTopDto
    {
        public string ProductName { get; set; }
        public string CategoryName { get; set; }
        public decimal SalesSum { get; set; }
        public int SalesCount { get; set; }

    }
}
