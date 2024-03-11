using ClothingStoreWebAPI.Entities;
using ClothingStoreWebAPI.Mappers.CategoryMappers;
using ClothingStoreWebAPI.Models;
using ClothingStoreWebAPI.Services.CategoryRepositories;
using Microsoft.AspNetCore.Mvc;

namespace ClothingStoreWebAPI.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class CategoriesController : ControllerBase
	{
		private ICategoryRepository _categoryRepository;
		private ICategoryMapper _categoryMapper;

		public CategoriesController(ICategoryRepository categoryRepository, ICategoryMapper categoryMapper)
		{
			_categoryRepository = categoryRepository;
			_categoryMapper = categoryMapper;
		}

		[HttpGet]
		public async Task<ActionResult<IEnumerable<CategoryDTO>>> GetAllCategoriesWithProductsAsync()
		{
			IEnumerable<Category> categories = await _categoryRepository.GetAllCategoriesWithProductsAsync();

			List<CategoryDTO> categoriesDTO = _categoryMapper.CategoriesToDTO(categories);

			return Ok(categoriesDTO);
		}

		[HttpGet("{categoryId}")]
		public async Task<ActionResult<CategoryDTO>> GetCategoryByIdWithProductsAsync(int categoryId)
		{
			Category? category = await _categoryRepository.GetCategoryByIdWithProductsAsync(categoryId);
			if (category == null)
			{
				return NotFound();
			}

			CategoryDTO categoryDTO = _categoryMapper.CategoryToDTO(category);

			return Ok(categoryDTO);
		}

		// Admin
		[HttpPost]
		public async Task<ActionResult<Category>> AddCategoryAsync(CategoryDTO categoryDTO)
		{
			Category category = _categoryMapper.CategoryFromDTO(categoryDTO);

			await _categoryRepository.AddCategoryAsync(category);
			await _categoryRepository.SaveChangesAsync();

			return Ok(category);
		}

		// Admin
		[HttpPut("{categoryId}")]
		public async Task<ActionResult<Category>> EditCategoryAsync(int categoryId, CategoryDTO categoryDTO)
		{
			Category? category = await _categoryRepository.GetCategoryByIdAsync(categoryId);
			if (category == null)
			{
				return NotFound();
			}

			_categoryMapper.UpdateCategory(category, categoryDTO);

			await _categoryRepository.SaveChangesAsync();

			return Ok(category);
		}

		// Admin
		[HttpDelete("{categoryId}")]
		public async Task<ActionResult> DeleteCategoryAsync(int categoryId)
		{
			Category? category = await _categoryRepository.GetCategoryByIdAsync(categoryId);
			if (category == null)
			{
				return NotFound();
			}

			_categoryRepository.DeleteCategory(category);
			await _categoryRepository.SaveChangesAsync();

			return Ok();
		}
	}
}
