namespace ClothingStoreBackend.Models
{
	public class ProductDTO
	{
		public int? ProductId { get; set; }

		public int CategoryId { get; set; }

		public string Brand { get; set; } = string.Empty;
		public string Name { get; set; } = string.Empty;
		public string Color { get; set; } = string.Empty;
		public string Size { get; set; } = string.Empty;
		public double Price { get; set; }
		public string Description { get; set; } = string.Empty;
		public int QuantityInStock { get; set; }
		public string ImageURL { get; set; } = string.Empty;
	}
}
