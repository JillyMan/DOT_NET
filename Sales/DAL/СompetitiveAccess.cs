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
		private bool disposed;

		public ConcurrencyAccess(IGenericRepository<Entity> repository, ReaderWriterLockSlim locker)
		{
			_repository = repository;
			_locker = locker;
			disposed = false;
		}

		public Entity TryGet(Expression<Func<Entity, bool>> filter)
		{
			_locker.EnterReadLock();

			Entity entity = null;

			try
			{
				entity = _repository.Get(filter).FirstOrDefault();
			}
			finally
			{
				_locker.ExitReadLock();
			}

			return entity;
		}

		public void TryLoad(Entity entity, Expression<Func<Entity, bool>> expression)
		{
			_locker.EnterWriteLock();

			try
			{
				if (TryGet(expression) == null)
				{
					_repository.Insert(entity);
					_repository.Save();
				}
			}
			finally
			{
				_locker.ExitWriteLock();
			}
		}
	}
}
