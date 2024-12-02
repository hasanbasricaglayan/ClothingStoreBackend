using ClothingStoreBackend.Entities;
using ClothingStoreBackend.Mappers.CategoryMappers;
using ClothingStoreBackend.Models;
using ClothingStoreBackend.Services.CategoryRepositories;
using Microsoft.AspNetCore.Mvc;

namespace ClothingStoreBackend.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
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

		[HttpPost]
		public async Task<ActionResult<CategoryDTO>> AddCategoryAsync(CategoryDTO newCategoryDTO)
		{
			Category category = _categoryMapper.CategoryFromDTO(newCategoryDTO);

			await _categoryRepository.AddCategoryAsync(category);
			await _categoryRepository.SaveChangesAsync();

			CategoryDTO categoryDTO = _categoryMapper.CategoryToDTO(category);

			return Ok(categoryDTO);
		}

		[HttpPut("{categoryId}")]
		public async Task<ActionResult<CategoryDTO>> UpdateCategoryAsync(int categoryId, CategoryDTO updatedCategoryDTO)
		{
			Category? category = await _categoryRepository.GetCategoryByIdAsync(categoryId);
			if (category == null)
			{
				return NotFound();
			}

			_categoryMapper.UpdateCategory(category, updatedCategoryDTO);
			await _categoryRepository.SaveChangesAsync();

			CategoryDTO categoryDTO = _categoryMapper.CategoryToDTO(category);

			return Ok(categoryDTO);
		}

		[HttpDelete("{categoryId}")]
		public async Task<IActionResult> DeleteCategoryAsync(int categoryId)
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
