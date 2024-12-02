using ClothingStoreBackend.Entities;
using ClothingStoreBackend.Mappers.ProductMappers;
using ClothingStoreBackend.Models;
using ClothingStoreBackend.Services.ProductRepositories;
using Microsoft.AspNetCore.Mvc;

namespace ClothingStoreBackend.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
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

		[HttpGet("category={categoryId}")]
		public async Task<ActionResult<IEnumerable<ProductDTO>>> GetAllProductsByCategoryAsync(int categoryId)
		{
			IEnumerable<Product> products = await _productRepository.GetAllProductsByCategoryAsync(categoryId);

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

		[HttpGet("name={productName}")]
		public async Task<ActionResult<ProductDTO>> GetProductByNameAsync(string productName)
		{
			Product? product = await _productRepository.GetProductByNameAsync(productName);
			if (product == null)
			{
				return NotFound();
			}

			ProductDTO productDTO = _productMapper.ProductToDTO(product);

			return Ok(productDTO);
		}

		[HttpPost]
		public async Task<ActionResult<ProductDTO>> AddProductAsync(ProductDTO newProductDTO)
		{
			Product product = _productMapper.ProductFromDTO(newProductDTO);

			await _productRepository.AddProductAsync(product);
			await _productRepository.SaveChangesAsync();

			ProductDTO productDTO = _productMapper.ProductToDTO(product);

			return Ok(productDTO);
		}

		[HttpPut("{productId}")]
		public async Task<ActionResult<ProductDTO>> UpdateProductAsync(int productId, ProductDTO updatedProductDTO)
		{
			Product? product = await _productRepository.GetProductByIdAsync(productId);
			if (product == null)
			{
				return NotFound();
			}

			_productMapper.UpdateProduct(product, updatedProductDTO);
			await _productRepository.SaveChangesAsync();

			ProductDTO productDTO = _productMapper.ProductToDTO(product);

			return Ok(productDTO);
		}

		[HttpDelete("{productId}")]
		public async Task<IActionResult> DeleteProductAsync(int productId)
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
