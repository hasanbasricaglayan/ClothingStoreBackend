using ClothingStoreWebAPI.Entities;
using ClothingStoreWebAPI.Models;

namespace ClothingStoreWebAPI.Mappers.ProductMappers
{
	public interface IProductMapper
	{
		ProductDTO ProductToDTO(Product product);
		List<ProductDTO> ProductsToDTO(IEnumerable<Product> products);

		Product ProductFromDTO(ProductDTO productDTO);
		List<Product> ProductsFromDTO(IEnumerable<ProductDTO> productsDTO);

		void UpdateProduct(Product product, ProductDTO productDTO);
	}
}
