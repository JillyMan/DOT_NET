using System.ComponentModel.DataAnnotations;

namespace WebStatisticSales.Models
{
	public class ChartsViewModels
	{
		[Required]
		[Display(Name = "Продукт №1")]
		public int FirstProductId { get; set; }

		[Required]
		[Display(Name = "Продукт №2")]
		public int SecondProductId { get; set; }

		[Required]
		[Display(Name = "Продукт №3")]
		public int ThirdProductId { get; set; }

		[Range(1900, 2100)]
		[Display(Name = "Год №1")]
		[Required(ErrorMessage = "Введите год")]
		public int FirstYear { get; set; }

		[Range(1900, 2100)]
		[Display(Name = "Год №2")]
		[Required(ErrorMessage = "Введите год")]
		public int SecondYear2 { get; set; }
	}
}