using System.Data.Entity;

namespace Entities
{
	public class SalesDbContext : DbContext
	{
		//TODO: Get connection name from .config
		public SalesDbContext() : 
			base("DBSales")
		{
		}

		public DbSet<Client> Clients { get; set; }
		public DbSet<Manager> Managers { get; set; }
		public DbSet<Product> Products { get; set; }
		public DbSet<Sale> Sales { get; set; }
		public DbSet<SourceDataSale> SourseDataSales { get; set; }
	}
}
