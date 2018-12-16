using System.Data.Entity;

namespace DAL.Abstractions
{
	public interface IRepositoryFactory
	{
		IGenericRepository<Entity> GetRepository<Entity>(DbContext context) where Entity : class;
	}
}
