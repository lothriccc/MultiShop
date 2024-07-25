﻿using MultiShop.Order.Application.Features.CQRS.Commands.AddressCommands;
using MultiShop.Order.Application.Features.CQRS.Commands.OrderDetailCommands;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers
{
	public class UpdateOrderDetailCommandHandler
	{
		private readonly IRepository<OrderDetail> _repository;

		public UpdateOrderDetailCommandHandler(IRepository<OrderDetail> repository)
		{
			_repository = repository;
		}
		public async Task Handle(UpdateOrderDetailCommand command)
		{
			var values = await _repository.GetByIdAsync(command.OrderDetailID);
			values.OrderDetailID = command.OrderDetailID;
			values.ProductID = command.ProductID;
			values.ProductName = command.ProductName;
			values.ProductPrice = command.ProductPrice;
			values.OrderingID = command.OrderingID;
			values.TotalPrice = command.TotalPrice;
			values.ProductAmount = command.ProductAmount;
			values.ProductPrice = command.ProductPrice;
			await _repository.UpdateAsync(values);
		}
	}
}
