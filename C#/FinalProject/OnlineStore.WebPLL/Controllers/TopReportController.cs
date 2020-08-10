using OnlineStore.BLL.Contracts;
using OnlineStore.BLL.Dtos.Models;
using OnlineStore.Common;
using System.Web.Mvc;

namespace OnlineStore.WebPLL.Controllers
{
    [Authorize(Roles = RolesConstants.EMPLOYEE + ", " + RolesConstants.ADMIN)]
    public class TopReportController : Controller
    {
        private readonly IReportTopProductsService _topProductsService;

        public TopReportController(IReportTopProductsService topProductService)
        {
            _topProductsService = topProductService;
        }
        public ActionResult Index(ReportTimeType? reportTime = null, int page = 1)
        {
            TopProductsReportDto topProducts = null;
            if(reportTime.HasValue)
            { 
            topProducts = _topProductsService.GetReport(reportTime.Value, page);
                ViewBag.IsReported = true;
            }
            else
            {
                ViewBag.IsReported = false;
            }

            return View(topProducts);
        }
    }
}