using OnlineStore.BL.Enums;
using System;

namespace OnlineStore.BL
{
    internal static class ProjectUtils
    {
        public static DateTime GetStartReportDateTime(ReportTimeType timeSpan)
        {
            DateTime result;
            switch (timeSpan)
            {
                case ReportTimeType.Week:
                    result = DateTime.Now.AddDays(-7);
                    break;
                case ReportTimeType.Month:
                    result = DateTime.Now.AddMonths(-1);
                    break;
                case ReportTimeType.Year:
                    result = DateTime.Now.AddYears(-1);
                    break;
                default:
                    result = DateTime.Now;
                    break;
            }
            return result;
        }
    }
}
