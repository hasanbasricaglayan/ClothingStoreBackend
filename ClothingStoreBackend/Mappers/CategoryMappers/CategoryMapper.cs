using ClothingStoreBackend.Entities;
using ClothingStoreBackend.Mappers.ProductMappers;
using ClothingStoreBackend.Models;

namespace ClothingStoreBackend.Mappers.CategoryMappers
{
	public class CategoryMapper : ICategoryMapper
	{
		private IProductMapper _productMapper;

		public CategoryMapper(IProductMapper productMapper)
		{
			_productMapper = productMapper;
		}

		public CategoryDTO CategoryToDTO(Category category)
		{
			CategoryDTO categoryDTO = new CategoryDTO
			{
				CategoryId = category.CategoryId,
				Name = category.Name
			};

			List<ProductDTO> productsDTO = _productMapper.ProductsToDTO(category.Products);
			categoryDTO.Products = productsDTO;

			return categoryDTO;
		}

		public List<CategoryDTO> CategoriesToDTO(IEnumerable<Category> categories)
		{
			List<CategoryDTO> categoriesDTO = [];

			foreach (Category category in categories)
			{
				CategoryDTO categoryDTO = CategoryToDTO(category);
				categoriesDTO.Add(categoryDTO);
			}

			return categoriesDTO;
		}

		public Category CategoryFromDTO(CategoryDTO categoryDTO)
		{
			Category category = new Category
			{
				CategoryId = categoryDTO.CategoryId.GetValueOrDefault(),
				Name = categoryDTO.Name
			};

			List<Product> products = _productMapper.ProductsFromDTO(categoryDTO.Products);
			category.Products = products;

			return category;
		}

		public List<Category> CategoriesFromDTO(IEnumerable<CategoryDTO> categoriesDTO)
		{
			List<Category> categories = [];

			foreach (CategoryDTO categoryDTO in categoriesDTO)
			{
				Category category = CategoryFromDTO(categoryDTO);
				categories.Add(category);
			}

			return categories;
		}

		public void UpdateCategory(Category category, CategoryDTO categoryDTO)
		{
			category.CategoryId = category.CategoryId;
			category.Name = categoryDTO.Name;
			category.Products = category.Products;
		}
	}
}
