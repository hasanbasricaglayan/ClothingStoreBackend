using ClothingStoreWebAPI.Entities;
using ClothingStoreWebAPI.Mappers.OrderMappers;
using ClothingStoreWebAPI.Models;
using ClothingStoreWebAPI.Services.OrderRepositories;
using ClothingStoreWebAPI.Services.UserRepositories;
using Microsoft.AspNetCore.Mvc;

namespace ClothingStoreWebAPI.Controllers
{
	[ApiController]
	[Route("api/Users/{userId}/Orders")]
	public class OrdersByUserController : ControllerBase
	{
		private IUserRepository _userRepository;
		private IOrderRepository _orderRepository;
		private IOrderMapper _orderMapper;

		public OrdersByUserController(IUserRepository userRepository, IOrderRepository orderRepository, IOrderMapper orderMapper)
		{
			_userRepository = userRepository;
			_orderRepository = orderRepository;
			_orderMapper = orderMapper;
		}

		[HttpGet]
		public async Task<ActionResult<IEnumerable<OrderDTO>>> GetAllOrdersOfUserWithProductsAsync(int userId)
		{
			User? user = await _userRepository.GetUserByIdWithOrdersAndProductsAsync(userId);
			if (user == null)
			{
				return NotFound();
			}

			List<OrderDTO> ordersDTO = _orderMapper.OrdersToDTO(user.Orders);

			return Ok(ordersDTO);
		}

		[HttpGet("{orderId}")]
		public async Task<ActionResult<OrderDTO>> GetOrderByIdOfUserWithProductsAsync(int userId, int orderId)
		{
			User? user = await _userRepository.GetUserByIdWithOrdersAndProductsAsync(userId);
			if (user == null)
			{
				return NotFound();
			}

			Order? order = _orderRepository.GetOrderByIdOfUser(user, orderId);
			if (order == null)
			{
				return NotFound();
			}

			OrderDTO orderDTO = _orderMapper.OrderToDTO(order);

			return Ok(orderDTO);
		}

		[HttpPost]
		public async Task<ActionResult<Order>> AddOrderToUserAsync(int userId, OrderDTO orderDTO)
		{
			User? user = await _userRepository.GetUserByIdAsync(userId);
			if (user == null)
			{
				return NotFound();
			}

			Order order = _orderMapper.OrderFromDTO(orderDTO);

			_orderRepository.AddOrderToUser(user, order);
			await _orderRepository.SaveChangesAsync();

			return Ok(order);
		}

		[HttpPut("{orderId}")]
		public async Task<ActionResult<Order>> EditOrderOfUserAsync(int userId, int orderId, OrderDTO orderDTO)
		{
			User? user = await _userRepository.GetUserByIdWithOrdersAndProductsAsync(userId);
			if (user == null)
			{
				return NotFound();
			}

			Order? order = _orderRepository.GetOrderByIdOfUser(user, orderId);
			if (order == null)
			{
				return NotFound();
			}

			_orderMapper.UpdateOrder(order, orderDTO);

			await _orderRepository.SaveChangesAsync();

			return Ok(order);
		}

		[HttpDelete("{orderId}")]
		public async Task<ActionResult> DeleteOrderOfUserAsync(int userId, int orderId)
		{
			User? user = await _userRepository.GetUserByIdWithOrdersAndProductsAsync(userId);
			if (user == null)
			{
				return NotFound();
			}

			Order? order = _orderRepository.GetOrderByIdOfUser(user, orderId);
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
