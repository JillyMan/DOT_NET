using System;
using System.Linq;
using System.Linq.Expressions;

namespace DAL.Abstractions
{
	public interface IGenericRepository<T>
	{
		IQueryable<T> Get(Expression<Func<T, bool>> filter = null, string includeProperties = "");
		T GetById(object id);
		void Insert(T item);
		void Update(T item);
		void Delete(object id);
		void Delete(T item);
		void Save();
	}
}
