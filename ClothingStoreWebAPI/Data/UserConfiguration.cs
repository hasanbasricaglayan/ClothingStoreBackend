using ClothingStoreWebAPI.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClothingStoreWebAPI.Data
{
	public class UserConfiguration : IEntityTypeConfiguration<User>
	{
		public void Configure(EntityTypeBuilder<User> builder)
		{
			User[] users =
			[
				new User
				{
					UserId = 1,
					FirstName = "Mouhammad",
					LastName = "Nour",
					PhoneNumber = "0606060601",
					Email = "mouhammad.nour@gmail.com",
					Password = "MouhammadN_1",
					DateOfBirth = new DateOnly(1999, 1, 1),
					BillingAdress = "Grenoble, France",
					DeliveryAdress = "Grenoble, France",
					IsAdmin = true
				},
				new User
				{
					UserId = 2,
					FirstName = "Hasan-Basri",
					LastName = "Caglayan",
					PhoneNumber = "0606060602",
					Email = "hasanbasri.caglayan@gmail.com",
					Password = "HasanBasriC_2",
					DateOfBirth = new DateOnly(2000, 1, 1),
					BillingAdress = "Clermont-Ferrand, France",
					DeliveryAdress = "Clermont-Ferrand, France",
					IsAdmin = true
				},
				new User
				{
					UserId = 3,
					FirstName = "Victor",
					LastName = "Hugo",
					PhoneNumber = "0606060603",
					Email = "victor.hugo@gmail.com",
					Password = "VictorH_3",
					DateOfBirth = new DateOnly(2001, 1, 1),
					BillingAdress = "Paris, France",
					DeliveryAdress = "Paris, France",
					IsAdmin = false
				},
				new User
				{
					UserId = 4,
					FirstName = "Albert",
					LastName = "Camus",
					PhoneNumber = "0606060604",
					Email = "albert.camus@gmail.com",
					Password = "AlbertC_4",
					DateOfBirth = new DateOnly(2002, 1, 1),
					BillingAdress = "Marseille, France",
					DeliveryAdress = "Marseille, France",
					IsAdmin = false
				}
			];
			builder.HasData(users);
		}
	}
}
