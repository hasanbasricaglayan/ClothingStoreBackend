using System.ComponentModel.DataAnnotations;

namespace ClothingStoreWebAPI.Entities
{
	public class Category
	{
		[Key]
		public int CategoryId { get; set; }

		public string Name { get; set; } = string.Empty;

		public List<Product> Products { get; set; } = [];
	}
}
