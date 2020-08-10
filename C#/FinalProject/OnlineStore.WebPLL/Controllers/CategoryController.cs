using OnlineStore.BLL.Contracts;
using OnlineStore.WebPLL.Helpers;
using OnlineStore.WebPLL.Mappers;
using OnlineStore.WebPLL.Models.FullModels;
using OnlineStore.WebPLL.Models.ShortModels;
using System.Linq;
using System.Web.Mvc;

namespace OnlineStore.WebPLL.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IProductService _productService;

        public CategoryController(ICategoryService c, IProductService p)
        {
            _categoryService = c;
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
        public ActionResult Create(CategoryShortViewModel model)
        {
            model.ImgUrl = ImageHelper.SaveImage(model.ImageFile,
                                         "Categories", Server, model.Name);

            _categoryService.Create(model.ToDto());

            return RedirectToAction("List");
        }

        public ActionResult Details(int id, int categoriesPage = 1)
        {
            var category = _categoryService.GetById(id).ToViewModel();
            var products = _productService.GetAllAtPageWithFilter(page: categoriesPage, categoryId: category.Id)
                .Select(p => p.ToViewModel())
                .ToList();

            var model = new CategoryFullViewModel
            {
                Category = category,
                Products = products
            };
            return View(model);
        }

        public ActionResult List(int page = 1)
        {
            var list = _categoryService.GetAllAtPage(page)
                .Select(c => c.ToViewModel()).ToList();

            return View(list);
        }

        [Authorize(Roles = RolesConstants.EMPLOYEE + ", " + RolesConstants.ADMIN)]
        public ActionResult Delete(int id)
        {
            _categoryService.Delete(id);

            return RedirectToAction("List");
        }

        [Authorize(Roles = RolesConstants.EMPLOYEE + ", " + RolesConstants.ADMIN)]
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var model = _categoryService.GetById(id);
            return View(model.ToViewModel());
        }

        [Authorize(Roles = RolesConstants.EMPLOYEE + ", " + RolesConstants.ADMIN)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CategoryShortViewModel model)
        {
            if (model.ImageFile != null)
            {
                model.ImgUrl = ImageHelper.SaveImage(model.ImageFile,
                                             "Categories", Server, model.Name);
            }

            _categoryService.Update(model.ToDto());

            return RedirectToAction("List");
        }


    }
}