using OnlineStore.BLL.Contracts;
using OnlineStore.WebPLL.Helpers;
using OnlineStore.WebPLL.Mappers;
using OnlineStore.WebPLL.Models.FullModels;
using OnlineStore.WebPLL.Models.ShortModels;
using System.Linq;
using System.Web.Mvc;

namespace OnlineStore.WebPLL.Controllers
{
    public class ManufacturerController : Controller
    {
        private readonly IManufacturerService _manufacturerService;
        private readonly IProductService _productService;
        public ManufacturerController(IManufacturerService m, IProductService p)
        {
            _manufacturerService = m;
            _productService = p;
        }

        [Authorize(Roles = RolesConstants.EMPLOYEE + ", " + RolesConstants.ADMIN)]
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [Authorize(Roles = RolesConstants.EMPLOYEE + ", " + RolesConstants.ADMIN)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ManufacturerShortViewModel model)
        {
            model.ImgUrl = ImageHelper.SaveImage(model.ImageFile,
             "Manufacturers", Server, model.Name);

            _manufacturerService.Create(model.ToDto());

            return RedirectToAction("List");
        }


        public ActionResult Details(int id, int productsPage = 1)
        {
            var model = _manufacturerService.GetById(id).ToViewModel();
            var list = _productService.GetAllAtPageWithFilter(page: productsPage, manufacturerId: id)
                .Select(p => p.ToViewModel())
                .ToList();

            return View(new ManufacturerFullViewModel
            {
                Manufacturer = model,
                Products = list
            });
        }

        public ActionResult List(int page = 1)
        {
            var list = _manufacturerService.GetAllAtPage(page).Select(m => m.ToViewModel()).ToList();

            return View(list);
        }

        [Authorize(Roles = RolesConstants.ADMIN + ", " + RolesConstants.EMPLOYEE)]
        public ActionResult Delete(int id)
        {
            _manufacturerService.Delete(id);

            return RedirectToAction("List", "Manufacturer");
        }

        [Authorize(Roles = RolesConstants.EMPLOYEE + ", " + RolesConstants.ADMIN)]
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var model = _manufacturerService.GetById(id);
            return View(model.ToViewModel());
        }

        [Authorize(Roles = RolesConstants.EMPLOYEE + ", " + RolesConstants.ADMIN)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ManufacturerShortViewModel model)
        {
            if (model.ImageFile != null)
            {
                model.ImgUrl = ImageHelper.SaveImage(model.ImageFile,
                "Manufacturers", Server, model.Name);
            }

            _manufacturerService.Update(model.ToDto());

            return RedirectToAction("List");
        }
    }
}