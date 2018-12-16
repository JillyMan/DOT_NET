using System.Data.Entity;
using System.Threading;

namespace DAL.Abstractions
{
	public interface IConcurrencyAccessFactory
	{
		IСompetitiveAccess<Entity> GetInstance<Entity>(DbContext context, ReaderWriterLockSlim lockSlim) where Entity : class;
	}
}
