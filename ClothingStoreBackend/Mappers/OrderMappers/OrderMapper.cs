using ClothingStoreBackend.Entities;
using ClothingStoreBackend.Mappers.OrderProductMappers;
using ClothingStoreBackend.Models;

namespace ClothingStoreBackend.Mappers.OrderMappers
{
	public class OrderMapper : IOrderMapper
	{
		private IOrderProductMapper _orderProductMapper;

		public OrderMapper(IOrderProductMapper orderProductMapper)
		{
			_orderProductMapper = orderProductMapper;
		}

		public OrderDTO OrderToDTO(Order order)
		{
			OrderDTO orderDTO = new OrderDTO
			{
				OrderId = order.OrderId,
				UserId = order.UserId,
				OrderDate = order.OrderDate,
				Status = order.Status
			};

			List<OrderProductDTO> orderProductsDTO = _orderProductMapper.OrderProductsToDTO(order.Products);
			orderDTO.Products = orderProductsDTO;

			return orderDTO;
		}

		public List<OrderDTO> OrdersToDTO(IEnumerable<Order> orders)
		{
			List<OrderDTO> ordersDTO = [];

			foreach (Order order in orders)
			{
				OrderDTO orderDTO = OrderToDTO(order);
				ordersDTO.Add(orderDTO);
			}

			return ordersDTO;
		}

		public Order OrderFromDTO(OrderDTO orderDTO)
		{
			Order order = new Order
			{
				OrderId = orderDTO.OrderId.GetValueOrDefault(),
				UserId = orderDTO.UserId,
				OrderDate = orderDTO.OrderDate,
				Status = orderDTO.Status
			};

			List<OrderProduct> orderProducts = _orderProductMapper.OrderProductsFromDTO(orderDTO.Products);
			order.Products = orderProducts;

			return order;
		}

		public List<Order> OrdersFromDTO(IEnumerable<OrderDTO> ordersDTO)
		{
			List<Order> orders = [];

			foreach (OrderDTO orderDTO in ordersDTO)
			{
				Order order = OrderFromDTO(orderDTO);
				orders.Add(order);
			}

			return orders;
		}

		public void UpdateOrder(Order order, OrderDTO orderDTO)
		{
			order.OrderId = order.OrderId;
			order.UserId = order.UserId;
			order.OrderDate = orderDTO.OrderDate;
			order.Status = orderDTO.Status;
			order.Products = order.Products;
		}
	}
}
