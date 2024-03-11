using ClothingStoreWebAPI.Entities;
using ClothingStoreWebAPI.Mappers.OrderMappers;
using ClothingStoreWebAPI.Models;
using ClothingStoreWebAPI.Services.OrderRepositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ClothingStoreWebAPI.Controllers
{
	[ApiController]
	[Authorize]
	[Route("api/[controller]")]
	public class OrdersController : ControllerBase
	{
		private IOrderRepository _orderRepository;
		private IOrderMapper _orderMapper;

		public OrdersController(IOrderRepository orderRepository, IOrderMapper orderMapper)
		{
			_orderRepository = orderRepository;
			_orderMapper = orderMapper;
		}

		[HttpGet]
		public async Task<ActionResult<IEnumerable<OrderDTO>>> GetAllOrdersWithProductsAsync()
		{
			IEnumerable<Order> orders = await _orderRepository.GetAllOrdersWithProductsAsync();

			List<OrderDTO> ordersDTO = _orderMapper.OrdersToDTO(orders);

			return Ok(ordersDTO);
		}

		[HttpGet("{orderId}")]
		public async Task<ActionResult<OrderDTO>> GetOrderByIdWithProductsAsync(int orderId)
		{
			Order? order = await _orderRepository.GetOrderByIdWithProductsAsync(orderId);
			if (order == null)
			{
				return NotFound();
			}

			OrderDTO orderDTO = _orderMapper.OrderToDTO(order);

			return Ok(orderDTO);
		}

		[HttpPost]
		public async Task<ActionResult<Order>> AddOrderAsync(OrderDTO orderDTO)
		{
			Order order = _orderMapper.OrderFromDTO(orderDTO);

			await _orderRepository.AddOrderAsync(order);
			await _orderRepository.SaveChangesAsync();

			return Ok(order);
		}

		[HttpPut("{orderId}")]
		public async Task<ActionResult<Order>> EditOrderAsync(int orderId, OrderDTO orderDTO)
		{
			Order? order = await _orderRepository.GetOrderByIdAsync(orderId);
			if (order == null)
			{
				return NotFound();
			}

			_orderMapper.UpdateOrder(order, orderDTO);

			await _orderRepository.SaveChangesAsync();

			return Ok(order);
		}

		[HttpDelete("{orderId}")]
		public async Task<ActionResult> DeleteOrderAsync(int orderId)
		{
			Order? order = await _orderRepository.GetOrderByIdAsync(orderId);
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
