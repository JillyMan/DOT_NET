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
		private IGenericRepository<Sale> _repositorySales;
		private string _includesPropertiesForSales = "Client,Seller,Product";

		private IGenericRepository<Client> _repositoryClients;
		private IGenericRepository<Seller> _repositorySellers;
		private IGenericRepository<Product> _repositoryProducts;

		public SalesController()
		{
			_context = new SalesDbContext();
			_repositorySales = new GenericRepository<Sale>(_context);
			_repositoryClients  = new GenericRepository<Client>(_context);
			_repositorySellers = new GenericRepository<Seller>(_context);
			_repositoryProducts = new GenericRepository<Product>(_context);
		}

        // GET: Sales
        public ActionResult Index()
		{
            return View();
        }

		[HttpGet]
		public PartialViewResult Load(int? page)
		{
			var sales = AutoMapper.Mapper.Map<IEnumerable<Sale>, List<SaleView>>(_repositorySales.Get(null, _includesPropertiesForSales));
			return PartialView(sales);
		}

		[HttpGet]
		public PartialViewResult Create()
		{
			ViewBag.Clients = new SelectList(_repositoryClients.Get(), "Id", "Name");
			ViewBag.Products = new SelectList(_repositoryProducts.Get(), "Id", "Name");
			ViewBag.Sellers = new SelectList(_repositorySellers.Get(), "Id", "Name");

			return PartialView();
		}

		[HttpPost]
		public JsonResult Create([Bind(Include ="ClientId,ProductId,SellerId,Cost,Date")] SaleCreateView createdSale)
		{
			if (ModelState.IsValid)
			{
				var saleForInsert = AutoMapper.Mapper.Map<Sale>(createdSale);
				_repositorySales.Insert(saleForInsert);
				_repositorySales.Save();
				return Json(new { result = true });
			}

			return Json(new { result = false, message="Model is invalid"});
		}

		[HttpGet]
		public JsonResult Delete(int? id)
		{
			if(id != null && id > 0)
			{
				_repositorySales.Delete(id);
				_repositorySales.Save();

				return Json(new { result = true }, JsonRequestBehavior.AllowGet);
			}
			return Json(new { result = false, message = "Can't delet!" }, JsonRequestBehavior.AllowGet);
		}

		[HttpGet]
		public PartialViewResult Edit(int? id)
		{
			if(id != null && id > 0)
			{
				var sale = _repositorySales.GetById(id);
				if(sale == null)
				{
					/*
					 * TODO: question what does with errors?
					 * saleEdit: contains ID?
					*/
					return PartialView("~/Views/Shared/Error.cshtml");
				}

				SaleEditView editSale = new SaleEditView
				{
					Id = sale.Id,
					Cost = sale.Summa,
					Date = sale.Date,
					ClientId = sale.ClientId.Value,
					SellerId = sale.SellerId.Value,
					ProductId = sale.ProductId.Value,
				};

				ViewBag.Clients = new SelectList(_repositoryClients.Get(), "Id", "Name");
				ViewBag.Products = new SelectList(_repositoryProducts.Get(), "Id", "Name");
				ViewBag.Sellers = new SelectList(_repositorySellers.Get(), "Id", "Name");

				return PartialView(editSale);
			}
			return PartialView("~/Views/Shared/Error.cshtml");
		}

		[HttpPost]
		public JsonResult Edit([Bind(Include = "Id,ClientId,ProductId,SellerId,Cost,Date")] SaleEditView saleEdit)
		{
			if (ModelState.IsValid)
			{
				var saleForUpdate = AutoMapper.Mapper.Map<Sale>(saleEdit);
				_repositorySales.Update(saleForUpdate);
				_repositorySales.Save();
				return Json(new { result = true });
			}

			return Json(new { result = false, message="model is not valid"});
		}
	}
}