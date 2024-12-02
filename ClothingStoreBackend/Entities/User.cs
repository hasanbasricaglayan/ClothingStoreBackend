using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClothingStoreBackend.Entities
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
		public DateOnly DateOfBirth { get; set; } = DateOnly.FromDateTime(DateTime.Now);
		public string BillingAddress { get; set; } = string.Empty;
		public string DeliveryAddress { get; set; } = string.Empty;
		public bool IsAdmin { get; set; }

		public List<Order> Orders { get; set; } = [];

		public User() { }

		public User(int userId)
		{
			UserId = userId;
			FirstName = $"Prénom {userId}";
			LastName = $"Nom {userId}";
			PhoneNumber = $"+33{userId}";
			Email = $"email_{userId}@mail.com";
			Password = $"Password_{userId}";
			DateOfBirth = DateOnly.FromDateTime(DateTime.Now);
			BillingAddress = $"Adresse de facturation {userId}";
			DeliveryAddress = $"Adresse de livraison {userId}";
		}
	}
}
