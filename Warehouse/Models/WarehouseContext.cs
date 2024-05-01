using Microsoft.EntityFrameworkCore;

namespace Warehouse.Models
{
	public class WarehouseContext : DbContext
	{
        public DbSet<UserDataModel> User { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			var configuration = new ConfigurationBuilder()
				.SetBasePath(AppContext.BaseDirectory)
				.AddJsonFile("appsettings.json", optional: true)
				.Build();
			optionsBuilder.UseMySQL(configuration.GetConnectionString("Warehouse"));
		}
	}
}
