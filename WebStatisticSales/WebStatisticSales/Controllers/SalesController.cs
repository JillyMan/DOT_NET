using AutoMapper;
using BL.Services;
using DAL;
using DAL.Abstractions;
using DAL.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using WebStatisticSales.Models;

namespace WebStatisticSales.Controllers
{
	public class SalesController : Controller
    {
		private SaleService saleService = new SaleService();

		private SalesDbContext _context;

		private IGenericRepository<Client> _repositoryClients;
		private IGenericRepository<Seller> _repositorySellers;
		private IGenericRepository<Product> _repositoryProducts;

		public SalesController()
		{
			_context = new SalesDbContext();
			_repositoryClients  = new GenericRepository<Client>(_context);
			_repositorySellers = new GenericRepository<Seller>(_context);
			_repositoryProducts = new GenericRepository<Product>(_context);
		}

        [HttpGet]
        public ActionResult Index()
		{
			return View();
        }

		[HttpGet]
		public PartialViewResult Load(SaleFilterView filter, int? page)
		{
			var sales = saleService.Get();

			if (filter != null)
			{
				if (filter.ClientFilter != null)
				{
					sales = sales.Where(x => x.Client.Name.Equals(filter.ClientFilter));
				}

				if (filter.ProductFilter != null)
				{
					sales = sales.Where(x => x.Product.Name.Equals(filter.ProductFilter));
				}

				if (filter.SellerFilter != null)
				{
					sales = sales.Where(x => x.Seller.Name.Equals(filter.SellerFilter));
				}

				if (filter.CostFilter > 0)
				{
					sales = sales.Where(x => x.Cost == filter.CostFilter);
				}
				ViewBag.Filter = filter;
			}
			else
			{
				ViewBag.Filter = new SaleFilterView();
			}

			var salesView = Mapper.Map<IEnumerable<Sale>, List<SaleView>>(sales);

			int pageSize = 8;
			int pageNumber = page ?? 1;
		
			return PartialView(salesView.ToPagedList(pageNumber, pageSize));
		}

		[Authorize(Roles = "Admin")]
		[HttpGet]
		public PartialViewResult Create()
		{
			ViewBag.Clients = new SelectList(_repositoryClients.Get(), "Id", "Name");
			ViewBag.Products = new SelectList(_repositoryProducts.Get(), "Id", "Name");
			ViewBag.Sellers = new SelectList(_repositorySellers.Get(), "Id", "Name");

			return PartialView();
		}

		[Authorize(Roles = "Admin")]
		[HttpPost]
		public JsonResult Create([Bind(Include ="ClientId,ProductId,SellerId,Cost,Date")] SaleCreateView createdSale)
		{
			if (ModelState.IsValid)
			{
				var saleForInsert = Mapper.Map<Sale>(createdSale);

				try
				{
					saleService.AddSale(saleForInsert);
					return Json(new { result=true, message="Sale added"});
				}
				catch (Exception e)
				{
					return Json(new { result=false, message = "Server error, sorry" });
				}
			}

			return Json(new { result = false, message="Model is invalid"});
		}

		[Authorize(Roles = "Admin")]
		[HttpGet]
		public JsonResult Delete(int id)
		{
			if(id > 0)
			{
				try
				{
					saleService.Delete(id);
					return Json(new { result = true }, JsonRequestBehavior.AllowGet);
				}
				catch(Exception e)
				{
					return Json(new { result = true, message="Server error, sorry" }, JsonRequestBehavior.AllowGet);
				}
			}
			return Json(new { result = false, message = "Can't delete, Sorry.." }, JsonRequestBehavior.AllowGet);
		}

		[Authorize(Roles = "Admin")]
		[HttpGet]
		public PartialViewResult Edit(int id)
		{
			if(id > 0)
			{
				var sale = saleService.GetById(id);
				if(sale == null)
				{
					return PartialView("~/Views/Shared/Error.cshtml");
				}

				var editSaleView = Mapper.Map<SaleEditView>(sale);

				//TODO: use unit of work for geting values..
				ViewBag.Clients = new SelectList(_repositoryClients.Get(), "Id", "Name");
				ViewBag.Products = new SelectList(_repositoryProducts.Get(), "Id", "Name");
				ViewBag.Sellers = new SelectList(_repositorySellers.Get(), "Id", "Name");

				return PartialView(editSaleView);
			}
			return PartialView("~/Views/Shared/Error.cshtml");
		}

		[Authorize(Roles = "Admin")]
		[HttpPost]
		public JsonResult Edit([Bind(Include = "Id,ClientId,ProductId,SellerId,Cost,Date")] SaleEditView saleEdit)
		{
			if (!ModelState.IsValid)
			{
				return Json(new { result = false, message = "Invalid data" });
			}

			var saleForUpdate = Mapper.Map<Sale>(saleEdit);
			try
			{
				saleService.EditSale(saleForUpdate);
				return Json(new { result = true });
			}
			catch (Exception e)
			{
				return Json(new { result=false, message = "Can't edit, server error"});
			}
		}
	}
}