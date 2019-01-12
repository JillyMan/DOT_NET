using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace BL.Abstractions
{
	public interface ISellerService : IDisposable
	{
		IEnumerable<Seller> Get(Expression<Func<Seller, bool>> filter = null);
		bool AddSeller(Seller product);
		bool EditSeller(Seller product);
		void Delete(int id);
	}
}
