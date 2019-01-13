using BL.Abstractions;
using DAL;
using DAL.Abstractions;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace BL.Services
{
	public class SellerService : ISellerService
	{
		private IUnitOfWork _database;
		private IGenericRepository<Seller> _repos;
		private bool disposed = false;

		public SellerService(IUnitOfWork db)
		{
			_database = db;
			_repos = _database.GetRepository<Seller>();
		}

		public SellerService() : this(new UnitOfWork())
		{ }

		public IEnumerable<Seller> Get(Expression<Func<Seller, bool>> filter = null)
		{
			return _repos.Get(filter);
		}

		public bool AddSeller(Seller Seller)
		{
			if (Seller != null)
			{
				TryValidateMode(Seller);
				_repos.Insert(Seller);
				_database.Save();
			}
			return true;
		}

		public bool EditSeller(Seller Seller)
		{
			if (Seller == null)
			{
				throw new ArgumentNullException("Seller is null");
			}

			TryValidateMode(Seller);

			var oldSeller = _repos.GetById(Seller.Id);
			if (oldSeller != null)
			{
				oldSeller.Name = Seller.Name;
				_repos.Update(oldSeller);
				_database.Save();
			}
			return true;
		}

		public void Delete(int id)
		{
			_repos.Delete(id);
			_database.Save();
		}

		public Seller GetById(int id)
		{
			return _repos.GetById(id);
		}

		private void TryValidateMode(Seller Seller)
		{
			if (string.IsNullOrEmpty(Seller.Name))
			{
				throw new ArgumentNullException("Seller name empty or null");
			}

			if (Seller.Name.Length < 3 || Seller.Name.Length > 100)
			{
				throw new ArgumentOutOfRangeException("Seller name length out of range");
			}
		}

		protected virtual void Dispose(bool dispose)
		{
			if (!disposed)
			{
				if (dispose)
				{
					_database.Save();
					disposed = true;
				}
			}
		}

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(true);
		}
	}
}
