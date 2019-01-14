using BL.Abstractions;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BL.Chart
{
	public class ProductsYearsChart
	{
		public class YearProductsCount
		{
			public int Year { get; set; }
			public ProductCount[] ProductCount { get; set; }
		}

		public class ProductCount
		{
			public Product Product { get; set; }
			public int Count { get; set; }
		}

		private ISaleService saleService;

		public ProductsYearsChart(ISaleService saleService)
		{
			this.saleService = saleService;
		}

		public YearProductsCount[] Build(IEnumerable<int> products, IEnumerable<int> years)
		{
			if(products == null || years == null)
			{
				throw new ArgumentNullException();
			}

			if (products.Count() == 0 || years.Count() == 0)
			{
				throw new ArgumentException();
			}

			YearProductsCount[] result = new YearProductsCount[years.Count()];

			for (int i = 0; i < result.Length; ++i)
			{
				result[i] = new YearProductsCount() { Year = years.ElementAt(i) };
				result[i].ProductCount = new ProductCount[products.Count()];

				for (int j = 0; j < products.Count(); ++j)
				{
					result[i].ProductCount[j] = GetProductCount(years.ElementAt(i), products.ElementAt(j));
				}
			}

			return result;
		}

		private ProductCount GetProductCount(int year, int idProd)
		{
			var result = saleService.Get()
				.Where(x => x.Date.Year == year && x.ProductId == idProd)
				.GroupBy(x => x.Date.Year)
				.Select(x => new ProductCount
				{
					Product = x.First().Product,
					Count = x.Count()
				}).FirstOrDefault();

			if (result == null)
			{
				result = new ProductCount
				{
					Product = null,
					Count = 0
				};
			}

			return result;
		}
	}
}
