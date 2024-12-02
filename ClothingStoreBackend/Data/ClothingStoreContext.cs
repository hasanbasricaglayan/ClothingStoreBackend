using ClothingStoreBackend.Data.Configuration;
using ClothingStoreBackend.Entities;
using Microsoft.EntityFrameworkCore;

namespace ClothingStoreBackend.Data
{
	public class ClothingStoreContext : DbContext
	{
		private IConfiguration _configuration;

		public DbSet<Category> Categories { get; set; }
		public DbSet<Product> Products { get; set; }
		public DbSet<User> Users { get; set; }
		public DbSet<Order> Orders { get; set; }
		public DbSet<OrderProduct> OrderProducts { get; set; }

		public ClothingStoreContext(IConfiguration configuration)
		{
			_configuration = configuration;
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer(_configuration.GetConnectionString("ClothingStoreDb"));
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<OrderProduct>().HasKey(orderProduct => new { orderProduct.OrderId, orderProduct.ProductId });
			modelBuilder.ApplyConfiguration(new CategoryConfiguration());
			modelBuilder.ApplyConfiguration(new ProductConfiguration());
			modelBuilder.ApplyConfiguration(new UserConfiguration());
			modelBuilder.ApplyConfiguration(new OrderConfiguration());
			modelBuilder.ApplyConfiguration(new OrderProductConfiguration());
		}
	}
}
