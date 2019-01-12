using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace BL.Abstractions
{
	public interface ISaleService : IDisposable
	{
		IEnumerable<Sale> Get(Expression<Func<Sale, bool>> filter = null, bool lazeLoad = true);
		bool AddSale(Sale product);
		bool EditSale(Sale product);
		void Delete(int id);
	}
}