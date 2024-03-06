using ClothingStoreWebAPI.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClothingStoreWebAPI.Data
{
	public class OrderProductConfiguration : IEntityTypeConfiguration<OrderProduct>
	{
		public void Configure(EntityTypeBuilder<OrderProduct> builder)
		{
			OrderProduct[] orderProducts =
			[
				new OrderProduct
				{
					OrderId = 1,
					ProductId = 1,
					Quantity = 3,
					Price = 49.75,
				},
				new OrderProduct
				{
					OrderId = 1,
					ProductId = 3,
					Quantity = 2,
					Price = 9.99,
				},
				new OrderProduct
				{
					OrderId = 4,
					ProductId = 1,
					Quantity = 1,
					Price = 59.99,
				},
				new OrderProduct
				{
					OrderId = 5,
					ProductId = 2,
					Quantity = 1,
					Price = 19.99,
				},
				new OrderProduct
				{
					OrderId = 5,
					ProductId = 3,
					Quantity = 2,
					Price = 12.99,
				}
			];
			builder.HasData(orderProducts);
		}
	}
}
