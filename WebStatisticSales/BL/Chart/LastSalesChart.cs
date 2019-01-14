using BL.Abstractions;
using System;
using System.Linq;

namespace BL.Chart
{
	public class LastSalesChart
	{
		public class YearCount
		{
			public int Year { get; set; }
			public int Count { get; set; }
		}

		private ISaleService saleService;
		public LastSalesChart(ISaleService saleService)
		{
			this.saleService = saleService;
		}

		public YearCount[] Build(int lastYears)
		{
			if(lastYears <= 0)
			{
				throw new ArgumentException("lastYear <= 0");
			}

			int currYear = DateTime.Now.Year;
			int min = currYear - lastYears;

			var result = saleService.Get()
				.Where(x => x.Date.Year >= min && x.Date.Year <= currYear)
				.GroupBy(x => x.Date.Year)
				.Select(x => new YearCount
				{
					Year = x.Key,
					Count = x.Count()
				}).ToArray();

			return result;
		}
	}
}
