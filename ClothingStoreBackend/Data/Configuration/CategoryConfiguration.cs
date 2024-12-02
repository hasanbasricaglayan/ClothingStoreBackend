using ClothingStoreBackend.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClothingStoreBackend.Data.Configuration
{
	public class CategoryConfiguration : IEntityTypeConfiguration<Category>
	{
		public void Configure(EntityTypeBuilder<Category> builder)
		{
			Category[] categories =
			[
				new Category(1)
				{
					Name = "Chemises"
				},
				new Category(2)
				{
					Name = "T-shirts"
				},
				new Category(3)
				{
					Name = "Polos"
				},
				new Category(4)
				{
					Name = "Sweats"
				},
				new Category(5)
				{
					Name = "Pulls"
				},
				new Category(6)
				{
					Name = "Gilets"
				},
				new Category(7)
				{
					Name = "Vestes"
				},
				new Category(8)
				{
					Name = "Blousons"
				},
				new Category(9)
				{
					Name = "Manteaux"
				},
				new Category(10)
				{
					Name = "Pantalons"
				},
				new Category(11)
				{
					Name = "Jeans"
				},
				new Category(12)
				{
					Name = "Costumes"
				},
				new Category(13)
				{
					Name = "Chaussures"
				},
				new Category(14)
				{
					Name = "Accessoires"
				}
			];
			builder.HasData(categories);
		}
	}
}
