using ClothingStoreBackend.Entities;
using ClothingStoreBackend.Models;

namespace ClothingStoreBackend.Mappers.ProductMappers
{
	public class ProductMapper : IProductMapper
	{
		public ProductDTO ProductToDTO(Product product)
		{
			ProductDTO productDTO = new ProductDTO
			{
				ProductId = product.ProductId,
				CategoryId = product.CategoryId,
				Brand = product.Brand,
				Name = product.Name,
				Color = product.Color,
				Size = product.Size,
				Price = product.Price,
				Description = product.Description,
				QuantityInStock = product.QuantityInStock,
				ImageURL = product.ImageURL
			};

			return productDTO;
		}

		public List<ProductDTO> ProductsToDTO(IEnumerable<Product> products)
		{
			List<ProductDTO> productsDTO = [];

			foreach (Product product in products)
			{
				ProductDTO productDTO = ProductToDTO(product);
				productsDTO.Add(productDTO);
			}

			return productsDTO;
		}

		public Product ProductFromDTO(ProductDTO productDTO)
		{
			Product product = new Product
			{
				ProductId = productDTO.ProductId.GetValueOrDefault(),
				CategoryId = productDTO.CategoryId,
				Brand = productDTO.Brand,
				Name = productDTO.Name,
				Color = productDTO.Color,
				Size = productDTO.Size,
				Price = productDTO.Price,
				Description = productDTO.Description,
				QuantityInStock = productDTO.QuantityInStock,
				ImageURL = productDTO.ImageURL
			};

			return product;
		}

		public List<Product> ProductsFromDTO(IEnumerable<ProductDTO> productsDTO)
		{
			List<Product> products = [];

			foreach (ProductDTO productDTO in productsDTO)
			{
				Product product = ProductFromDTO(productDTO);
				products.Add(product);
			}

			return products;
		}

		public void UpdateProduct(Product product, ProductDTO productDTO)
		{
			product.ProductId = product.ProductId;
			product.CategoryId = product.CategoryId;
			product.Brand = productDTO.Brand;
			product.Name = productDTO.Name;
			product.Color = productDTO.Color;
			product.Size = productDTO.Size;
			product.Price = productDTO.Price;
			product.Description = productDTO.Description;
			product.QuantityInStock = productDTO.QuantityInStock;
			product.ImageURL = productDTO.ImageURL;
		}
	}
}
