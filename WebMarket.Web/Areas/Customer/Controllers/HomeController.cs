using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WebMarket.DataAccess.Services.Interface;
using WebMarket.Models;
using WebMarket.Models.ViewModels;

namespace WebMarket.Web.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class HomeController : Controller
    {
        private readonly IProductService _productSrvice;
        private readonly IShoppingCartService _shoppingCartService;

        public HomeController(IProductService productSrvice, IShoppingCartService shoppingCartService)
        {
            _productSrvice = productSrvice;
            _shoppingCartService = shoppingCartService;
        }

        public IActionResult Index()
        {
            var products = _productSrvice.GetAll();
            return View(products);
        }

        [HttpGet]
        public IActionResult ProductDetails(int productId)
        {
            ShoppingCart shoppingCart = new ShoppingCart
            {
                Product = _productSrvice.GetFirstOrDefault(p => p.Id == productId),
                ProductId = productId,
                Count = 1
            };
            return View(shoppingCart);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public IActionResult ProductDetails(ShoppingCart shoppingCart)
        {
            var claimIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimIdentity.FindFirst(ClaimTypes.NameIdentifier);
            shoppingCart.ApplicationUserId = claim.Value;

            ShoppingCart cartFromDb = _shoppingCartService.GetFirstOrDefault(
                u => u.ApplicationUserId == claim.Value && u.ProductId == shoppingCart.ProductId);

            if(cartFromDb == null)
            {
                _shoppingCartService.Add(shoppingCart);
            }
            else
            {
                _shoppingCartService.IncrementCount(cartFromDb, shoppingCart.Count);
            }
            

            return RedirectToAction("Index");
        }
    }
}
