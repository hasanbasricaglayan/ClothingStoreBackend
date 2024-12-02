using ClothingStoreBackend.Entities;
using ClothingStoreBackend.Models;

namespace ClothingStoreBackend.Mappers.OrderMappers
{
	public interface IOrderMapper
	{
		OrderDTO OrderToDTO(Order order);
		List<OrderDTO> OrdersToDTO(IEnumerable<Order> orders);

		Order OrderFromDTO(OrderDTO orderDTO);
		List<Order> OrdersFromDTO(IEnumerable<OrderDTO> ordersDTO);

		void UpdateOrder(Order order, OrderDTO orderDTO);
	}
}
