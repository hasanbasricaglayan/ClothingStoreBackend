using ClothingStoreBackend.Entities;

namespace ClothingStoreBackend.Services.OrderRepositories
{
	public interface IOrderRepository
	{
		Task<IEnumerable<Order>> GetAllOrdersWithProductsAsync();
		Task<IEnumerable<Order>> GetAllOrdersByUserWithProductsAsync(int userId);

		Task<Order?> GetOrderByIdAsync(int orderId);
		Task<Order?> GetOrderByIdWithProductsAsync(int orderId);

		Task AddOrderAsync(Order order);

		void DeleteOrder(Order order);

		Task SaveChangesAsync();
	}
}
