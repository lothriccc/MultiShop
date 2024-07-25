using MultiShop.Catalog.Dtos.CategortDtos;
using MultiShop.Catalog.Dtos.ProductDtos;

namespace MultiShop.Catalog.Services.ProductServices
{
	public interface IProductService
	{
		Task<List<ResultProductDto>> GetAllProductAsync();
		Task CreateProductAsync(CreateProductDto createProductDto);
		Task UpdateProductAsync(UpdateProductDto updateProductDto);
		Task DeleteProductAync(string id);
		Task<GetByIdProductDto> GetByIdProductAsync(string id);
        Task<List<ResultProductsWithCategoryDto>> GetProductsWithCategoryAsync();
		Task<List<ResultProductsWithCategoryDto>> GetProdutctsWithCategoryByCategoryIdAsync(string categoryid);
    }
}
