using ClothingStoreWebAPI.Entities;

namespace ClothingStoreWebAPI.Services.OrderRepositories
{
	public interface IOrderRepository
	{
		Task<IEnumerable<Order>> GetAllOrdersWithProductsAsync();

		Task<Order?> GetOrderByIdAsync(int orderId);
		Task<Order?> GetOrderByIdWithProductsAsync(int orderId);
		Order? GetOrderByIdOfUser(User user, int orderId);

		Task AddOrderAsync(Order order);
		void AddOrderToUser(User user, Order order);

		void DeleteOrder(Order order);

		Task SaveChangesAsync();
	}
}
