using MultiShop.DtoLayer.CargoDtos.CargoCustomerDtos;
using System.Net.Http;

namespace MultiShop.WebUI.Services.CargoServices.CargoCustomerServices
{
    public class CargoCustomerService : ICargoCustomerService
    {
        private readonly HttpClient _httpClient;
        public CargoCustomerService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<GetCargoCustomerById> GetByIdCargoCustomerAsync(string id)
        {
            var responseMessage = await _httpClient.GetAsync("CargoCustomers/GetCargoCustomerById?id="+id );
            var values = await responseMessage.Content.ReadFromJsonAsync<GetCargoCustomerById>();
            return values;
        }
    }
}
