using System.Data.Entity;
using DAL.Abstractions;

namespace DAL.Factory
{
	public class RepositoryFactory : IRepositoryFactory
	{
		public IGenericRepository<Entity> GetRepository<Entity>(DbContext context) where Entity : class
		{
			return new GenericRepository<Entity>(context);
		}
	}
}
