using OnlineStore.Common;
using System;

namespace OnlineStore.BLL
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
        public static (int skip, int take) GetSkipAndTakeCounts(int page, int countAtPage)
        {
            var skip = (page - 1) * countAtPage;
            var take = countAtPage;

            return (skip, take);
        }
    }
}
