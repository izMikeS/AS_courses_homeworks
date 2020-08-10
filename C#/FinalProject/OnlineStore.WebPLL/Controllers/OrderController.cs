using Microsoft.AspNet.Identity;
using OnlineStore.BLL.Contracts;
using OnlineStore.Common;
using OnlineStore.WebPLL.Mappers;
using System.Linq;
using System.Web.Mvc;

namespace OnlineStore.WebPLL.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;
        private readonly IFullOrderService _fullOrderService;
        private readonly IHalfOrderService _orderFullShortService;
        private readonly ICustomerService _customerService;

        public OrderController(IOrderService o, IFullOrderService fo,
            IHalfOrderService fso, ICustomerService c)
        {
            _orderService = o;
            _fullOrderService = fo;
            _orderFullShortService = fso;
            _customerService = c;
        }


        [Authorize]
        public ActionResult Details(int id, string returnUrl)
        {
            var model = _fullOrderService.GetById(id).ToViewModel();

            var customer = _customerService.GetById(model.Order.CustomerId);


            if (User.IsInRole(RolesConstants.ADMIN)
                || User.IsInRole(RolesConstants.EMPLOYEE)
                || User.Identity.GetUserId() == customer.AuthId)
            {
                ViewBag.returnUrl = returnUrl;
                return View(model);
            }

            return RedirectToAction("Login", "Account");
        }


        [Authorize]
        public ActionResult List(int? customerId = null,
            OrderStatus? status = null, int page = 1)
        {
            if (!(User.IsInRole(RolesConstants.ADMIN)
               || User.IsInRole(RolesConstants.EMPLOYEE)))
            {
                customerId = _customerService.GetByAuthId(User.Identity.GetUserId()).Id;
            }

            var list = _orderService.GetAllByStatusAndCustomer(status, customerId, page)
                .Select(c => _orderFullShortService.GetByShortModel(c).ToViewModel())
                .ToList();

            var customers = _customerService.GetAllAtPage(1, 999); //todo: only one page

            ViewData["customers"] = customers.Select(c => new SelectListItem
            {
                Text = c.Email,
                Value = c.Id.ToString()
            }).ToList();

            return View(list);
        }

        [Authorize]
        public ActionResult Buy(int id)
        {
            var customer = _customerService.GetByAuthId(User.Identity.GetUserId());

            var order = _orderService.GetById(id);

            if (order.CustomerId == customer.Id)
            {

                order.Status = OrderStatus.Payed.ToString();

                _orderService.Update(order);

                return RedirectToAction("List", new { customerId = customer.Id });

            }

            return RedirectToAction("Login", "Account");


        }

        [Authorize(Roles = RolesConstants.EMPLOYEE + ", " + RolesConstants.ADMIN)]
        public ActionResult Finish(int id)
        {
            var order = _orderService.GetById(id);

            if (order.Status == OrderStatus.Payed.ToString())
            {

                order.Status = OrderStatus.Finished.ToString();

                _orderService.Update(order);
            }

            return RedirectToAction("List");
        }

        [Authorize(Roles = RolesConstants.EMPLOYEE + ", " + RolesConstants.ADMIN)]
        public ActionResult Delete(int id)
        {
            _orderService.Delete(id);

            return RedirectToAction("List");
        }
    }
}