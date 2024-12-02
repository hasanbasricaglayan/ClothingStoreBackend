using ClothingStoreBackend.Data;
using ClothingStoreBackend.Entities;
using Microsoft.EntityFrameworkCore;

namespace ClothingStoreBackend.Services.CategoryRepositories
{
	public class CategoryRepository : ICategoryRepository
	{
		private ClothingStoreContext _context;

		public CategoryRepository(ClothingStoreContext context)
		{
			_context = context;
		}

		public async Task<IEnumerable<Category>> GetAllCategoriesWithProductsAsync()
		{
			return await _context.Categories.Include(c => c.Products).ToListAsync();
		}

		public async Task<Category?> GetCategoryByIdAsync(int categoryId)
		{
			return await _context.Categories.FindAsync(categoryId);
		}

		public async Task<Category?> GetCategoryByIdWithProductsAsync(int categoryId)
		{
			return await _context.Categories.Include(c => c.Products).FirstOrDefaultAsync(c => c.CategoryId == categoryId);
		}

		public async Task AddCategoryAsync(Category category)
		{
			await _context.Categories.AddAsync(category);
		}

		public void DeleteCategory(Category category)
		{
			_context.Categories.Remove(category);
		}

		public async Task SaveChangesAsync()
		{
			await _context.SaveChangesAsync();
		}
	}
}
