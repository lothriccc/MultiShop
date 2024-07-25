using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.FeatureDtos;
using MultiShop.WebUI.Services.CatalogServices.FeatureServices;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
	[AllowAnonymous]
	[Area("Admin")]
	[Route("Admin/Feature")]
	public class FeatureController : Controller
	{
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IFeatureService _featureService;

        public FeatureController(IHttpClientFactory httpClientFactory, IFeatureService featureService)
        {
            _httpClientFactory = httpClientFactory;
            _featureService = featureService;
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            FeatureViewBagList();

            var values = await _featureService.GetAllFeatureAsync();
            return View(values);

        }
        [Route("CreateFeature")]
        [HttpGet]
        public IActionResult CreateFeature()
        {
            FeatureViewBagList();
            return View();
        }
        [Route("CreateFeature")]
        [HttpPost]
        public async Task<IActionResult> CreateFeature(CreateFeatureDto createFeatureDto)
        {
            await _featureService.CreateFeatureAsync(createFeatureDto);
            return RedirectToAction("Index", "Feature", new { area = "Admin" });


        }
        [Route("DeleteFeature/{id}")]
        public async Task<IActionResult> DeleteFeature(string id)
        {
            await _featureService.DeleteFeatureAsync(id);
            return RedirectToAction("Index", "Feature", new { area = "Admin" });

        }
        [Route("UpdateFeature/{id}")]
        [HttpGet]
        public async Task<IActionResult> UpdateFeature(string id)
        {
            FeatureViewBagList();
            var values = await _featureService.GetByIdFeatureAsync(id);

            return View(values);
        }
        [Route("UpdateFeature/{id}")]
        [HttpPost]

        public async Task<IActionResult> UpdateFeature(UpdateFeatureDto updateFeatureDto)
        {
            await _featureService.UpdateFeatureAsync(updateFeatureDto);
            return RedirectToAction("Index", "Feature", new { area = "Admin" });

        }
        void FeatureViewBagList()
        {
            ViewBag.v1 = "Ana Sayfa";
            ViewBag.v2 = "Öne Çıkanlar";
            ViewBag.v3 = "Öne Çıkan Listesi";
            ViewBag.v0 = "Öne Çıkan işlemleri";
        }
    }
}
