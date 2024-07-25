using MultiShop.Catalog.Dtos.CategortDtos;
using MultiShop.Catalog.Dtos.OfferDiscountDtos;

namespace MultiShop.Catalog.Services.OfferDiscountServices
{
    public interface IOfferDiscountService
    {
        Task<List<ResultOfferDiscountDto>> GetAllOfferDiscountsAsync();
        Task CreateOfferDiscountAsync(CreateOfferDiscountDto createOfferDiscountDto);
        Task UpdateOfferDiscountAsync(UpdateOfferDiscountDto updateOfferDiscountDto);
        Task DeleteOfferDiscountAync(string id);
        Task<GetByIdOfferDiscountDto> GetByIdOfferDiscountAsync(string id);
    }
}
