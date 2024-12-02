using ClothingStoreBackend.Entities;

namespace ClothingStoreBackend.Services.ProductRepositories
{
	public interface IProductRepository
	{
		Task<IEnumerable<Product>> GetAllProductsAsync();
		Task<IEnumerable<Product>> GetAllProductsByCategoryAsync(int categoryId);

		Task<Product?> GetProductByIdAsync(int productId);
		Task<Product?> GetProductByNameAsync(string productName);

		Task AddProductAsync(Product product);

		void DeleteProduct(Product product);

		Task SaveChangesAsync();
	}
}
