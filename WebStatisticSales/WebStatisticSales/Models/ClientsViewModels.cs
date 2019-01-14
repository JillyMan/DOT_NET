using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace WebStatisticSales.Models
{
	public class ClientIndexView
	{
		[Display(Name="Ид")]
		public int Id { get; set; }

		[Display(Name="Имя")]
		public string Name { get; set; }
	}

	public class ClientCreateView
	{
		[Required]
		[StringLength(50, MinimumLength = 3, ErrorMessage = "Длина строки от 3 до 50")]
		[Display(Name = "Имя")]
		public string Name { get; set; }
	}

	public class ClientEditView
	{
		[Required]
		[HiddenInput(DisplayValue = false)]
		public int Id { get; set; }

		[Required]
		[StringLength(50, MinimumLength = 3, ErrorMessage = "Длина строки от 3 до 50")]
		[Display(Name = "Имя")]
		public string Name { get; set; }
	}
}