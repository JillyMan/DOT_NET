using BL.Services;
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
		private ProductService productService = new ProductService();

		public ProductController()
		{
		}

		public ActionResult Index()
		{
			return View();
		}

		[HttpGet]
		public PartialViewResult Load()
		{
			var clientsView = AutoMapper.Mapper.Map<IEnumerable<Product>,
				List<Models.ProductIndexView>>(productService.Get());

			return PartialView(clientsView);
		}

		[Authorize(Roles = "Admin")]
		[HttpGet]
		public PartialViewResult Create()
		{
			return PartialView();
		}

		[Authorize(Roles = "Admin")]
		[HttpPost]
		public JsonResult Create([Bind(Include = "Name")] Models.ProductCreateView product)
		{
			if (ModelState.IsValid)
			{
				var clientForSave = AutoMapper.Mapper.Map<Product>(product);

				try
				{
					productService.AddProduct(clientForSave);
				}
				catch(Exception e)
				{
					return Json(new { result = false, message = e.Message });
				}

				return Json(new { result = true });
			}
			return Json(new { result = false, message = "Model is invalid" } );
		}

		[Authorize(Roles = "Admin")]
		[HttpGet]
		public PartialViewResult Edit(int? id)
		{
			if (id != null)
			{
				var clienEditView = AutoMapper.Mapper.Map<Models.ProductEditView>(productService.GetById(id.Value));
				return PartialView(clienEditView);
			}
			return PartialView("~/Views/Shared/Error.cshtml");
		}

		[Authorize(Roles = "Admin")]
		[HttpPost]
		public JsonResult Edit([Bind(Include = "Id,Name")] Models.ProductEditView client)
		{
			if (ModelState.IsValid)
			{
				var clientForUpdate = AutoMapper.Mapper.Map<Product>(client);

				try
				{
					productService.EditProduct(clientForUpdate);
					return Json(new { result = true });
				}
				catch (Exception e)
				{
					return Json(new { result = true, message=e.Message });
				}
			}
			return Json(new { result = false });
		}

		[Authorize(Roles = "Admin")]
		[HttpPost]
		public JsonResult Delete(int? id)
		{
			try
			{
				productService.Delete(id.Value);
				return Json(new { result = true });
			}
			catch (Exception e)
			{
				return Json(new { result = false, message=e.Message });
			}
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				productService.Dispose();
			}

			base.Dispose(disposing);
		}
	}
}