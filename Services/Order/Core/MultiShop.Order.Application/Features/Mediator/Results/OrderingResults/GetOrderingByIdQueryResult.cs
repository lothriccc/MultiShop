﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.Mediator.Results.OrderingResults
{
	public class GetOrderingByIdQueryResult
	{
		public int OrderID { get; set; }
		public string UserID { get; set; }
		public decimal TotalPrice { get; set; }
		public DateTime OrderDate { get; set; }
	}
}
