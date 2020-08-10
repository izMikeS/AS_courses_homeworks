using OnlineStore.WebPLL.IdentityServices;
using System.Web.Mvc;

namespace OnlineStore.WebPLL.Controllers
{
    [Authorize(Roles = RolesConstants.ADMIN)]
    public class AdminController : Controller
    {
        private readonly RoleService _roleService;
        private readonly UserService _userService;

        public AdminController()
        {
            _roleService = new RoleService();
            _userService = new UserService();
        }

        public ActionResult Delete(string customerId)
        {
            _userService.Delete(customerId);
            return RedirectToAction("List", "Customer");
        }

        public ActionResult GrantCustomerRole(string customerId)
        {
            _roleService.GrantRole(RolesConstants.CUSTOMER, customerId, true);
            return RedirectToAction("List", "Customer");

        }

        public ActionResult GrantEmployeeRole(string customerId)
        {
            _roleService.GrantRole(RolesConstants.EMPLOYEE, customerId, true);
            return RedirectToAction("List", "Customer");

        }

        public ActionResult GrantAdminRole(string customerId)
        {
            _roleService.GrantRole(RolesConstants.ADMIN, customerId);
            return RedirectToAction("List", "Customer");
        }
    }
}