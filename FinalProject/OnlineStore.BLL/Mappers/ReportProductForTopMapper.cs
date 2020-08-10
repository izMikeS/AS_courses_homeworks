namespace OnlineStore.BLL.Mappers
{
    public static class ReportProductForTopMapper
    {
        public static DAL.Dtos.Models.ReportProductForTopDto ToDataDto(this Dtos.Models.ReportProductForTopDto model)
        {
            return new DAL.Dtos.Models.ReportProductForTopDto
            {
                CategoryName = model.CategoryName,
                ProductName = model.ProductName,
                SalesCount = model.SalesCount,
                SalesSum = model.SalesSum
            };
        }
        public static Dtos.Models.ReportProductForTopDto ToDto(this DAL.Dtos.Models.ReportProductForTopDto model)
        {
            return new BLL.Dtos.Models.ReportProductForTopDto
            {
                CategoryName = model.CategoryName,
                ProductName = model.ProductName,
                SalesCount = model.SalesCount,
                SalesSum = model.SalesSum
            };
        }
    }
}
