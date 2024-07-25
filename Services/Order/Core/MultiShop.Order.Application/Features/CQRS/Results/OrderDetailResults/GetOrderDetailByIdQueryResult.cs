﻿using MultiShop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.CQRS.Results.OrderDetailResults
{
	public class GetOrderDetailByIdQueryResult
	{
		public int OrderDetailID { get; set; }
		public string ProductID { get; set; }
		public string ProductName { get; set; }
		public decimal ProductPrice { get; set; }
		public int ProductAmount { get; set; }
		public decimal TotalPrice { get; set; }
		public int OrderingID { get; set; }

	}
}