﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Cargo.Business.Abstract;
using MultiShop.Cargo.DtoLayer.Dtos.CargoOperationDtos;
using MultiShop.Cargo.EntityLayer.Concrete;

namespace MultiShop.Cargo.WebApi.Controllers
{
	[Authorize]
	[Route("api/[controller]")]
	[ApiController]
	public class CargoOperationsController : ControllerBase
	{
		private readonly ICargoOperationService _cargoOperationService;

		public CargoOperationsController(ICargoOperationService cargoOperationService)
		{
			_cargoOperationService = cargoOperationService;
		}

		[HttpGet]
		public IActionResult CargoOperationList()
		{
			var values = _cargoOperationService.TGetAll();
			return Ok(values);
		}
		[HttpPost]
		public IActionResult CreateCargoOperation(CreateCargoOperationDto createCargoOperationDto)
		{
			CargoOperation cargoOperation = new CargoOperation()
			{
				Barcode = createCargoOperationDto.Barcode,
				Description = createCargoOperationDto.Description,
				OperationDate = createCargoOperationDto.OperationDate,

			};
			_cargoOperationService.TInsert(cargoOperation);
			return Ok("Kargo Durumu Başarıyla Oluşturuldu");
		}
		[HttpDelete]
		public IActionResult DeleteCargoOperation(int id)
		{
			_cargoOperationService.TDelete(id);
			return Ok("Kargo Durumu Başarıyla Silindi");
		}
		[HttpGet("{id}")]
		public IActionResult GetCargoOperationById(int id)
		{
			var values = _cargoOperationService.TGetById(id);
			return Ok(values);
		}
		[HttpPut]
		public IActionResult UpdateCargoOperation(UpdateCargoOperationDto updateCargoOperationDto)
		{
			CargoOperation cargoOperation = new CargoOperation()
			{
				Barcode = updateCargoOperationDto.Barcode,
				Description = updateCargoOperationDto.Description,
				OperationDate = updateCargoOperationDto.OperationDate,
				CargoOperationID = updateCargoOperationDto.CargoOperationID
			};
			_cargoOperationService.TUpdate(cargoOperation);
			return Ok("Kargo Durumu Başarıyla Güncellendi");
		}
	}
}
