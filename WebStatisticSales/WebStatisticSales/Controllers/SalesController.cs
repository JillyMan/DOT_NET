using DAL;
using DAL.Abstractions;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebStatisticSales.Models;

namespace WebStatisticSales.Controllers
{
    public class SalesController : Controller
    {
		private SalesDbContext _context;
		private IGenericRepository<Sale> _repository;

		public SalesController()
		{
			_context = new SalesDbContext();
			_repository = new GenericRepository<Sale>(_context);
		}

        // GET: Sales
        public ActionResult Index()
		{
            return View();
        }

		[HttpGet]
		public PartialViewResult Load(int? page)
		{
 			var sales = AutoMapper.Mapper.Map<IEnumerable<SaleView>>(_repository.Get());
			return PartialView(sales);
		}

		[HttpPost]
		public PartialViewResult Edit(int? id)
		{
			if(id != null && id > 0)
			{
				var sale = AutoMapper.Mapper.Map<IEnumerable<SaleEditView>>(_repository.Get(x => x.Id==id));
				return PartialView(sale);
			}
			return PartialView("~/Views/Shared/Error.cshtml");
		}
	}
}