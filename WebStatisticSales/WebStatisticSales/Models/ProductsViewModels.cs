using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebStatisticSales.Models
{
	public class ProductIndexView
	{
		[Display(Name = "Ид")]
		public int Id { get; set; }

		[Display(Name = "Название продукта")]
		public string Name { get; set; }
	}

	public class ProductCreateView
	{
		[Required]
		[StringLength(50, MinimumLength = 3, ErrorMessage = "Длина строки от 3 до 50")]
		[Display(Name = "Название продукта")]
		public string Name { get; set; }
	}

	public class ProductEditView
	{
		[Required]
		[HiddenInput(DisplayValue = false)]
		public int Id { get; set; }

		[Required]
		[StringLength(50, MinimumLength = 3, ErrorMessage = "Длина строки от 3 до 50")]
		[Display(Name = "Название продукта")]
		public string Name { get; set; }
	}
}