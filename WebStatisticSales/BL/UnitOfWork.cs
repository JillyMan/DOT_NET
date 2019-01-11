using DAL;
using DAL.Abstractions;
using System;

namespace BL
{
    public class UnitOfWork : IDisposable
    {
		private DAL.Models.SalesDbContext _context = new DAL.Models.SalesDbContext();
		private bool _disposed = false;

		public IGenericRepository<Entity> GetRepository<Entity>() where Entity : class
		{
			return new GenericRepository<Entity>(_context);
		}

		public void Save()
		{
			_context.SaveChanges();
		}

		private void Dispose(bool dispose)
		{
			if (!_disposed)
			{
				if (dispose)
				{
					_context.Dispose();
					_disposed = false;
				}
			}
		}

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}
    }
}
