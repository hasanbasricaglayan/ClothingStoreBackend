using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClothingStoreBackend.Entities
{
	public class Category
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int CategoryId { get; set; }

		public string Name { get; set; } = string.Empty;

		public List<Product> Products { get; set; } = [];

		public Category() { }

		public Category(int categoryId)
		{
			CategoryId = categoryId;
		}
	}
}
