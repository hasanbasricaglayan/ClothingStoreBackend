using ClothingStoreWebAPI.Entities;
using ClothingStoreWebAPI.Mappers.ProductMappers;
using ClothingStoreWebAPI.Models;
using ClothingStoreWebAPI.Services.CategoryRepositories;
using ClothingStoreWebAPI.Services.ProductRepositories;
using Microsoft.AspNetCore.Mvc;

namespace ClothingStoreWebAPI.Controllers
{
	[ApiController]
	[Route("api/Categories/{categoryId}/Products")]
	public class ProductsByCategoryController : ControllerBase
	{
		private ICategoryRepository _categoryRepository;
		private IProductRepository _productRepository;
		private IProductMapper _productMapper;

		public ProductsByCategoryController(ICategoryRepository categoryRepository, IProductRepository productRepository, IProductMapper productMapper)
		{
			_categoryRepository = categoryRepository;
			_productRepository = productRepository;
			_productMapper = productMapper;
		}

		[HttpGet]
		public async Task<ActionResult<IEnumerable<ProductDTO>>> GetAllProductsOfCategoryAsync(int categoryId)
		{
			Category? category = await _categoryRepository.GetCategoryByIdWithProductsAsync(categoryId);
			if (category == null)
			{
				return NotFound();
			}

			List<ProductDTO> productsDTO = _productMapper.ProductsToDTO(category.Products);

			return Ok(productsDTO);
		}

		[HttpGet("{productId}")]
		public async Task<ActionResult<ProductDTO>> GetProductByIdOfCategoryAsync(int categoryId, int productId)
		{
			Category? category = await _categoryRepository.GetCategoryByIdWithProductsAsync(categoryId);
			if (category == null)
			{
				return NotFound();
			}

			Product? product = _productRepository.GetProductByIdOfCategory(category, productId);
			if (product == null)
			{
				return NotFound();
			}

			ProductDTO productDTO = _productMapper.ProductToDTO(product);

			return Ok(productDTO);
		}

		[HttpPost]
		public async Task<ActionResult<Product>> AddProductToCategoryAsync(int categoryId, ProductDTO productDTO)
		{
			Category? category = await _categoryRepository.GetCategoryByIdAsync(categoryId);
			if (category == null)
			{
				return NotFound();
			}

			Product product = _productMapper.ProductFromDTO(productDTO);

			_productRepository.AddProductToCategory(category, product);
			await _productRepository.SaveChangesAsync();

			return Ok(product);
		}

		[HttpPut("{productId}")]
		public async Task<ActionResult<Product>> EditProductOfCategoryAsync(int categoryId, int productId, ProductDTO productDTO)
		{
			Category? category = await _categoryRepository.GetCategoryByIdWithProductsAsync(categoryId);
			if (category == null)
			{
				return NotFound();
			}

			Product? product = _productRepository.GetProductByIdOfCategory(category, productId);
			if (product == null)
			{
				return NotFound();
			}

			_productMapper.UpdateProduct(product, productDTO);

			await _productRepository.SaveChangesAsync();

			return Ok(product);
		}

		[HttpDelete("{productId}")]
		public async Task<ActionResult> DeleteProductOfCategoryAsync(int categoryId, int productId)
		{
			Category? category = await _categoryRepository.GetCategoryByIdWithProductsAsync(categoryId);
			if (category == null)
			{
				return NotFound();
			}

			Product? product = _productRepository.GetProductByIdOfCategory(category, productId);
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
