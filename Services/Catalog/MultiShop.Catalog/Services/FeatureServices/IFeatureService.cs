﻿using MultiShop.Catalog.Dtos.CategortDtos;
using MultiShop.Catalog.Dtos.FeatureDtos;

namespace MultiShop.Catalog.Services.FeatureServices
{
	public interface IFeatureService
	{
		Task<List<ResultFeatureDto>> GetAllFeaturesAsync();
		Task CreateFeatureAsync(CreateFeatureDto createFeatureDto);
		Task UpdateFeatureAsync(UpdateFeatureDto updateFeatureDto);
		Task DeleteFeatureAync(string id);
		Task<GetByIdFeatureDto> GetByIdFeatureAsync(string id);
	}
}
