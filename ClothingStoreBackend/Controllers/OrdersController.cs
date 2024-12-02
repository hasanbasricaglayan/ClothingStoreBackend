using ClothingStoreBackend.Entities;
using ClothingStoreBackend.Mappers.OrderMappers;
using ClothingStoreBackend.Models;
using ClothingStoreBackend.Services.OrderRepositories;
using Microsoft.AspNetCore.Mvc;

namespace ClothingStoreBackend.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
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

		[HttpGet("user={userId}")]
		public async Task<ActionResult<IEnumerable<OrderDTO>>> GetAllOrdersByUserWithProductsAsync(int userId)
		{
			IEnumerable<Order> orders = await _orderRepository.GetAllOrdersByUserWithProductsAsync(userId);

			List<OrderDTO> orderDTO = _orderMapper.OrdersToDTO(orders);

			return Ok(orderDTO);
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
		public async Task<ActionResult<OrderDTO>> AddOrderAsync(OrderDTO newOrderDTO)
		{
			Order order = _orderMapper.OrderFromDTO(newOrderDTO);

			await _orderRepository.AddOrderAsync(order);
			await _orderRepository.SaveChangesAsync();

			OrderDTO orderDTO = _orderMapper.OrderToDTO(order);

			return Ok(orderDTO);
		}

		[HttpPut("{orderId}")]
		public async Task<ActionResult<OrderDTO>> UpdateOrderAsync(int orderId, OrderDTO updatedOrderDTO)
		{
			Order? order = await _orderRepository.GetOrderByIdAsync(orderId);
			if (order == null)
			{
				return NotFound();
			}

			_orderMapper.UpdateOrder(order, updatedOrderDTO);
			await _orderRepository.SaveChangesAsync();

			OrderDTO orderDTO = _orderMapper.OrderToDTO(order);

			return Ok(orderDTO);
		}

		[HttpDelete("{orderId}")]
		public async Task<IActionResult> DeleteOrderAsync(int orderId)
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
