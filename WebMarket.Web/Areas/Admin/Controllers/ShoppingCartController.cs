using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WebMarket.DataAccess.Services;
using WebMarket.DataAccess.Services.Interface;
using WebMarket.Models;
using WebMarket.Models.ViewModels;

namespace WebMarket.Web.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class ShoppingCartController : Controller
    {
        private readonly IShoppingCartService _shoppingCart;

        public ShoppingCartController(IShoppingCartService shoppingCart)
        {
            _shoppingCart = shoppingCart;
        }

        public IActionResult Index()
        {
            return View();
        }


    }
}
