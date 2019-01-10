using DAL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebStatisticSales.Models
{
	public class PageInfo
	{
		public int PageNumber { get; set; }
		public int PageSize { get; set; }
		public int TotalItems { get; set; }
		public int TotalPage
		{
			get
			{
				if(TotalPage == 0)
				{
					return 0;
				}
				return (int)Math.Ceiling((decimal)TotalItems / TotalPage);
			}
		}
	}

	public class PageIndexViewModel
	{
		public PageInfo PageInfo { get; set; }
		public IEnumerable<SaleView> Sales { get; set; }
	}

	public class SaleView
	{
		[HiddenInput(DisplayValue = false)]
		public int Id { get; set; }

		[Display(Name = "Продавец")]
		public string Seller { get; set; }

		[Display(Name = "Клиeнт")]
		public string Client { get; set; }

		[Display(Name = "Название продукта")]
		public string Product { get; set; }

		[Display(Name = "Стоимость")]
		public int Cost { get; set; }

		[Display(Name = "Дата продажи")]
		[DataType(DataType.Date)]
		//[DisplayFormat(DataFormatString = "{mm/dd/yyyy}")]
		public DateTime Date { get; set; }
	}

	public class SaleIndexView
	{
		public IEnumerable<SaleView> SaleView { get; set; }
		public SaleFileterView Filter { get; set; }
	}


	public class SaleFileterView
	{
		[Required]
		[Display(Name = "Клиеты")]
		public SelectList Clients { get; set; }

		[Required]
		[Display(Name = "Продавец")]
		public SelectList Sellers { get; set; }

		[Required]
		[Display(Name = "Продукт")]
		public SelectList Products { get; set; }
	}



	public class SaleCreateView
	{
		[Display(Name = "Продавец")]
		[Required(ErrorMessage = "Выберите продовца")]
		public int SellerId { get; set; }

		[Display(Name = "Клиeнт")]
		[Required(ErrorMessage = "Выберите покупателя")]
		public int ClientId { get; set; }

		[Required(ErrorMessage = "Продукт")]
		[Display(Name = "Название продукта")]
		public int ProductId { get; set; }

		[Required]
		[Display(Name = "Стоимость")]
		[Range(1, int.MaxValue, ErrorMessage = "Недопустимая цена")]
		public int Cost { get; set; }

		[Required]
		[DataType(DataType.Date)]
		[Display(Name = "Дата продажи")]
		public DateTime Date { get; set; }
	}


	public class SaleEditView
	{
		[HiddenInput(DisplayValue = false)]
		public int Id { get; set; }

		[Display(Name = "Продавец")]
		[Required(ErrorMessage = "Выберите продовца")]
		public int SellerId { get; set; }

		[Display(Name = "Клиeнт")]
		[Required(ErrorMessage = "Выберите покупателя")]
		public int ClientId { get; set; }

		[Required(ErrorMessage = "Продукт")]
		[Display(Name = "Название продукта")]
		public int ProductId { get; set; }

		[Required]
		[Display(Name = "Стоимость")]
		[Range(1, int.MaxValue, ErrorMessage = "Недопустимая цена")]
		public int Cost { get; set; }

		[Required]
		[DataType(DataType.Date)]
		[Display(Name = "Дата продажи")]
		public DateTime Date { get; set; }
	}
}