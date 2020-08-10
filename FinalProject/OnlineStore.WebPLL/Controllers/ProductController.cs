using OnlineStore.BLL.Contracts;
using OnlineStore.WebPLL.Helpers;
using OnlineStore.WebPLL.Mappers;
using OnlineStore.WebPLL.Models.FullModels;
using OnlineStore.WebPLL.Models.ShortModels;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace OnlineStore.WebPLL.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly IManufacturerService _manufacturerService;
        private readonly ICategoryService _categoryService;

        public ProductController(IProductService p, IManufacturerService m, ICategoryService c)
        {
            _productService = p;
            _manufacturerService = m;
            _categoryService = c;
        }
        [Authorize(Roles = RolesConstants.EMPLOYEE + ", " + RolesConstants.ADMIN)]
        [HttpGet]
        public ActionResult Create()
        {
            var manufacturers = _manufacturerService.GetAllAtPage(1, 999)
                .Select(m => m.ToViewModel()).ToList(); // todo: only one page
            var categories = _categoryService.GetAllAtPage(1, 999)
                .Select(c => c.ToViewModel()).ToList(); // todo: only one page

            ViewData["manufacturers"] = manufacturers
                .Select(m => new SelectListItem { Text = m.Name, Value = m.Id.ToString() });
            ViewData["categories"] = categories
                .Select(c => new SelectListItem { Text = c.Name, Value = c.Id.ToString() });
            return View();
        }

        [Authorize(Roles = RolesConstants.EMPLOYEE + ", " + RolesConstants.ADMIN)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProductShortViewModel model)
        {
            model.ImgUrl = ImageHelper.SaveImage(model.ImageFile,
                "Products", Server, model.Name);

            _productService.Create(model.ToDto());

            return RedirectToAction("List");
        }

        public ActionResult Details(int id, int page = 1)
        {
            var product = _productService.GetById(id).ToViewModel();
            var productCategory = _categoryService.GetById(product.CategoryId).ToViewModel();
            var productManufacturer = _manufacturerService.GetById(product.ManafacturerId).ToViewModel();

            var model = new ProductFullViewModel
            {
                Product = product,
                Category = productCategory,
                Manufacturer = productManufacturer
            };

            return View(model);
        }

        public ActionResult List(int page = 1, int? categoryId = null, int? manufacturerId = null,
            string searchQuery = null)
        {
            List<ProductShortViewModel> list;

            ViewData["categories"] = _categoryService.GetAllAtPage(1, 999).Select(c => new SelectListItem
            {
                Text = c.Name,
                Value = c.Id.ToString()
            }).ToList(); // todo: only 1 page...

            ViewData["manufacturers"] = _manufacturerService.GetAllAtPage(1, 999).Select(c => new SelectListItem
            {
                Text = c.Name,
                Value = c.Id.ToString()
            }).ToList(); // todo: only 1 page...


            if (searchQuery == null)
            {
                list = _productService.GetAllAtPageWithFilter(page, categoryId: categoryId,
                   manufacturerId: manufacturerId).Select(p => p.ToViewModel()).ToList();
            }
            else
            {
                list = _productService.GetBySearchQuery(searchQuery, page)
                    .Select(p => p.ToViewModel()).ToList();
            }

            return View(list);
        }

        [Authorize(Roles = RolesConstants.EMPLOYEE + ", " + RolesConstants.ADMIN)]
        public ActionResult Delete(int id)
        {
            _productService.Delete(id);

            return RedirectToAction("List");
        }

        [Authorize(Roles = RolesConstants.EMPLOYEE + ", " + RolesConstants.ADMIN)]
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var manufacturers = _manufacturerService.GetAllAtPage(1, 999)
                .Select(m => m.ToViewModel()).ToList(); // todo: all it page!!!
            var categories = _categoryService.GetAllAtPage(1, 999)
                .Select(c => c.ToViewModel()).ToList(); // todo: all at PAGE!!!


            var model = _productService.GetById(id);

            var currentManufacturer = _manufacturerService.GetById(model.ManafacturerId);
            var currentCategory = _categoryService.GetById(model.CategoryId);

            if (!manufacturers.Any(m => m.Id == currentManufacturer.Id))
            {
                manufacturers.Add(currentManufacturer.ToViewModel());
            }

            if (!categories.Any(m => m.Id == currentCategory.Id))
            {
                categories.Add(currentCategory.ToViewModel());
            }


            ViewData["manufacturers"] = manufacturers
                .Select(m => new SelectListItem { Text = m.Name, Value = m.Id.ToString() });
            ViewData["categories"] = categories
                .Select(c => new SelectListItem { Text = c.Name, Value = c.Id.ToString() });

            return View(model.ToViewModel());
        }

        [Authorize(Roles = RolesConstants.EMPLOYEE + ", " + RolesConstants.ADMIN)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ProductShortViewModel model)
        {
            if (model.ImageFile != null)
            {
                model.ImgUrl = ImageHelper.SaveImage(model.ImageFile,
                    "Products", Server, model.Name);
            }

            _productService.Update(model.ToDto());

            return RedirectToAction("List");
        }
    }
}
