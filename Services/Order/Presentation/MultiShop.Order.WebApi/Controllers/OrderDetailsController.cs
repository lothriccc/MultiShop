using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Order.Application.Features.CQRS.Commands.AddressCommands;
using MultiShop.Order.Application.Features.CQRS.Commands.OrderDetailCommands;
using MultiShop.Order.Application.Features.CQRS.Handlers.AddressHandlers;
using MultiShop.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers;
using MultiShop.Order.Application.Features.CQRS.Queries.AddressQueries;
using MultiShop.Order.Application.Features.CQRS.Queries.OrderDetailQueries;
using MultiShop.Order.Application.Features.CQRS.Results.OrderDetailResults;

namespace MultiShop.Order.WebApi.Controllers
{
	[Authorize]
	[Route("api/[controller]")]
	[ApiController]
	public class OrderDetailsController : ControllerBase
	{
		private readonly GetOrderDetailByIdQueryHandler _getOrderDetailByIdQueryHandler;
		private readonly GetOrderDetialQueryHandler _getOrderDetailQueryHandler;
		private readonly UpdateOrderDetailCommandHandler _updateOrderDetailCommandHandler;
		private readonly RemoveOrderDetailCommandHandler _removeOrderDetailQueryHandler;
		private readonly CreateOrderDetailCommandHandler _createOrderDetailCommandHandler;

		public OrderDetailsController(GetOrderDetailByIdQueryHandler getOrderDetailByIdQueryHandler, GetOrderDetialQueryHandler getOrderDetailQueryHandler, UpdateOrderDetailCommandHandler updateOrderDetailCommandHandler, RemoveOrderDetailCommandHandler removeOrderDetailQueryHandler, CreateOrderDetailCommandHandler createOrderDetailCommandHandler)
		{
			_getOrderDetailByIdQueryHandler = getOrderDetailByIdQueryHandler;
			_getOrderDetailQueryHandler = getOrderDetailQueryHandler;
			_updateOrderDetailCommandHandler = updateOrderDetailCommandHandler;
			_removeOrderDetailQueryHandler = removeOrderDetailQueryHandler;
			_createOrderDetailCommandHandler = createOrderDetailCommandHandler;

		}
		[HttpGet]
		public async Task<IActionResult> OrderDetailList()
		{
			var values = await _getOrderDetailQueryHandler.Handle();
			return Ok(values);

		}
		[HttpGet("{id}")]
		public async Task<IActionResult> OrderDetailListById(int id)
		{
			var values = await _getOrderDetailByIdQueryHandler.Handle(new GetOrderDetailQuery(id));
			return Ok(values);
		}
		[HttpPost]
		public async Task<IActionResult> CreateOrderDetail(CreateOrderDetailCommand command)
		{
			await _createOrderDetailCommandHandler.Handle(command);
			return Ok("Sipariş Detayı başarıyla eklenmiştir");
		}
		[HttpDelete]
		public async Task<IActionResult> RemoveOrderDetail(int id)
		{
			await _removeOrderDetailQueryHandler.Handle(new RemoveOrderDetailCommand(id));
			return Ok("Sipariş Detayı Başarıyla silinmiştir");
		}
		[HttpPut]
		public async Task<IActionResult> UpdateOrderDetail(UpdateOrderDetailCommand command)
		{
			await _updateOrderDetailCommandHandler.Handle(command);
			return Ok("Sipariş Detayı başarıyla güncellendi");
		}
	}
}
