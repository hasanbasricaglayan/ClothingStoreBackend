using ClothingStoreBackend.Data;
using ClothingStoreBackend.Entities;
using Microsoft.EntityFrameworkCore;

namespace ClothingStoreBackend.Services.ProductRepositories
{
	public class ProductRepository : IProductRepository
	{
		private ClothingStoreContext _context;

		public ProductRepository(ClothingStoreContext context)
		{
			_context = context;
		}

		public async Task<IEnumerable<Product>> GetAllProductsAsync()
		{
			return await _context.Products.ToListAsync();
		}

		public async Task<IEnumerable<Product>> GetAllProductsByCategoryAsync(int categoryId)
		{
			return await _context.Products.Where(p => p.CategoryId == categoryId).ToListAsync();
		}

		public async Task<Product?> GetProductByIdAsync(int productId)
		{
			return await _context.Products.FindAsync(productId);
		}

		public async Task<Product?> GetProductByNameAsync(string productName)
		{
			return await _context.Products.FirstOrDefaultAsync(p => p.Name == productName);
		}

		public async Task AddProductAsync(Product product)
		{
			await _context.Products.AddAsync(product);
		}

		public void DeleteProduct(Product product)
		{
			_context.Products.Remove(product);
		}

		public async Task SaveChangesAsync()
		{
			await _context.SaveChangesAsync();
		}
	}
}
