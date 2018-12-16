using DAL.Abstractions;
using System.Data.Entity;
using System.Threading;

namespace DAL.Factory
{
	public class ConcurrencyAccessFactory : IConcurrencyAccessFactory
	{
		private IRepositoryFactory _factory;
		public ConcurrencyAccessFactory(IRepositoryFactory factory)
		{
			_factory = factory;
		}

		public IСompetitiveAccess<Entity> GetInstance<Entity>(DbContext context, ReaderWriterLockSlim lockSlim) where Entity : class
		{
			return new ConcurrencyAccess<Entity>(_factory.GetRepository<Entity>(context), lockSlim);
		}
	}
}
