using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DAL.Abstractions
{
	public interface IConcurrencyAccessFactory
	{
		IСompetitiveAccess<Entity> GetInstance<Entity>(IGenericRepository<Entity> rep, ReaderWriterLockSlim lockSlim) where Entity : class;
	}
}
