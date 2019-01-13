using AutoMapper;
using BL.Services;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using WebStatisticSales.Models;

namespace WebStatisticSales.Controllers
{
    public class SellersController : Controller
    {
		private SellerService sellerService = new SellerService();
		
		public SellersController()
		{
		}

		public ActionResult Index()
		{
			return View();
		}

		[HttpGet]
		public PartialViewResult Load()
		{
			var clientsView = AutoMapper.Mapper.Map<IEnumerable<Seller>,
				List<SellerIndexView>>(sellerService.Get());

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
		public JsonResult Create([Bind(Include = "Name")] SellerCreateView seller)
		{
			if (ModelState.IsValid)
			{
				var sellerForSave = Mapper.Map<Seller>(seller);
				try
				{
					sellerService.AddSeller(sellerForSave);
					return Json(new { result = true });
				}
				catch (Exception e)
				{
					return Json(new { result = false, message = e.Message });
				}
			}
			return Json(new { result = false, message = "Models is invalid" });
		}

		[Authorize(Roles = "Admin")]
		[HttpGet]
		public PartialViewResult Edit(int id)
		{		
			try
			{
				var clienEditView = Mapper.Map<SellerEditView>(sellerService.GetById(id));
				return PartialView(clienEditView);
			}
			catch (Exception e)
			{
				return PartialView("~/Views/Shared/Error.cshtml");
			}
		}

		[Authorize(Roles = "Admin")]
		[HttpPost]
		public JsonResult Edit([Bind(Include = "Id,Name")] SellerEditView seller)
		{
			if (ModelState.IsValid)
			{
				var sellerForUpdate = AutoMapper.Mapper.Map<Seller>(seller);
				try
				{
					sellerService.EditSeller(sellerForUpdate);
					return Json(new { result = true });
				}
				catch (Exception e)
				{
					return Json(new { result = false, message = e.Message });
				}
			}
			return Json(new { result = false, message="Model is invlid" });
		}

		[Authorize(Roles = "Admin")]
		[HttpPost]
		public JsonResult Delete(int id)
		{
			try
			{
				sellerService.Delete(id);
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
				sellerService.Dispose();
			}

			base.Dispose(disposing);
		}
	}
}