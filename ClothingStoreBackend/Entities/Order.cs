using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClothingStoreBackend.Entities
{
	public class Order
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int OrderId { get; set; }

		[ForeignKey("UserId")]
		public int UserId { get; set; }

		public DateOnly OrderDate { get; set; } = DateOnly.FromDateTime(DateTime.Now);
		public string Status { get; set; } = string.Empty;

		public List<OrderProduct> Products { get; set; } = [];

		public Order() { }

		public Order(int orderId)
		{
			OrderId = orderId;
			OrderDate = DateOnly.FromDateTime(DateTime.Now);
		}
	}
}
