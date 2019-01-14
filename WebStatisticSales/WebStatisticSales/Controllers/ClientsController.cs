using AutoMapper;
using BL.Services;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace WebStatisticSales.Controllers
{
    public class ClientsController : Controller
	{
		private ClientService clientService = new ClientService();

		public ClientsController()
		{
		}

        public ActionResult Index()
        {
            return View();
        }

		[HttpGet]
		public PartialViewResult Load()
		{
			var clientsView = Mapper.Map<IEnumerable<Client>, 
				List<Models.ClientIndexView>>(clientService.Get());

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
		public JsonResult Create([Bind(Include = "Name")] Models.ClientCreateView client)
		{
			if (ModelState.IsValid)
			{
				var clientForSave = Mapper.Map<Client>(client);

				try
				{
					clientService.AddClient(clientForSave);				
					return Json(new { result = true });
				}
				catch(Exception e)
				{
					return Json(new { result = false, message="Server error, when try add client" });
				}

			}
			return Json(new { result = false, message="Invalid model" });
		}

		[Authorize(Roles = "Admin")]
		[HttpGet]
		public PartialViewResult Edit(int id)
		{
			if(id > 0)
			{
				try
				{
					var clienEditView = Mapper.Map<Models.ClientEditView>(clientService.GetById(id));
					return PartialView(clienEditView);
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
		public JsonResult Edit([Bind(Include = "Id,Name")] Models.ClientEditView client)
		{
			if (ModelState.IsValid)
			{
				var clientForUpdate = Mapper.Map<Client>(client);

				try
				{	
					clientService.EditClient(clientForUpdate);
					return Json(new { result = true });
				}
				catch (Exception e)
				{
					return Json(new { result = false, message = e.Message });
				}
			}
			return Json(new { result = false, model="Model is invalid"});
		}

		[Authorize(Roles = "Admin")]
		[HttpPost]
		public JsonResult Delete(int id)
		{
			try
			{
				clientService.Delete(id);
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
				clientService.Dispose();
			}

			base.Dispose(disposing);
		}
	}
}