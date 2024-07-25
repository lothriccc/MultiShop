using MultiShop.DtoLayer.CatalogDtos.CategoryDtos;

namespace MultiShop.WebUI.Services.CatalogServices.CategoryServices
{
	public interface ICategoryService
	{
		Task<List<ResultCategoryDto>> GetAllCategoriesAsync();
		Task CreateCategoryAsync(CreateCategoryDto createCategoryDto);
		Task UpdateCategoryAsync(UpdateCategoryDto updateCategoryDto);
		Task DeleteCategoryAync(string id);
		Task<UpdateCategoryDto> GetByIdCategoryAsync(string id);
	}
}
