using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.ProductDtos;
using MultiShop.DtoLayer.CatalogDtos.ProductImageDtos;
using Newtonsoft.Json;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [AllowAnonymous]
    [Area("Admin")]
    [Route("Admin/ProductImage")]
    public class ProductImageController : Controller
	{
        private readonly IHttpClientFactory _httpClientFactory;

        public ProductImageController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public IActionResult Index()
		{
			return View();
		}
        [Route("Deneme")]
		public async Task<IActionResult> Deneme()
		{
            
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7070/api/ProductImages/ProductImagesByProductId?id=668b8c1c7b5490720de796c6");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<GetByIdProductImageDto>(jsonData);
                return View(values);
            }
            return View();
        }

	}
}
