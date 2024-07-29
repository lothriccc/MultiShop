﻿using Dapper;
using MultiShop.Discount.Context;
using MultiShop.Discount.Dtos;
using System.Reflection.Metadata;
using System.Security.Cryptography;

namespace MultiShop.Discount.Services
{
	public class DiscountService : IDiscountService
	{
		private readonly DapperContext _context;

		public DiscountService(DapperContext context)
		{
			_context = context;	
		}

		public async Task CreateDiscountCouponAsync(CreateDiscountCouponDto createCouponDto)
		{
			string query="insert into Coupons (Code,Rate,IsActive,ValidDate) values(@code,@rate,@isActive,@validDate)";
			var paramaters = new DynamicParameters();
			paramaters.Add("@code", createCouponDto.Code);
			paramaters.Add("@rate", createCouponDto.Rate);
			paramaters.Add("@isActive", createCouponDto.IsActive);
			paramaters.Add("@validDate", createCouponDto.ValidDate);
			using (var connection=_context.CreateConnection())
			{
				await connection.ExecuteAsync(query, paramaters);
			}
		}

		public async Task DeleteDiscountCouponAsync(int id)
		{
			string query = "Delete From Coupons where CouponID=@couponID";
			var parameters=new DynamicParameters();
			parameters.Add("@couponID", id);
			using (var connection = _context.CreateConnection())
			{
				await connection.ExecuteAsync(query, parameters);
			}
		}

		public async Task<List<ResultDiscountCouponDto>> GetAllDiscountCouponAsync()
		{
			string query = "Select * From Coupons";
			using (var connection = _context.CreateConnection())
			{
				var values	=await connection.QueryAsync<ResultDiscountCouponDto>(query);
				return values.ToList();
			}
		}

		public async Task<GetByIdDiscountCouponDto> GetByIdDiscountCouponAsync(int id)
		{
			string query = "Select * From Coupons Where CouponID=@couponID";
			var parameters= new DynamicParameters();
			parameters.Add("@couponID", id);
			using (var connection = _context.CreateConnection())
			{
				var values = await connection.QueryFirstOrDefaultAsync<GetByIdDiscountCouponDto>(query,parameters);
				return values;
			}
		}

        public  async Task<ResultDiscountCouponDto> GetCodeDetailByCodeAsync(string code)
        {
			string query = "Select * From Coupons Where Code=@code";
			var parameters=new DynamicParameters();
			parameters.Add("@code", code);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<ResultDiscountCouponDto>(query, parameters);
                return values;
            }
        }

        public async Task<int> GetDiscountCouponCount()
        {
            string query = "Select Count(*) From Coupons";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<int>(query);
                return values;
            }
        }

        public int GetDiscountCouponCountRate(string code)
        {
            string query = "Select Rate From Coupons Where Code=@code";
            var parameters = new DynamicParameters();
            parameters.Add("@code", code);
            using (var connection = _context.CreateConnection())
            {
                var values =  connection.QueryFirstOrDefault<int>(query, parameters);
				return values;
            }
        }

        public async  Task UpdateDiscountCouponAsync(UpdateDiscountCouponDto updateDiscountCouponDto)
		{
			string query = "Update Coupons Set Code=@code,Rate=@rate,IsActive=@isActive,ValidDate=@validDate where CouponID=@couponID";
			var parameters = new DynamicParameters();
			parameters.Add("@code", updateDiscountCouponDto.Code);
			parameters.Add("@rate", updateDiscountCouponDto.Rate);
			parameters.Add("@isActive", updateDiscountCouponDto.IsActive);
			parameters.Add("@validDate", updateDiscountCouponDto.ValidDate);	
			parameters.Add("@couponID", updateDiscountCouponDto.CouponID);
			using (var connection = _context.CreateConnection())
			{
				await connection.ExecuteAsync(query, parameters);
			}
		}
	}
}
