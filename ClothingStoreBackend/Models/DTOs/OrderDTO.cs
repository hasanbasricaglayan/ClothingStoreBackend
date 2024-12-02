namespace ClothingStoreBackend.Models
{
	public class OrderDTO
	{
		public int? OrderId { get; set; }

		public int UserId { get; set; }

		public DateOnly OrderDate { get; set; }
		public string Status { get; set; } = string.Empty;

		public List<OrderProductDTO> Products { get; set; } = [];
	}
}
