using ClothingStoreWebAPI.Entities;
using ClothingStoreWebAPI.Models;

namespace ClothingStoreWebAPI.Mappers.CategoryMappers
{
	public interface ICategoryMapper
	{
		CategoryDTO CategoryToDTO(Category category);
		List<CategoryDTO> CategoriesToDTO(IEnumerable<Category> categories);

		Category CategoryFromDTO(CategoryDTO categoryDTO);

		void UpdateCategory(Category category, CategoryDTO categoryDTO);
	}
}
