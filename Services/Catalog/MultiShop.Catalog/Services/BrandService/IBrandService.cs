using MultiShop.Catalog.Dtos.BrandDtos;

namespace MultiShop.Catalog.Services.BrandService
{
	public interface IBrandService
	{
		Task<List<ResultBrandDto>> GetAllBrandsAsync();
		Task CreateBrandAsync(CreateBrandDto createBrandDto);
		Task UpdateBrandAsync(UpdateBrandDto updateBrandDto);
		Task DeleteBrandAync(string id);
		Task<GetByIdBrandDto> GetByIdBrandAsync(string id);
	}
}
