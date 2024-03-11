using ClothingStoreWebAPI.Data;
using ClothingStoreWebAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace ClothingStoreWebAPI.Services.ProductRepositories
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

		public async Task<IEnumerable<Product>> GetAllProductsWithOrdersAsync()
		{
			return await _context.Products.Include(p => p.Orders).ThenInclude(op => op.Product).ToListAsync();
		}

		public async Task<Product?> GetProductByIdAsync(int productId)
		{
			return await _context.Products.FindAsync(productId);
		}

		public async Task<Product?> GetProductByIdWithOrdersAsync(int productId)
		{
			return await _context.Products.Include(p => p.Orders).ThenInclude(op => op.Product).FirstOrDefaultAsync(p => p.ProductId == productId);
		}

		public Product? GetProductByIdOfCategory(Category category, int productId)
		{
			return category.Products.FirstOrDefault(p => p.ProductId == productId);
		}

		public async Task<Product?> GetProductByNameAsync(string name)
		{
			return await _context.Products.FirstOrDefaultAsync(p => p.Name == name);
		}

		public async Task AddProductAsync(Product product)
		{
			await _context.Products.AddAsync(product);
		}

		public void AddProductToCategory(Category category, Product product)
		{
			category.Products.Add(product);
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
