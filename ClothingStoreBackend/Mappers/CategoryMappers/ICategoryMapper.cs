using ClothingStoreBackend.Entities;
using ClothingStoreBackend.Models;

namespace ClothingStoreBackend.Mappers.CategoryMappers
{
	public interface ICategoryMapper
	{
		CategoryDTO CategoryToDTO(Category category);
		List<CategoryDTO> CategoriesToDTO(IEnumerable<Category> categories);

		Category CategoryFromDTO(CategoryDTO categoryDTO);
		List<Category> CategoriesFromDTO(IEnumerable<CategoryDTO> categoriesDTO);

		void UpdateCategory(Category category, CategoryDTO categoryDTO);
	}
}
