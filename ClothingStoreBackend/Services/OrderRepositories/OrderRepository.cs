using ClothingStoreBackend.Data;
using ClothingStoreBackend.Entities;
using Microsoft.EntityFrameworkCore;

namespace ClothingStoreBackend.Services.OrderRepositories
{
	public class OrderRepository : IOrderRepository
	{
		private ClothingStoreContext _context;

		public OrderRepository(ClothingStoreContext context)
		{
			_context = context;
		}

		public async Task<IEnumerable<Order>> GetAllOrdersWithProductsAsync()
		{
			return await _context.Orders.Include(o => o.Products).ThenInclude(op => op.Product).ToListAsync();
		}

		public async Task<IEnumerable<Order>> GetAllOrdersByUserWithProductsAsync(int userId)
		{
			return await _context.Orders.Include(o => o.Products).ThenInclude(op => op.Product).Where(o => o.UserId == userId).ToListAsync();
		}

		public async Task<Order?> GetOrderByIdAsync(int orderId)
		{
			return await _context.Orders.FindAsync(orderId);
		}

		public async Task<Order?> GetOrderByIdWithProductsAsync(int orderId)
		{
			return await _context.Orders.Include(o => o.Products).ThenInclude(op => op.Product).FirstOrDefaultAsync(o => o.OrderId == orderId);
		}

		public async Task AddOrderAsync(Order order)
		{
			await _context.Orders.AddAsync(order);
		}

		public void DeleteOrder(Order order)
		{
			_context.Orders.Remove(order);
		}

		public async Task SaveChangesAsync()
		{
			await _context.SaveChangesAsync();
		}
	}
}
