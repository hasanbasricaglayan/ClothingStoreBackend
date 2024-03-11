namespace ClothingStoreWebAPI.Models
{
	public class OrderProductDTO
	{
		public int OrderId { get; set; }

		public int ProductId { get; set; }
		public int Quantity { get; set; }
		public double Price { get; set; }

		public ProductDTO? Product { get; set; }
	}
}
