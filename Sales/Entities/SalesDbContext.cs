using System.Data.Entity;

namespace Entities
{
	public class SalesDbContext : DbContext
	{
		//TODO: Get connection name from .config
		public SalesDbContext() : 
			base("DBConnection")
		{
		}

		DbSet<Client> Clients { get; set; }
		DbSet<Product> Product { get; set; }
		DbSet<Sales> Sales { get; set; }
	}
}
