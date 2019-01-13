using AutoMapper;
using BL.Services;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using WebStatisticSales.Models;

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
			var clientsView = Mapper.Map<IEnumerable<Product>,
				List<ProductIndexView>>(productService.Get());

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
				var clientForSave = Mapper.Map<Product>(product);

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
		public PartialViewResult Edit(int id)
		{	
			if(id > 0)
			{
				try
				{
					var client = productService.GetById(id);
					if(client != null)
					{
						var clienEditView = Mapper.Map<ProductEditView>(client);
						return PartialView(clienEditView);
					}
				}
				catch(Exception e)
				{
					return PartialView("~/Views/Shared/Error.cshtml");
				}
			}
			return PartialView("~/Views/Shared/Error.cshtml");
		}

		[Authorize(Roles = "Admin")]
		[HttpPost]
		public JsonResult Edit([Bind(Include = "Id,Name")] Models.ProductEditView client)
		{
			if (ModelState.IsValid)
			{
				var clientForUpdate = Mapper.Map<Product>(client);

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
		public JsonResult Delete(int id)
		{
			try
			{
				productService.Delete(id);
				return Json(new { result = true });
			}
			catch (Exception e)
			{
				return Json(new { result = false });
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