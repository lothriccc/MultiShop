using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.ProductDetailDtos;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [AllowAnonymous]
    [Area("Admin")]
    [Route("Admin/ProductDetail")]
    public class ProductDetailController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ProductDetailController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            ViewBag.v1 = "Ana Sayfa";
            ViewBag.v2 = "Ürün Detayları";
            ViewBag.v3 = "Ürün Detay Listesi";
            ViewBag.v0 = "Ürün Detay işlemleri";

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7070/api/ProductDetails");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultProductDetailDto>>(jsonData);
                return View(values);
            }
            return View();
        }
        [Route("CreateProductDetail")]
        [HttpGet]
        public IActionResult CreateProductDetail()
        {
            ViewBag.v1 = "Ana Sayfa";
            ViewBag.v2 = "ürün Detayları";
            ViewBag.v3 = "Yeni Ürün Detayı Girişi";
            ViewBag.v0 = "Ürün Detay işlemleri";
            return View();
        }
        [Route("CreateProductDetail")]
        [HttpPost]
        public async Task<IActionResult> CreateProductDetail(CreateProductDetailDto createProductDetailDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createProductDetailDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7070/api/ProductDetails", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "ProductDetail", new { area = "Admin" });
            }
            return View();
        }
        [Route("DeleteProductDetail/{id}")]
        public async Task<IActionResult> DeleteProductDetail(string id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync("https://localhost:7070/api/ProductDetails?id=" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "ProductDetail", new { area = "Admin" });
            }
            return View();
        }
        [Route("UpdateProductDetail/{id}")]
        [HttpGet]
        public async Task<IActionResult> UpdateProductDetail(string id)
        {
            ViewBag.v1 = "Ana Sayfa";
            ViewBag.v2 = "Ürün Detayları";
            ViewBag.v3 = "Ürün Detayı Güncelleme";
            ViewBag.v0 = "Ürün Detay işlemleri";
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7070/api/ProductDetails/GetProductDetailByProductId?id=" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateProductDetailDto>(jsonData);
                return View(values);
            }
            return View();
        }
        [Route("UpdateProductDetail/{id}")]
        [HttpPost]

        public async Task<IActionResult> UpdateProductDetail(UpdateProductDetailDto updateProductDetailDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateProductDetailDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:7070/api/ProductDetails/", stringContent);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("ProductListWithCategory", "Product", new { area = "Admin" });
            }
            return View();
        }
    }
}
