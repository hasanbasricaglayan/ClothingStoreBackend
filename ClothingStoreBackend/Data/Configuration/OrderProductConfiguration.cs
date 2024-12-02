using ClothingStoreBackend.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClothingStoreBackend.Data.Configuration
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
					Quantity = 2,
					Price = 10.99
				},
				new OrderProduct
				{
					OrderId = 1,
					ProductId = 2,
					Quantity = 3,
					Price = 20.99
				},
				new OrderProduct
				{
					OrderId = 1,
					ProductId = 3,
					Quantity = 1,
					Price = 30.99
				},
				new OrderProduct
				{
					OrderId = 2,
					ProductId = 4,
					Quantity = 1,
					Price = 4.99
				},
				new OrderProduct
				{
					OrderId = 2,
					ProductId = 5,
					Quantity = 2,
					Price = 5.99
				},
				new OrderProduct
				{
					OrderId = 3,
					ProductId = 6,
					Quantity = 1,
					Price = 6.99
				},
				new OrderProduct
				{
					OrderId = 4,
					ProductId = 7,
					Quantity = 4,
					Price = 7.99
				}
			];
			builder.HasData(orderProducts);
		}
	}
}
