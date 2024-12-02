using ClothingStoreBackend.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClothingStoreBackend.Data.Configuration
{
	public class ProductConfiguration : IEntityTypeConfiguration<Product>
	{
		public void Configure(EntityTypeBuilder<Product> builder)
		{
			Product[] products =
			[
				new Product(1)
				{
					CategoryId = 1
				},
				new Product(2)
				{
					CategoryId = 1
				},
				new Product(3)
				{
					CategoryId = 2
				},
				new Product(4)
				{
					CategoryId = 2
				},
				new Product(5)
				{
					CategoryId = 3
				},
				new Product(6)
				{
					CategoryId = 3
				},
				new Product(7)
				{
					CategoryId = 4
				},
				new Product(8)
				{
					CategoryId = 4
				},
				new Product(9)
				{
					CategoryId = 5
				},
				new Product(10)
				{
					CategoryId = 5
				}
			];
			builder.HasData(products);
		}
	}
}
