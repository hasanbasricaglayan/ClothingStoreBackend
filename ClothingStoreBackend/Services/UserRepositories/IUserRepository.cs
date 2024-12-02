using ClothingStoreBackend.Entities;

namespace ClothingStoreBackend.Services.UserRepositories
{
	public interface IUserRepository
	{
		Task<IEnumerable<User>> GetAllUsersWithOrdersAndProductsAsync();

		Task<User?> GetUserByIdAsync(int userId);
		Task<User?> GetUserByIdWithOrdersAndProductsAsync(int userId);

		Task AddUserAsync(User user);

		void DeleteUser(User user);

		Task SaveChangesAsync();
	}
}
