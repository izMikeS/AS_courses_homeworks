using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using OnlineStore.BLL.Contracts;
using OnlineStore.WebPLL.Models;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineStore.WebPLL.Controllers
{
    [Authorize(Roles = RolesConstants.ADMIN)]
    public class CustomerController : Controller
    {
        private readonly ICustomerService _customerService;
        public CustomerController(ICustomerService c)
        {
            _customerService = c;
        }

        public ActionResult List()
        {
            var list = HttpContext.GetOwinContext()
                .GetUserManager<ApplicationUserManager>().Users
                .Select(u => new UserViewModel
                {
                    Id = u.Id,
                    Login = u.Email,
                    Roles = u.Roles
                }).ToArray();

            string adminRoleId;
            string employeeRoleId;

            using (var context = new IdentityDbContext())
            {
                var roleStore = new RoleStore<IdentityRole>(context);
                var roleManager = new RoleManager<IdentityRole>(roleStore);

                adminRoleId = roleManager.Roles.Single(r => r.Name == RolesConstants.ADMIN).Id;
                employeeRoleId = roleManager.Roles.Single(r => r.Name == RolesConstants.EMPLOYEE).Id;
            }

            ViewBag.AdminRoleId = adminRoleId;
            ViewBag.EmployeeRoleId = employeeRoleId;

            return View(list);
        }
    }
}