using MultiShop.Catalog.Dtos.CategortDtos;

namespace MultiShop.Catalog.Services.CategoryServices
{
    public interface ICategoryService
    {
        Task<List<ResultCategoryDto>> GetAllCategoriesAsync();
        Task CreateCategoryAsync(CreateCategoryDto createCategoryDto);
        Task UpdateCategoryAsync(UpdateCategoryDto updateCategoryDto);
        Task DeleteCategoryAync(string id);
        Task<GetByIdCategoryDto> GetByIdCategoryAsync(string id);
    }
}
