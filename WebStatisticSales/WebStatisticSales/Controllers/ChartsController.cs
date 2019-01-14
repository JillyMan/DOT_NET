using BL.Chart;
using BL.Services;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Linq;
using WebStatisticSales.Models;

namespace WebStatisticSales.Controllers
{
    public class ChartsController : Controller
    {
		private SaleService saleService = new SaleService();

		[HttpGet]
		public ActionResult Index()
		{
			return View();
		}

		[HttpGet]
		public PartialViewResult GetBuildProductsYearChart()
		{
			using (var productService = new ProductService())
			{
				ViewBag.Products = new SelectList(productService.Get(), "Id", "Name");
			}

			return PartialView("SaleCharts");
		}

		[HttpGet]
		public JsonResult BuildProductsYearsChart(ChartsViewModels model)
		{
			if (ModelState.IsValid)
			{
				ProductsYearsChart chart = new ProductsYearsChart(saleService);

				var products = new List<int>() { model.FirstProductId, model.SecondProductId, model.ThirdProductId };
				var years = new List<int>() { model.FirstYear, model.SecondYear2 };

				var chartData = chart.Build(products, years);

				if(chartData == null)
				{
					return Json(null, JsonRequestBehavior.AllowGet);
				}

				var item = chartData.Select( x => new object[]
				{
					x.Year.ToString(),
					x.ProductCount[0].Count,
					x.ProductCount[1].Count,
					x.ProductCount[2].Count
				}).ToArray();

				return Json(item, JsonRequestBehavior.AllowGet);
				
			}

			return Json(new { result = false, message = "Model is invalid"}, JsonRequestBehavior.AllowGet);
		}

		[HttpGet]
		public PartialViewResult GetBuildLastSalesChart()
		{
			return PartialView("SaleForLastYears");
		}

		[HttpGet]
		public JsonResult BuildLastSalesChart(int lastYears)
		{
			if(lastYears <= 0)
			{
				return Json(null, JsonRequestBehavior.AllowGet);
			}

			LastSalesChart chartBuilder = new LastSalesChart(saleService);
			var item = chartBuilder.Build(lastYears)
				.Select(x => new object[]
				{
					x.Year.ToString(), x.Count
				});

			return Json(item, JsonRequestBehavior.AllowGet);
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				saleService.Dispose();
			}

			base.Dispose(disposing);
		}

	}
}