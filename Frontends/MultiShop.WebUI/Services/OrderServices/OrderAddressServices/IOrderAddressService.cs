using MultiShop.DtoLayer.OrderDtos.OrderAddressDtos;

namespace MultiShop.WebUI.Services.OrderServices.OrderAddressServices
{
    public interface IOrderAddressService
    {
        //Task<List<ResultAddressDto>> GetAllAddressAsync();
        Task CreateAddressAsync(CreateOrderAddressDto createOrderAddressDto);
       // Task UpdateAddressAsync(UpdateAddressDto updateAddressDto);
        //Task DeleteAddressAsync(string id);
        //Task<UpdateAddressDto> GetByIdAddressAsync(string id);
    }
}
