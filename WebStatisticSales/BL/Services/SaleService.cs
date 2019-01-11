using DAL.Abstractions;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BL.Services
{
	//TODO: Method save in unit of work
	public class SaleService
	{
		private UnitOfWork unit = new UnitOfWork();
		private IGenericRepository<Sale> _repos;

		public SaleService()
		{
			_repos = unit.GetRepository<Sale>();
		}

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
				_repos.Save();
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
				_repos.Save();
			}
			return true;
		}

		public void Delete(int id)
		{
			_repos.Delete(id);
			_repos.Save();
		}

		public Sale GetById(int id)
		{
			return _repos.GetById(id);
		}

		private void TryValidateMode(Sale sale)
		{
			var clientRep = unit.GetRepository<Client>();
			var productRep = unit.GetRepository<Product>();
			var sellerRep = unit.GetRepository<Seller>();

			if (productRep.GetById(sale.ProductId) == null) throw new InvalidOperationException("Product Id not exist");
			if (clientRep.GetById(sale.ClientId) == null) throw new InvalidOperationException("Client Id not exist");
			if (sellerRep.GetById(sale.SellerId) == null) throw new InvalidOperationException("Seller Id not exist");
			if (sale.Cost <= 0 || sale.Cost > int.MaxValue) throw new ArgumentOutOfRangeException("Summa out of range");
			if (sale.Date == null) throw new ArgumentNullException("Date is null");
		}
	}
}
