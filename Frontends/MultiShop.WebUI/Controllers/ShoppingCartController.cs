using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.BasketDtos;
using MultiShop.WebUI.Services.BasketServices;
using MultiShop.WebUI.Services.CatalogServices.ProductServices;
using MultiShop.WebUI.Services.DiscountServices;

namespace MultiShop.WebUI.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly IProductService _productService;
        private readonly IBasketService _basketService;


        public ShoppingCartController(IProductService productService, IBasketService basketService)
        {
            _productService = productService;
            _basketService = basketService;
           
        }

        public async Task<IActionResult> Index(string code, int discountRate, decimal totalNewPriceWithDiscount)
        {
            ViewBag.code = code;
            ViewBag.discountRate = discountRate;
            ViewBag.totalNewPriceWithDiscount = totalNewPriceWithDiscount;

            ViewBag.directory1 = "Ana Sayfa";
            ViewBag.directory2 = "Sepet";
            ViewBag.directory3 = "Sepetteki Ürünler";

            var values = await _basketService.GetBasket();
            ViewBag.total = values.TotalPrice;

            var totalPriceWithTax = values.TotalPrice + values.TotalPrice / 100 * 10;
            ViewBag.totalPriceWithTax=totalPriceWithTax;

            var Tax =  values.TotalPrice / 100 * 10;
            ViewBag.Tax = Tax;

            return View();
        }

        public async Task<IActionResult> AddBasketItem(string id)
        {
            var values = await _productService.GetByIdProductAsync(id);
            var items = new BasketItemDto
            {
                ProductID = values.ProductID,
                ProductName = values.ProductName,
                Price = values.ProductPrice,
                Quantity = 1,
                ProductImageUrl=values.ProductImageUrl
            };
            await _basketService.AddBasketItem(items);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> RemoveBasketItem(string id)
        {
            await _basketService.RemoveBasketItem(id);
            return RedirectToAction("Index");
        }
    }
}
