using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MultiShop.DtoLayer.CatalogDtos.CategoryDtos;
using MultiShop.DtoLayer.CatalogDtos.ProductDtos;
using MultiShop.WebUI.Services.CatalogServices.CategoryServices;
using MultiShop.WebUI.Services.CatalogServices.ProductServices;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/Product")]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;

        public ProductController(IProductService productService, ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            ProductViewBagList();

            var values = await _productService.GetAllProductAsync();
                return View(values);
            
        }
        [Route("ProductListWithCategory")]
        public async Task<IActionResult> ProductListWithCategory()
        {
            ProductViewBagList();
            var values = await _productService.GetAllProductAsync();
            return View(values);
        }
        [Route("CreateProduct")]
        [HttpGet]
        public async Task<IActionResult> CreateProduct()
        {
            ProductViewBagList();
            var values = await _categoryService.GetAllCategoriesAsync();
            List<SelectListItem> categoryValues=(from x in values
                                                 select new SelectListItem
                                                 {
                                                     Text=x.CateoryName,
                                                    Value=x.CategoryID
                                                }).ToList();
            ViewBag.CategoryValues = categoryValues;
            return View();
        }

        [Route("CreateProduct")]
        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductDto createproductDto)
        {
            await _productService.CreateProductAsync(createproductDto);
            return RedirectToAction("Index", "Product", new { area = "Admin" });
        }
        [Route("DeleteProduct/{id}")]
        public async Task<IActionResult> DeleteProduct(string id)
        {
            await _productService.DeleteProductAsync(id);
            return RedirectToAction("Index", "Product", new { area = "Admin" });
        }
        [Route("UpdateProduct/{id}")]
        [HttpGet]
        public async Task<IActionResult> UpdateProduct(string id)
        {
            ProductViewBagList();
            var values = await _categoryService.GetAllCategoriesAsync();
            List<SelectListItem> categoryValues = (from x in values
                                                   select new SelectListItem
                                                   {
                                                       Text = x.CateoryName,
                                                       Value = x.CategoryID
                                                   }).ToList();
            ViewBag.CategoryValues = categoryValues;

       
            var listValues = await _productService.GetByIdProductAsync(id);

            return View(listValues);
        }
        [Route("UpdateProduct/{id}")]
        [HttpPost]

        public async Task<IActionResult> UpdateProduct(UpdateProductDto updateProductDto)
        {
            await _productService.UpdateProductAsync(updateProductDto);
            return RedirectToAction("Index", "Product", new { area = "Admin" });

        }
        void ProductViewBagList()
        {
            ViewBag.v1 = "Ana Sayfa";
            ViewBag.v2 = "Ürünler";
            ViewBag.v3 = "Ürün Listesi";
            ViewBag.v0 = "Ürün işlemleri";
        }
    }
}
