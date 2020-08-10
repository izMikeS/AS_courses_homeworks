using OnlineStore.BL.ReportGenerators;
using System;
using OnlineStore.BL.Enums;

namespace OnlineStore.PL
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var cReportGenerator = new CommonReportGenerator())
            {
                var report = cReportGenerator.GetReport(ReportTimeType.Year, "Мобільні телефони");

                Console.WriteLine($"{report.CategoryName} -- {report.TotalSalesSum}");
                foreach (var item in report.Products)
                {
                    Console.WriteLine($"{item.Name} -- {item.SalesCount} -- {item.SalesSum}");
                }
            }
            Console.WriteLine(new string('-', 50));
            using (var topNReportGenerator = new TopNReportGenerator())
            {
                var top10Report = topNReportGenerator.GetReport(ReportTimeType.Year, 10);

                foreach (var item in top10Report.Products)
                {
                    Console.WriteLine($"{item.CategoryName} || {item.ProductName} -- {item.SalesCount} -- {item.SalesSum}");
                }
            }
            Console.WriteLine(new string('-', 50));
            using(var statisticReportGenerator = new StatisticReportGenerator())
            {
                var statisticReport = statisticReportGenerator.GetReport("Мобільний телефон SamsungXs");

                Console.WriteLine($"{statisticReport.WeekSalesCount} -- {statisticReport.WeekSalesSum}");
                Console.WriteLine($"{statisticReport.MonthSalesCount} -- {statisticReport.MonthSalesSum}");
                Console.WriteLine($"{statisticReport.YearSalesCount} -- {statisticReport.YearSalesSum}");
            }
            Console.WriteLine(new string('-', 50));
            Console.ReadKey();
        }
    }
}
