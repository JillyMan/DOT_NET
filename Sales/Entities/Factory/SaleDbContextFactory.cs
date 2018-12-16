using System.Data.Entity;
using Entities.Abstractions;

namespace Entities.Factory
{
	public class SaleDbContextFactory : IDbContextFactory
	{
		public DbContext GetContext()
		{
			return new SalesDbContext();
		}
	}
}
