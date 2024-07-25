using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Cargo.Business.Abstract;
using MultiShop.Cargo.DtoLayer.Dtos.CargoCustomerDtos;
using MultiShop.Cargo.EntityLayer.Concrete;

namespace MultiShop.Cargo.WebApi.Controllers
{
	[Authorize]
	[Route("api/[controller]")]
	[ApiController]
	public class CargoCustomersController : ControllerBase
	{
		private readonly ICargoCustomerService _cargoCustomerService;

		public CargoCustomersController(ICargoCustomerService cargoCustomerService)
		{
			_cargoCustomerService = cargoCustomerService;
		}
		[HttpGet]
		public IActionResult CargoCustomerList()
		{
			var values = _cargoCustomerService.TGetAll();
			return Ok(values);
		}
		[HttpPost]
		public IActionResult CreateCargoCustomer(CreateCargoCustomerDto createCargoCustomerDto)
		{
			CargoCustomer cargoCustomer = new CargoCustomer()
			{
				Name = createCargoCustomerDto.Name,
				Address = createCargoCustomerDto.Address,
				City	= createCargoCustomerDto.City,
				District = createCargoCustomerDto.District,
				Email = createCargoCustomerDto.Email,
				Phone = createCargoCustomerDto.Phone,
				Surname = createCargoCustomerDto.Surname

			};
			_cargoCustomerService.TInsert(cargoCustomer);
			return Ok("Kargo Müşterisi Başarıyla Oluşturuldu");
		}
		[HttpDelete]
		public IActionResult DeleteCargoCustomer(int id)
		{
			_cargoCustomerService.TDelete(id);
			return Ok("Kargo Müşterisi Başarıyla Silindi");
		}
		[HttpGet("{id}")]
		public IActionResult GetCargoCustomerById(int id)
		{
			var values = _cargoCustomerService.TGetById(id);
			return Ok(values);
		}
		[HttpPut]
		public IActionResult UpdateCargoCustomer(UpdateCargoCustomerDto updateCargoCustomerDto)
		{
			CargoCustomer cargoCustomer = new CargoCustomer()
			{
			CargoCustomerID=updateCargoCustomerDto.CargoCustomerID,
			Name=updateCargoCustomerDto.Name,
			Address=updateCargoCustomerDto.Address,
			City = updateCargoCustomerDto.City,
			Surname=updateCargoCustomerDto.Surname,
			Phone = updateCargoCustomerDto.Phone,
			Email = updateCargoCustomerDto.Email,
			District = updateCargoCustomerDto.District
			
			};
			_cargoCustomerService.TUpdate(cargoCustomer);
			return Ok("Kargo Şirketi Başarıyla Güncellendi");
		}
	}
}
