using ClothingStoreWebAPI.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClothingStoreWebAPI.Data
{
	public class OrderConfiguration : IEntityTypeConfiguration<Order>
	{
		public void Configure(EntityTypeBuilder<Order> builder)
		{
			Order[] orders =
			[
				new Order
				{
					OrderId = 1,
					UserId = 1,
					OrderDate = new DateOnly(2024, 3, 4),
					Status = "Validée"
				},
				new Order
				{
					OrderId = 2,
					UserId = 1,
					OrderDate = new DateOnly(2024, 3, 1),
					Status = "En attente"
				},
				new Order
				{
					OrderId = 3,
					UserId = 2,
					OrderDate = new DateOnly(2024, 2, 29),
					Status = "Expédiée"
				},
				new Order
				{
					OrderId = 4,
					UserId = 2,
					OrderDate = new DateOnly(2024, 2, 14),
					Status = "Livrée"
				},
				new Order
				{
					OrderId = 5,
					UserId = 3,
					OrderDate = new DateOnly(2023, 12, 15),
					Status = "Livrée"
				},
				new Order
				{
					OrderId = 6,
					UserId = 4,
					OrderDate = new DateOnly(2023, 12, 18),
					Status = "Livrée"
				}
			];
			builder.HasData(orders);
		}
	}
}
