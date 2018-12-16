using DAL.Abstractions;
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
	
		public GenericRepository(DbContext context)
		{
			this.context = context;
			this.container = context.Set<T>();
		}

		public virtual void Insert(T item)
		{
			if(item == null)
			{
				throw new ArgumentNullException("Item is null!");
			}
			container.Add(item);
		}

		public virtual void Delete(object id)
		{
			if (id == null)
			{
				throw new ArgumentNullException("Item is null!");
			}
			T entiy = container.Find(id);
			container.Remove(entiy);
		}

		public virtual void Delete(T item)
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

		public virtual IQueryable<T> Get(Expression<Func<T, bool>> filter = null)
		{
			IQueryable<T> query = container;
			if(filter != null)
			{
				query = query.Where(filter);
			}
			return query;
		}

		public virtual T GetById(object id)
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

		public virtual void Update(T item)
		{
			if(item == null)
			{
				throw new ArgumentNullException("Item is null");
			}

			container.Attach(item);
			context.Entry(item).State = EntityState.Modified;
		}
	}
}
