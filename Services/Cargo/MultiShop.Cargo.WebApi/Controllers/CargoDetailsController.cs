﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Cargo.Business.Abstract;
using MultiShop.Cargo.DtoLayer.Dtos.CargoDetailDtos;
using MultiShop.Cargo.EntityLayer.Concrete;

namespace MultiShop.Cargo.WebApi.Controllers
{
	[Authorize]
	[Route("api/[controller]")]
	[ApiController]
	public class CargoDetailsController : ControllerBase
	{
		private readonly ICargoDetailService _cargoDetailService;

		public CargoDetailsController(ICargoDetailService cargoDetailService)
		{
			_cargoDetailService = cargoDetailService;
		}

		[HttpGet]
		public IActionResult CargoDetailList()
		{
			var values = _cargoDetailService.TGetAll();
			return Ok(values);
		}
		[HttpPost]
		public IActionResult CreateCargoDetail(CreateCargoDetailDto createCargoDetailDto)
		{
			CargoDetail cargoDetail = new CargoDetail()
			{
				Barcode = createCargoDetailDto.Barcode,
				CargoCompanyID=createCargoDetailDto.CargoCompanyID,
				ReceiverCustomer=createCargoDetailDto.ReceiverCustomer,
				SenderCustomer = createCargoDetailDto.SenderCustomer
			};
			_cargoDetailService.TInsert(cargoDetail);
			return Ok("Kargo Detayı Başarıyla Oluşturuldu");
		}
		[HttpDelete]
		public IActionResult DeleteCargoDetail(int id)
		{
			_cargoDetailService.TDelete(id);
			return Ok("Kargo Detayı Başarıyla Silindi");
		}
		[HttpGet("{id}")]
		public IActionResult GetCargoDetailById(int id)
		{
			var values = _cargoDetailService.TGetById(id);
			return Ok(values);
		}
		[HttpPut]
		public IActionResult UpdateCargoDetail(UpdateCargoDetailDto updateCargoDetailDto)
		{
			CargoDetail cargoDetail = new CargoDetail()
			{
				Barcode = updateCargoDetailDto.Barcode,
				CargoCompanyID = updateCargoDetailDto.CargoCompanyID,
				ReceiverCustomer = updateCargoDetailDto.ReceiverCustomer,
				SenderCustomer = updateCargoDetailDto.SenderCustomer,
				CargoDetailID=updateCargoDetailDto.CargoDetailID
			};
			_cargoDetailService.TUpdate(cargoDetail);
			return Ok("Kargo Detayı Başarıyla Güncellendi");
		}
	}
}
