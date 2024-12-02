using ClothingStoreBackend.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClothingStoreBackend.Data.Configuration
{
	public class OrderConfiguration : IEntityTypeConfiguration<Order>
	{
		public void Configure(EntityTypeBuilder<Order> builder)
		{
			Order[] orders =
			[
				new Order(1)
				{
					UserId = 1,
					Status = "Livrée"
				},
				new Order(2)
				{
					UserId = 2,
					Status = "En attente"
				},
				new Order(3)
				{
					UserId = 2,
					Status = "Validée"
				},
				new Order(4)
				{
					UserId = 2,
					Status = "Expédiée"
				}
			];
			builder.HasData(orders);
		}
	}
}
