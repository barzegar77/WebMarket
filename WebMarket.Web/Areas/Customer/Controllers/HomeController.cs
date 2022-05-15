using Microsoft.AspNetCore.Mvc;
using WebMarket.DataAccess.Services.Interface;
using WebMarket.Models.ViewModels;

namespace WebMarket.Web.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class HomeController : Controller
    {
        private readonly IProductService _productSrvice;

        public HomeController(IProductService productSrvice)
        {
            _productSrvice = productSrvice;
        }

        public IActionResult Index()
        {
            var products = _productSrvice.GetAll();
            return View(products);
        }

        [HttpGet]
        public IActionResult ProductDetails(int id)
        {
            ShoppingCartVM shoppingCart = new ShoppingCartVM
            {
                Product = _productSrvice.GetFirstOrDefault(p => p.Id == id),
                Count = 1
            };
            return View(shoppingCart);
        }
    }
}
