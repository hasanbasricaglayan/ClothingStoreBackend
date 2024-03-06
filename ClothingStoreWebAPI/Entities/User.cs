using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClothingStoreWebAPI.Entities
{
	public class User
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int UserId { get; set; }

		public string FirstName { get; set; } = string.Empty;
		public string LastName { get; set; } = string.Empty;
		public string PhoneNumber { get; set; } = string.Empty;
		public string Email { get; set; } = string.Empty;
		public string Password { get; set; } = string.Empty;
		public DateOnly DateOfBirth { get; set; }
		public string BillingAdress { get; set; } = string.Empty;
		public string DeliveryAdress { get; set; } = string.Empty;
		public bool IsAdmin { get; set; }

		public List<Order> Orders { get; set; } = [];
	}
}
