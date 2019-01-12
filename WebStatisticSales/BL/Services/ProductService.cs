using BL.Abstractions;
using DAL.Abstractions;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace BL.Services
{
	public class ProductService : IProductService
	{
		private IUnitOfWork _database;
		private IGenericRepository<Product> _repos;
		public bool disposed = true;

		public ProductService(IUnitOfWork db)
		{
			_database = db;
			_repos = _database.GetRepository<Product>();
		}

		public ProductService() : this(new UnitOfWork())
		{ }

		public IEnumerable<Product> Get(Expression<Func<Product, bool>> filter = null)
		{
			return _repos.Get(filter);
		}

		public bool AddProduct(Product Product)
		{
			if (Product != null)
			{
				TryValidateMode(Product);
				_repos.Insert(Product);
				_database.Save();
			}
			return true;
		}

		public bool EditProduct(Product product)
		{
			if (product == null)
			{
				throw new ArgumentNullException("Product is null");
			}

			TryValidateMode(product);

			var oldProduct = _repos.GetById(product.Id);
			if (oldProduct != null)
			{
				oldProduct.Name = product.Name;
				_repos.Update(oldProduct);
				_database.Save();
			}
			return true;
		}

		public void Delete(int id)
		{
			_repos.Delete(id);
			_database.Save();
		}

		public Product GetById(int id)
		{
			return _repos.GetById(id);
		}

		private void TryValidateMode(Product Product)
		{
			if (string.IsNullOrEmpty(Product.Name))
			{
				throw new ArgumentNullException("Product name empty or null");
			}

			if(Product.Name.Length > 0 && Product.Name.Length < 100)
			{
				throw new ArgumentOutOfRangeException("Product name length out of range");
			}
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
