using System.Text.Json.Serialization;

namespace ClothingStoreWebAPI.Entities
{
	public class OrderProduct
	{
		public int OrderId { get; set; }

		[JsonIgnore]
		public Order? Order { get; set; }

		public int ProductId { get; set; }

		[JsonIgnore]
		public Product? Product { get; set; }

		public int Quantity { get; set; }
		public double Price { get; set; }
	}
}
