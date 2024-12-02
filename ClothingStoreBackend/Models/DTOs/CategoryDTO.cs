namespace ClothingStoreBackend.Models
{
	public class CategoryDTO
	{
		public int? CategoryId { get; set; }

		public string Name { get; set; } = string.Empty;

		public List<ProductDTO> Products { get; set; } = [];
	}
}
