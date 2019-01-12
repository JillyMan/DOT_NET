using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace BL.Abstractions
{
	public interface IProductService : IDisposable
	{
		IEnumerable<Product> Get(Expression<Func<Product, bool>> filter = null);
		bool AddProduct(Product product);
		bool EditProduct(Product product);
		void Delete(int id);
	}
}
