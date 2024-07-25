﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.FeatureDtos;
using MultiShop.Catalog.Services.FeatureServices;

namespace MultiShop.Catalog.Controllers
{
	[Authorize]
	[Route("api/[controller]")]
	[ApiController]
	public class FeaturesController : Controller
	{
		private readonly IFeatureService _featureService;

		public FeaturesController(IFeatureService featureService)
		{
			_featureService = featureService;
		}

		[HttpGet]
		public async Task<IActionResult> FeatureList()
		{
			var values = await _featureService.GetAllFeaturesAsync();
			return Ok(values);
		}
		[HttpGet("{id}")]
		public async Task<IActionResult> GetFeatureById(string id)
		{
			var values = await _featureService.GetByIdFeatureAsync(id);
			return Ok(values);
		}
		[HttpPost]
		public async Task<IActionResult> CreateFeature(CreateFeatureDto createFeatureDto)
		{
			await _featureService.CreateFeatureAsync(createFeatureDto);
			return Ok("Kategori başarıyla eklendi");
		}
		[HttpDelete]
		public async Task<IActionResult> DeleteFeature(string id)
		{
			await _featureService.DeleteFeatureAync(id);
			return Ok("Kategori başarıyla silindi");
		}
		[HttpPut]
		public async Task<IActionResult> UpdateFeature(UpdateFeatureDto updateFeatureDto)
		{
			await _featureService.UpdateFeatureAsync(updateFeatureDto);
			return Ok("Kategori başarıyla güncellendi");
		}
	}
}
