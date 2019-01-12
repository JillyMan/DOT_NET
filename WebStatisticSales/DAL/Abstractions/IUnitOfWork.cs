using System;

namespace DAL.Abstractions
{
	public interface IUnitOfWork : IDisposable
	{
		IGenericRepository<Entity> GetRepository<Entity>() where Entity : class;
		void Save();
	}
}
