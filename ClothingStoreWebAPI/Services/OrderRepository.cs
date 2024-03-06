using ClothingStoreWebAPI.Data;
using ClothingStoreWebAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace ClothingStoreWebAPI.Services
{
	public class OrderRepository : IOrderRepository
	{
		private ClothingStoreContext _context;

		public OrderRepository(ClothingStoreContext context)
		{
			_context = context;
		}

		public async Task<IEnumerable<Order>> GetOrdersAsync()
		{
			return await _context.Orders.ToListAsync();
		}

		public async Task<IEnumerable<Order>> GetOrdersWithProductsAsync()
		{
			return await _context.Orders.Include(o => o.Products).ThenInclude(op => op.Product).ToListAsync();
		}

		public async Task<Order?> GetOrderAsync(int orderId)
		{
			return await _context.Orders.FindAsync(orderId);
		}

		public async Task<Order?> GetOrderWithProductsAsync(int orderId)
		{
			return await _context.Orders.Include(o => o.Products).FirstOrDefaultAsync(o => o.OrderId == orderId);
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
