using OnlineStore.BLL.Contracts;
using OnlineStore.BLL.Dtos.Models;
using OnlineStore.BLL.Services;
using System.Linq;
using System.Web.Mvc;

namespace OnlineStore.WebPLL.Controllers
{
    [Authorize(Roles = RolesConstants.EMPLOYEE + ", " + RolesConstants.ADMIN)]
    public class StatisticReportController : Controller
    {
        private readonly IReportProductStatisticService _reportProductStatisticService;
        private readonly IProductService _productService;

        public StatisticReportController(IReportProductStatisticService reportProductStatisticService,
            IProductService productService)
        {
            _reportProductStatisticService = reportProductStatisticService;
            _productService = productService;
        }

        public ActionResult Index(int? productId = null)
        {
            ViewData["products"] = _productService.GetAllAtPage(1, 999).Select(p => new SelectListItem
            {
                Text = p.Name,
                Value = p.Id.ToString()
            }); // todo: ONLY 1 page

            ProductStatisticReportDto report = null;

            if (productId.HasValue)
            {
                report = _reportProductStatisticService.GetReportByProductId(productId.Value);
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