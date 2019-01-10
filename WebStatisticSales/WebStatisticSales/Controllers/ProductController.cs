using DAL.Abstractions;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebStatisticSales.Controllers
{
    public class ProductController : Controller
    {
		private SalesDbContext _context;
		private IGenericRepository<Product> _repository;

		public ProductController()
		{
			_context = new SalesDbContext();
			_repository = new DAL.GenericRepository<Product>(_context);
		}

		public ActionResult Index()
		{
			return View();
		}

		[HttpGet]
		public PartialViewResult Load()
		{
			var clientsView = AutoMapper.Mapper.Map<IEnumerable<Product>,
				List<Models.ProductIndexView>>(_repository.Get());

			return PartialView(clientsView);
		}

		//[Authorize(Roles = "Admin")]
		[HttpGet]
		public PartialViewResult Create()
		{
			return PartialView();
		}

		//[Authorize(Roles = "Admin")]
		[HttpPost]
		public JsonResult Create([Bind(Include = "Name")] Models.ProductCreateView product)
		{
			if (ModelState.IsValid)
			{
				var clientForSave = AutoMapper.Mapper.Map<Product>(product);

				_repository.Insert(clientForSave);
				_repository.Save();

				return Json(new { result = true });
			}

			return Json(new { result = false, message = "Не удалось добавить продукт" } );
		}

		//[Authorize(Roles = "Admin")]
		[HttpGet]
		public PartialViewResult Edit(int? id)
		{
			if (id != null)
			{
				var clienEditView = AutoMapper.Mapper.Map<Models.ProductEditView>(_repository.GetById(id));
				return PartialView(clienEditView);
			}
			return PartialView("~/Views/Shared/Error.cshtml");
		}

		//[Authorize(Roles = "Admin")]
		[HttpPost]
		public JsonResult Edit([Bind(Include = "Id,Name")] Models.ProductEditView client)
		{
			if (ModelState.IsValid)
			{
				var clientForUpdate = AutoMapper.Mapper.Map<Product>(client);

				_repository.Update(clientForUpdate);
				_repository.Save();

				return Json(new { result = true });
			}
			return Json(new { result = false });
		}

		//[Authorize(Roles = "Admin")]
		[HttpPost]
		public JsonResult Delete(int? id)
		{
			_repository.Delete(id);
			_repository.Save();
			return Json(new { result = true });
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				_context.Dispose();
			}

			base.Dispose(disposing);
		}
	}
}