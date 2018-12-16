using DAL.Abstractions;
using System.Threading;

namespace DAL.Factory
{
	public class ConcurrencyAccessFactory : IConcurrencyAccessFactory
	{
		public IСompetitiveAccess<Entity> GetInstance<Entity>(IGenericRepository<Entity> rep, ReaderWriterLockSlim lockSlim) where Entity : class
		{
			return new ConcurrencyAccess<Entity>(rep, lockSlim);
		}
	}
}
