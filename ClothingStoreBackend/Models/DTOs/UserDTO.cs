namespace ClothingStoreBackend.Models
{
	public class UserDTO
	{
		public int? UserId { get; set; }

		public string FirstName { get; set; } = string.Empty;
		public string LastName { get; set; } = string.Empty;
		public string PhoneNumber { get; set; } = string.Empty;
		public string Email { get; set; } = string.Empty;
		public string Password { get; set; } = string.Empty;
		public DateOnly DateOfBirth { get; set; }
		public string BillingAddress { get; set; } = string.Empty;
		public string DeliveryAddress { get; set; } = string.Empty;
		public bool IsAdmin { get; set; } = false;

		public List<OrderDTO> Orders { get; set; } = [];
	}
}
