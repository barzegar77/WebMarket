using Microsoft.AspNetCore.Mvc;
using WebMarket.DataAccess.Services;
using WebMarket.DataAccess.Services.Interface;
using WebMarket.Models;

namespace WebMarket.Web.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public IActionResult Index()
        {
            IEnumerable<Category> CategoryList = _categoryService.GetAll();
            return View(CategoryList);
        }

        //Get
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        //post
        [HttpPost]
        public IActionResult Create(Category obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("Name", "مقدار فیلد ترتیب نمایش نباید با مقدار فیلد نام برابر باشد");
            }

            if (ModelState.IsValid)
            {
                _categoryService.Add(obj);
                TempData["success"] = "دسته جدید با موفقیت ایجاد شد";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        //Get
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            //var categoryFromDb = _db.Categories.Find(id);
            var categoryFromDbFirst = _categoryService.GetFirstOrDefault(u => u.Id == id);
            //var categoryFromDbSingle = _db.Categories.SingleOrDefault(u => u.Id == id);

            if (categoryFromDbFirst == null)
            {
                return NotFound();
            }

            return View(categoryFromDbFirst);
        }

        //post
        [HttpPost]
        public IActionResult Edit(Category obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("Name", "مقدار فیلد ترتیب نمایش نباید با مقدار فیلد نام برابر باشد");
            }

            if (ModelState.IsValid)
            {
                _categoryService.Update(obj);
                TempData["success"] = "دسته با موفقیت ویرایش شد";
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


            var categoryFromDbFirst = _categoryService.GetFirstOrDefault(u => u.Id == id);
            //var categoryFromDbSingle = _db.Categories.SingleOrDefault(u => u.Id == id);

            if (categoryFromDbFirst == null)
            {
                return NotFound();
            }

            return View(categoryFromDbFirst);
        }

        //post
        [HttpPost]
        public IActionResult DeletePost(int? id)
        {
            var obj = _categoryService.GetFirstOrDefault(u => u.Id == id);
            _categoryService.Remove(obj);
            TempData["success"] = "دسته با موفقیت حذف شد";
            return RedirectToAction("Index");
        }

    }
}
