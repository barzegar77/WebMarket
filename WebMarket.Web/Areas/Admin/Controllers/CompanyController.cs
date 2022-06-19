using Microsoft.AspNetCore.Mvc;
using WebMarket.DataAccess.Services;
using WebMarket.DataAccess.Services.Interface;
using WebMarket.Models;

namespace WebMarket.Web.Controllers
{
    [Area("Admin")]
    public class CompanyController : Controller
    {
        private readonly ICompanyService _companyService;

        public CompanyController(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        public IActionResult Index()
        {
            IEnumerable<Company> companies = _companyService.GetAll();
            return View(companies);
        }

        //Get
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        //post
        [HttpPost]
        public IActionResult Create(Company obj)
        {

            if (ModelState.IsValid)
            {
                _companyService.Add(obj);
                TempData["success"] = "کمپانی جدید با موفقیت ایجاد شد";
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

            var companyFromDbFirst = _companyService.GetFirstOrDefault(u => u.Id == id);

            if (companyFromDbFirst == null)
            {
                return NotFound();
            }

            return View(companyFromDbFirst);
        }

        //post
        [HttpPost]
        public IActionResult Edit(Company obj)
        {

            if (ModelState.IsValid)
            {
                _companyService.Update(obj);
                TempData["success"] = "کمپانی با موفقیت ویرایش شد";
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


            var companyFromDbFirst = _companyService.GetFirstOrDefault(u => u.Id == id);
            //var categoryFromDbSingle = _db.Categories.SingleOrDefault(u => u.Id == id);

            if (companyFromDbFirst == null)
            {
                return NotFound();
            }

            return View(companyFromDbFirst);
        }

        //post
        [HttpPost]
        public IActionResult DeletePost(int? id)
        {
            var obj = _companyService.GetFirstOrDefault(u => u.Id == id);
            _companyService.Remove(obj);
            TempData["success"] = "کمپانی با موفقیت حذف شد";
            return RedirectToAction("Index");
        }

    }
}
