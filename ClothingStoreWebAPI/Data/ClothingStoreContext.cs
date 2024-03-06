using ClothingStoreWebAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace ClothingStoreWebAPI.Data
{
	public class ClothingStoreContext : DbContext
	{
		private IConfiguration _configuration;

		public DbSet<User> Users { get; set; }
		public DbSet<Order> Orders { get; set; }
		public DbSet<Product> Products { get; set; }
		public DbSet<OrderProduct> OrderProducts { get; set; }
		public DbSet<Category> Categories { get; set; }

		public ClothingStoreContext(IConfiguration configuration)
		{
			_configuration = configuration;
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer(_configuration.GetConnectionString("ClothingStoreDb"));

			// Pour désactiver le suivi (tracking) des modifications
			//optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);

			// Pour afficher la journalisation (le log) d'EF Core
			//optionsBuilder.LogTo(Console.WriteLine);
			//optionsBuilder.LogTo(Console.WriteLine, new[] { DbLoggerCategory.Database.Command.Name });
			//optionsBuilder.LogTo(Console.WriteLine, new[] { DbLoggerCategory.Database.Command.Name }, LogLevel.Information);
			//optionsBuilder.LogTo(message => Debug.WriteLine(message), new[] { DbLoggerCategory.Database.Command.Name }, LogLevel.Information);

			// Pour forcer l'affichage des paramètres dans les requêtes SQL générées lorsqu'on veut modifier des données
			//optionsBuilder.EnableSensitiveDataLogging();
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<OrderProduct>().HasKey(orderProduct => new { orderProduct.OrderId, orderProduct.ProductId });
			modelBuilder.ApplyConfiguration(new UserConfiguration());
			modelBuilder.ApplyConfiguration(new OrderConfiguration());
			modelBuilder.ApplyConfiguration(new ProductConfiguration());
			modelBuilder.ApplyConfiguration(new OrderProductConfiguration());
			modelBuilder.ApplyConfiguration(new CategoryConfiguration());
		}
	}
}
