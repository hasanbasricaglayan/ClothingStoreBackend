using ClothingStoreBackend.Entities;

namespace ClothingStoreBackend.Services.CategoryRepositories
{
	public interface ICategoryRepository
	{
		Task<IEnumerable<Category>> GetAllCategoriesWithProductsAsync();

		Task<Category?> GetCategoryByIdAsync(int categoryId);
		Task<Category?> GetCategoryByIdWithProductsAsync(int categoryId);

		Task AddCategoryAsync(Category category);

		void DeleteCategory(Category category);

		Task SaveChangesAsync();
	}
}
