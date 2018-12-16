using System.Data.Entity;

namespace Entities.Abstractions
{
	public interface IDbContextFactory
	{
		DbContext GetContext();
	}
}
