﻿using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.CategortDtos;
using MultiShop.Catalog.Dtos.FeatureDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.FeatureServices
{
	public class FeatureService:IFeatureService
	{
		private readonly IMongoCollection<Feature> _featureCollection;
		private readonly IMapper _mapper;

		public FeatureService(IMapper mapper, IDatabaseSettings _databaseSettings)
		{
			var client = new MongoClient(_databaseSettings.ConnectionString);
			var database = client.GetDatabase(_databaseSettings.DatabaseName);
			_featureCollection = database.GetCollection<Feature>(_databaseSettings.FeatureCollectionName);
			_mapper = mapper;
		}

		public async Task CreateFeatureAsync(CreateFeatureDto createFeatureDto)
		{
			var value = _mapper.Map<Feature>(createFeatureDto);
			await _featureCollection.InsertOneAsync(value);
		}

		public async Task DeleteFeatureAync(string id)
		{
			await _featureCollection.DeleteOneAsync(x => x.FeatureID == id);
		}

		

		public async  Task<List<ResultFeatureDto>> GetAllFeaturesAsync()
		{
			var values = await _featureCollection.Find(x => true).ToListAsync();
			return _mapper.Map<List<ResultFeatureDto>>(values);
		}

		public async Task<GetByIdFeatureDto> GetByIdFeatureAsync(string id)
		{
			var values = await _featureCollection.Find<Feature>(x => x.FeatureID == id).FirstOrDefaultAsync();
			return _mapper.Map<GetByIdFeatureDto>(values);
		}

		public async Task UpdateFeatureAsync(UpdateFeatureDto updateFeatureDto)
		{
			var values = _mapper.Map<Feature>(updateFeatureDto);
			await _featureCollection.FindOneAndReplaceAsync(x => x.FeatureID == updateFeatureDto.FeatureID, values);
		}
	}
}