﻿using MultiShop.Order.Application.Features.CQRS.Results.OrderDetailResults;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers
{
	public class GetOrderDetialQueryHandler
	{
		private readonly IRepository<OrderDetail> _repository;

		public GetOrderDetialQueryHandler(IRepository<OrderDetail> repository)
		{
			_repository = repository;
		}
		public async Task<List<GetOrderDetailQueryResult>> Handle()
		{
			var values=await _repository.GetAllAsync();
			return values.Select(x=> new GetOrderDetailQueryResult
			{
				OrderDetailID= x.OrderDetailID,
				ProductAmount= x.ProductAmount,
				OrderingID= x.OrderingID,
				ProductName= x.ProductName,
				ProductID= x.ProductID,
				ProductPrice= x.ProductPrice
			}).ToList();
		}
	}
}
