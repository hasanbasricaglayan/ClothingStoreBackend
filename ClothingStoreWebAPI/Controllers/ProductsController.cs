using ClothingStoreWebAPI.Entities;
using ClothingStoreWebAPI.Mappers.ProductMappers;
using ClothingStoreWebAPI.Models;
using ClothingStoreWebAPI.Services.ProductRepositories;
using Microsoft.AspNetCore.Mvc;

namespace ClothingStoreWebAPI.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class ProductsController : ControllerBase
	{
		private IProductRepository _productRepository;
		private IProductMapper _productMapper;

		public ProductsController(IProductRepository productRepository, IProductMapper productMapper)
		{
			_productRepository = productRepository;
			_productMapper = productMapper;
		}

		[HttpGet]
		public async Task<ActionResult<IEnumerable<ProductDTO>>> GetAllProductsAsync()
		{
			IEnumerable<Product> products = await _productRepository.GetAllProductsAsync();

			List<ProductDTO> productsDTO = _productMapper.ProductsToDTO(products);

			return Ok(productsDTO);
		}

		[HttpGet("{productId}")]
		public async Task<ActionResult<ProductDTO>> GetProductByIdAsync(int productId)
		{
			Product? product = await _productRepository.GetProductByIdAsync(productId);
			if (product == null)
			{
				return NotFound();
			}

			ProductDTO productDTO = _productMapper.ProductToDTO(product);

			return Ok(productDTO);
		}

		[HttpGet("name={name}")]
		public async Task<ActionResult<ProductDTO>> GetProductByNameAsync(string name)
		{
			Product? product = await _productRepository.GetProductByNameAsync(name);
			if (product == null)
			{
				return NotFound();
			}

			ProductDTO productDTO = _productMapper.ProductToDTO(product);

			return Ok(productDTO);
		}

		[HttpPost]
		public async Task<ActionResult<Product>> AddProductAsync(ProductDTO productDTO)
		{
			Product product = _productMapper.ProductFromDTO(productDTO);

			await _productRepository.AddProductAsync(product);
			await _productRepository.SaveChangesAsync();

			return Ok(product);
		}

		[HttpPut("{productId}")]
		public async Task<ActionResult<Product>> EditProductAsync(int productId, ProductDTO productDTO)
		{
			Product? product = await _productRepository.GetProductByIdAsync(productId);
			if (product == null)
			{
				return NotFound();
			}

			_productMapper.UpdateProduct(product, productDTO);

			await _productRepository.SaveChangesAsync();

			return Ok(product);
		}

		[HttpDelete("{productId}")]
		public async Task<ActionResult> DeleteProductAsync(int productId)
		{
			Product? product = await _productRepository.GetProductByIdAsync(productId);
			if (product == null)
			{
				return NotFound();
			}

			_productRepository.DeleteProduct(product);
			await _productRepository.SaveChangesAsync();

			return Ok();
		}
	}
}
