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

		public Entity TryGet(Expression<Func<Entity, bool>> searchCriteria, bool safeMode = false)
		{
			if (searchCriteria == null)
			{
				return null;
			}

			if (safeMode)
			{
				_locker.EnterReadLock();
			}

			Entity entity = null;

			try
			{
				entity = _repository.Get(searchCriteria).FirstOrDefault();
			}
			finally
			{
				if (safeMode)
				{
					_locker.ExitReadLock();
				}
			}

			return entity;
		}

		public void Load(Entity entity, Expression<Func<Entity, bool>> searchExpression)
		{
			_locker.EnterWriteLock();

			try
			{
				if(TryGet(searchExpression) == null)
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