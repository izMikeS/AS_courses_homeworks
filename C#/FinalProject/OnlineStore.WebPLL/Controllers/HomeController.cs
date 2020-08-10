using OnlineStore.BLL.Contracts;
using System.IO;
using System.Web;
using System.Web.Mvc;

namespace OnlineStore.WebPLL.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return RedirectToAction("List", "Product");
        }
    }
}