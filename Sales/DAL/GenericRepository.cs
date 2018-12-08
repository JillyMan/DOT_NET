using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace DAL
{
	public class GenericRepository<T> : IGenericRepository<T> 
		where T : class
	{
		private DbContext context;
		private DbSet<T> container;
		private bool disposed = false;

		public GenericRepository(DbContext context)
		{
			this.context = context;
			this.container = context.Set<T>();
		}

		public void Insert(T item)
		{
			if(item == null)
			{
				throw new ArgumentNullException("Item is null!");
			}
			container.Add(item);
		}

		public void Delete(object id)
		{
			if (id == null)
			{
				throw new ArgumentNullException("Item is null!");
			}
			T entiy = container.Find(id);
			container.Remove(entiy);
		}

		public void Delete(T item)
		{
			if (item == null)
			{
				throw new ArgumentNullException("Item is null!");
			}
			if(context.Entry(item).State == EntityState.Detached)
			{
				container.Attach(item);
			}
			container.Remove(item);
		}

		public IQueryable<T> Get(Expression<Func<T, bool>> filter = null)
		{
			IQueryable<T> query = container;
			if(filter != null)
			{
				query = query.Where(filter);
			}
			return query;
		}

		public T GetById(object id)
		{
			if (id == null)
			{
				throw new ArgumentNullException("Item is null!");
			}

			return container.Find(id);
		}

		public void Save()
		{
			context.SaveChanges();
		}

		public void Update(T item)
		{
			if(item == null)
			{
				throw new ArgumentNullException("Item is null");
			}

			container.Attach(item);
			context.Entry(item).State = EntityState.Modified;
		}

		public virtual void Dispose(bool disposing)
		{
			if (!this.disposed)
			{
				if (disposing)
				{
					context.Dispose();
				}
			}
			this.disposed = true;
		}

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		~GenericRepository()
		{
			Dispose();
		}
	}
}
