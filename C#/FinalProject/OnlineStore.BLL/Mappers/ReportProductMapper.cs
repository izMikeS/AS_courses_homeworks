namespace OnlineStore.BLL.Mappers
{
    public static class ReportProductMapper
    {
        public static DAL.Dtos.Models.ReportProductDto ToDataDto(this Dtos.Models.ReportProductDto model)
        {
            return new DAL.Dtos.Models.ReportProductDto
            {
              ManafacturerName = model.ManafacturerName,
              Name = model.Name,
              SalesCount = model.SalesCount,
              SalesSum = model.SalesSum
            };
        }
        public static Dtos.Models.ReportProductDto ToDto(this DAL.Dtos.Models.ReportProductDto model)
        {
            return new BLL.Dtos.Models.ReportProductDto
            {
                ManafacturerName = model.ManafacturerName,
                Name = model.Name,
                SalesCount = model.SalesCount,
                SalesSum = model.SalesSum
            };
        }
    }
}
