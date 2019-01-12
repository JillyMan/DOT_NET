using BL.Abstractions;
using DAL;
using DAL.Abstractions;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace BL.Services
{
	public class SaleService : ISaleService
	{
		private IUnitOfWork _database;
		private IGenericRepository<Sale> _repos;
		private bool disposed = false;

		public SaleService(IUnitOfWork db)
		{
			_database = db;
			_repos = _database.GetRepository<Sale>();
		}

		public SaleService() : this(new UnitOfWork())
		{ }


		public IEnumerable<Sale> Get(Expression<Func<Sale, bool>> filter = null, bool lazyLoad = true)
		{
			if(lazyLoad == true)
			{
				return _repos.Get(filter);
			}
			return _repos.Get(filter, "Client,Seller,Product");
		}

		public bool AddSale(Sale sale)
		{
			if (sale != null)
			{
				TryValidateMode(sale);
				_repos.Insert(sale);
				_database.Save();
			}
			return true;
		}

		public bool EditSale(Sale sale)
		{
			if(sale == null)
			{
				throw new ArgumentNullException("Sale is null");
			}

			TryValidateMode(sale);

			var oldSale = _repos.GetById(sale.Id);
			if(oldSale != null)
			{
				oldSale.ClientId = sale.ClientId;
				oldSale.SellerId = sale.SellerId;
				oldSale.ProductId = sale.ProductId;

				_repos.Update(oldSale);
				_database.Save();
			}
			return true;
		}

		public void Delete(int id)
		{
			_repos.Delete(id);
			_database.Save();
		}

		public Sale GetById(int id)
		{
			return _repos.GetById(id);
		}

		private void TryValidateMode(Sale sale)
		{
			var clientRep = _database.GetRepository<Client>();
			var productRep = _database.GetRepository<Product>();
			var sellerRep = _database.GetRepository<Seller>();

			if (productRep.GetById(sale.ProductId) == null) throw new InvalidOperationException("Product Id not exist");
			if (clientRep.GetById(sale.ClientId) == null) throw new InvalidOperationException("Client Id not exist");
			if (sellerRep.GetById(sale.SellerId) == null) throw new InvalidOperationException("Seller Id not exist");
			if (sale.Cost <= 0 || sale.Cost > int.MaxValue - 1) throw new ArgumentOutOfRangeException("Summa out of range");
			if (sale.Date == null) throw new ArgumentNullException("Date is null");
		}

		private void Dispose(bool dispose)
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
