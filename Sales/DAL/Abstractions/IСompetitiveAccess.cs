using System;
using System.Linq.Expressions;

namespace DAL.Abstractions
{
	public interface IСompetitiveAccess<Entity> where Entity : class
	{
		Entity TryGet(Expression<Func<Entity, bool>> filter);
		void TryLoad(Entity entity, Expression<Func<Entity, bool>> expression);
	}
}
