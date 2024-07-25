using MultiShop.Catalog.Dtos.ProductImageDtos;

namespace MultiShop.Catalog.Services.ProductImageServices
{
	public interface IProductImageService
	{
		Task<List<ResultProductImageDto>> GetAllProductImageAsync();
		Task CreateProductImageAsync(CreateProductImageDto createProductImageDto);
		Task UpdateProductImageAsync(UpdateProductImageDto updateProductImageDto);
		Task DeleteProductImageAync(string id);
		Task<GetByIdProductImageDto> GetByIdProductImageAsync(string id);
		Task<GetByIdProductImageDto> GetByIdProductIdProductImageAsync(string id);

	}
}
