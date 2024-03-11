using ClothingStoreWebAPI.Entities;

namespace ClothingStoreWebAPI.Services.ProductRepositories
{
	public interface IProductRepository
	{
		Task<IEnumerable<Product>> GetAllProductsAsync();
		Task<IEnumerable<Product>> GetAllProductsWithOrdersAsync();

		Task<Product?> GetProductByIdAsync(int productId);
		Task<Product?> GetProductByIdWithOrdersAsync(int productId);
		Product? GetProductByIdOfCategory(Category category, int productId);

		Task<Product?> GetProductByNameAsync(string name);

		Task AddProductAsync(Product product);
		void AddProductToCategory(Category category, Product product);

		void DeleteProduct(Product product);

		Task SaveChangesAsync();
	}
}
