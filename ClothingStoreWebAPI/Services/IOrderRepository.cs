using ClothingStoreWebAPI.Entities;

namespace ClothingStoreWebAPI.Services
{
	public interface IOrderRepository
	{
		Task<IEnumerable<Order>> GetOrdersAsync();
		Task<IEnumerable<Order>> GetOrdersWithProductsAsync();

		Task<Order?> GetOrderAsync(int orderId);
		Task<Order?> GetOrderWithProductsAsync(int orderId);

		Task AddOrderAsync(Order order);

		void DeleteOrder(Order order);

		Task SaveChangesAsync();
	}
}
