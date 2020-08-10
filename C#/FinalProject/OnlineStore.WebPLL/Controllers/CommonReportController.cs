using OnlineStore.BLL.Contracts;
using OnlineStore.BLL.Dtos.Models;
using OnlineStore.Common;
using OnlineStore.WebPLL.Mappers;
using System.Linq;
using System.Web.Mvc;

namespace OnlineStore.WebPLL.Controllers
{
    [Authorize(Roles = RolesConstants.EMPLOYEE + ", " + RolesConstants.ADMIN)]
    public class CommonReportController : Controller
    {
        private readonly ICommonReportService _commonReportService;
        private readonly ICategoryService _categoryService;

        public CommonReportController(ICommonReportService cr, ICategoryService cs)
        {
            _commonReportService = cr;
            _categoryService = cs;
        }

        public ActionResult Index(ReportTimeType? reportTime = null, int? categoryId = null, int page = 1)
        {
            ViewData["categories"] = _categoryService.GetAllAtPage(1, 999).Select(c => c.ToViewModel())
                .Select(c => new SelectListItem { Text = c.Name, Value = c.Id.ToString() }); //todo: ONLY ONE PAGE

            CommonReportDto report = null;

            if (reportTime.HasValue && categoryId.HasValue)
            {
                 report = _commonReportService.GetReport(reportTime.Value, categoryId.Value, page);
                ViewBag.IsReported = true;
            }
            else
            {
                ViewBag.IsReported = false;
            }

            return View(report);

        }
    }
}