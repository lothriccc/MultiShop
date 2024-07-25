﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.BrandDtos;
using MultiShop.Catalog.Services.BrandService;

namespace MultiShop.Catalog.Controllers
{
	[Authorize]
	[Route("api/[controller]")]
	[ApiController]
	public class BrandsController : ControllerBase
	{
		private readonly IBrandService _brandService;

		public BrandsController(IBrandService brandService)
		{
			_brandService = brandService;
		}

		[HttpGet]
		public async Task<IActionResult> BrandList()
		{
			var values = await _brandService.GetAllBrandsAsync();
			return Ok(values);
		}
		[HttpGet("{id}")]
		public async Task<IActionResult> GetBrandById(string id)
		{
			var values = await _brandService.GetByIdBrandAsync(id);
			return Ok(values);
		}
		[HttpPost]
		public async Task<IActionResult> CreateBrand(CreateBrandDto createBrandDto)
		{
			await _brandService.CreateBrandAsync(createBrandDto);
			return Ok("Marka başarıyla eklendi");
		}
		[HttpDelete]
		public async Task<IActionResult> DeleteBrand(string id)
		{
			await _brandService.DeleteBrandAync(id);
			return Ok("Marka başarıyla silindi");
		}
		[HttpPut]
		public async Task<IActionResult> UpdateBrand(UpdateBrandDto updateBrandDto)
		{
			await _brandService.UpdateBrandAsync(updateBrandDto);
			return Ok("Marka başarıyla güncellendi");
		}
	}
}