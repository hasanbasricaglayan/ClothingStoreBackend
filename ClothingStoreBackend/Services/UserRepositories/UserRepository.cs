using ClothingStoreBackend.Data;
using ClothingStoreBackend.Entities;
using Microsoft.EntityFrameworkCore;

namespace ClothingStoreBackend.Services.UserRepositories
{
	public class UserRepository : IUserRepository
	{
		private ClothingStoreContext _context;

		public UserRepository(ClothingStoreContext context)
		{
			_context = context;
		}

		public async Task<IEnumerable<User>> GetAllUsersWithOrdersAndProductsAsync()
		{
			return await _context.Users.Include(u => u.Orders).ThenInclude(o => o.Products).ThenInclude(op => op.Product).ToListAsync();
		}

		public async Task<User?> GetUserByIdAsync(int userId)
		{
			return await _context.Users.FindAsync(userId);
		}

		public async Task<User?> GetUserByIdWithOrdersAndProductsAsync(int userId)
		{
			return await _context.Users.Include(u => u.Orders).ThenInclude(o => o.Products).ThenInclude(op => op.Product).FirstOrDefaultAsync(u => u.UserId == userId);
		}

		public async Task AddUserAsync(User user)
		{
			await _context.Users.AddAsync(user);
		}

		public void DeleteUser(User user)
		{
			_context.Users.Remove(user);
		}

		public async Task SaveChangesAsync()
		{
			await _context.SaveChangesAsync();
		}
	}
}
