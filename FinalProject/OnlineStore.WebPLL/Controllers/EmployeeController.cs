using OnlineStore.BLL.Contracts;
using OnlineStore.Common;
using System.Web.Mvc;

namespace OnlineStore.WebPLL.Controllers
{
    [Authorize(Roles = RolesConstants.EMPLOYEE + ", " + RolesConstants.ADMIN)]
    public class EmployeeController : Controller
    {
        IOrderService _orderService;
        public EmployeeController(IOrderService orderService)
        {
            _orderService = orderService;
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ChangeOrderStatus(int orderId, OrderStatus status)
        {

            var order = _orderService.GetById(orderId);

            order.Status = status.ToString();
            _orderService.Update(order);

            return RedirectToAction("List", "Orders");
        }
    }
}