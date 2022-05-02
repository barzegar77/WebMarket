using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebMarket.DataAccess.Services;
using WebMarket.DataAccess.Services.Interface;
using WebMarket.Models;

namespace WebMarket.Web.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly ICoverTypeService _coverTypeService;

        public ProductController(IProductService productService
            , ICategoryService categoryService, ICoverTypeService coverTypeService)
        {
            _productService = productService;
            _categoryService = categoryService;
            _coverTypeService = coverTypeService;   
        }

        public IActionResult Index()
        {
            IEnumerable<Product> productList = _productService.GetAll();
            return View(productList);
        }

        //Get
        public IActionResult Upsert(int? id)
        {
            IEnumerable<SelectListItem> CategoryList = _categoryService.GetAll().Select(
                u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString()
                }
                );

            IEnumerable<SelectListItem> CoverTypeList = _coverTypeService.GetAll().Select(
          u => new SelectListItem
          {
              Text = u.Name,
              Value = u.Id.ToString()
          }
          );

            if (id == null || id == 0)
            {
                //create
                ViewBag.CategoryList = CategoryList;
                ViewBag.CoverTypeList = CoverTypeList;
                return View();
            }
            else
            {
                //update
            }


            return View();
        }

        //post
        [HttpPost]
        public IActionResult Upsert(Product obj)
        {
            //if (obj.Name == obj.DisplayOrder.ToString())
            //{
            //    ModelState.AddModelError("Name", "مقدار فیلد ترتیب نمایش نباید با مقدار فیلد نام برابر باشد");
            //}

            if (ModelState.IsValid)
            {
                _productService.Update(obj);
                TempData["success"] = "محصول با موفقیت ویرایش شد";
                return RedirectToAction("Index");
            }
            return View(obj);
        }


        //Get
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }


            var productFromDbFirst = _productService.GetFirstOrDefault(u => u.Id == id);
            //var categoryFromDbSingle = _db.Categories.SingleOrDefault(u => u.Id == id);

            if (productFromDbFirst == null)
            {
                return NotFound();
            }

            return View(productFromDbFirst);
        }

        //post
        [HttpPost]
        public IActionResult DeletePost(int? id)
        {
            var obj = _productService.GetFirstOrDefault(u => u.Id == id);
            _productService.Remove(obj);
            TempData["success"] = "محصول با موفقیت حذف شد";
            return RedirectToAction("Index");
        }

    }
}
