using ClothingStoreWebAPI.Entities;
using ClothingStoreWebAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace ClothingStoreWebAPI.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class OrdersController : ControllerBase
	{
		private IOrderRepository _orderRepository;

		public OrdersController(IOrderRepository orderRepository)
		{
			_orderRepository = orderRepository;
		}

		[HttpGet]
		public async Task<ActionResult<IEnumerable<Order>>> GetOrdersWithProducts()
		{
			IEnumerable<Order> orders = await _orderRepository.GetOrdersWithProductsAsync();

			return Ok(orders);
		}

		[HttpGet("{orderId}")]
		public async Task<ActionResult<Order>> GetOrderWithProducts(int orderId)
		{
			Order? order = await _orderRepository.GetOrderWithProductsAsync(orderId);

			if (order == null)
			{
				return NotFound();
			}

			return Ok(order);
		}

		[HttpPost]
		public async Task<ActionResult<Order>> AddOrder(Order order)
		{
			await _orderRepository.AddOrderAsync(order);
			await _orderRepository.SaveChangesAsync();

			return Ok(order);
		}

		[HttpPut("{orderId}")]
		public async Task<ActionResult<Order>> EditOrder(int orderId, Order order)
		{
			Order? orderToEdit = await _orderRepository.GetOrderAsync(orderId);
			if (orderToEdit == null)
			{
				return NotFound();
			}

			orderToEdit.Status = order.Status;

			await _orderRepository.SaveChangesAsync();

			return Ok(orderToEdit);
		}

		[HttpDelete("{orderId}")]
		public async Task<ActionResult> DeleteOrder(int orderId)
		{
			Order? order = await _orderRepository.GetOrderAsync(orderId);
			if (order == null)
			{
				return NotFound();
			}

			_orderRepository.DeleteOrder(order);
			await _orderRepository.SaveChangesAsync();

			return Ok();
		}
	}
}
