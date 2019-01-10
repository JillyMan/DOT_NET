using System.Data.Entity;

namespace DAL.Models
{
	public class SalesDbContext : DbContext
	{
		public SalesDbContext() :
			base("SalesDatabase")
		{
		}

		public DbSet<Client> Clients { get; set; }
		public DbSet<Product> Products { get; set; }
		public DbSet<Seller> Sellers { get; set; }
		public DbSet<Sale> Purchases { get; set; }
	}
}
