using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.CategoryDtos;
using MultiShop.WebUI.Services.CatalogServices.CategoryServices;
using Newtonsoft.Json;

namespace MultiShop.WebUI.ViewComponents.DefaultViewComponents
{
    public class _CategoiresDefaultComponentPartial:ViewComponent
    {
        private readonly ICategoryService _categoryService;

        public _CategoiresDefaultComponentPartial(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        public async Task< IViewComponentResult> InvokeAsync()
        {

            var values = await _categoryService.GetAllCategoriesAsync();
            return View(values);
        }
    }
}
