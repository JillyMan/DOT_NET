using DAL.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Linq.Expressions;
using System.Threading;

namespace DAL
{
	public class ConcurrencyAccess<Entity> : IСompetitiveAccess<Entity>
		where Entity : class
	{
		private IGenericRepository<Entity> _repository;
		private ReaderWriterLockSlim _locker;

		public ConcurrencyAccess(IGenericRepository<Entity> repository, ReaderWriterLockSlim locker)
		{
			_repository = repository;
			_locker = locker;
		}

		public Entity TryGet(Expression<Func<Entity, bool>> searchCriteria)
		{
			_locker.EnterReadLock();

			Entity entity = null;

			try
			{
				entity = _repository.Get(searchCriteria).FirstOrDefault();
			}
			finally
			{
				_locker.ExitReadLock();
			}

			return entity;
		}

		public void Load(Entity entity)
		{
			_locker.EnterWriteLock();

			try
			{
				_repository.Insert(entity);
				_repository.Save();
			}
			finally
			{
				_locker.ExitWriteLock();
			}
		}
	}
}