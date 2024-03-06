using ClothingStoreWebAPI.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClothingStoreWebAPI.Data
{
	public class CategoryConfiguration : IEntityTypeConfiguration<Category>
	{
		public void Configure(EntityTypeBuilder<Category> builder)
		{
			Category[] categories =
			[
				new Category
				{
					CategoryId = 1,
					Name = "Homme",
				},
				new Category
				{
					CategoryId = 2,
					Name = "Femme",
				},
				new Category
				{
					CategoryId = 3,
					Name = "Enfant",
				}
			];
			builder.HasData(categories);
		}
	}
}
