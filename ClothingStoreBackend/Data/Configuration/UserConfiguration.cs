using ClothingStoreBackend.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClothingStoreBackend.Data.Configuration
{
	public class UserConfiguration : IEntityTypeConfiguration<User>
	{
		public void Configure(EntityTypeBuilder<User> builder)
		{
			User[] users =
			[
				new User(1)
				{
					IsAdmin = true
				},
				new User(2)
				{
					IsAdmin = true
				},
				new User(3)
				{
					IsAdmin = false
				},
				new User(4)
				{
					IsAdmin = false
				}
			];
			builder.HasData(users);
		}
	}
}
