using System;

namespace DAL.Models
{
	public class Sale
	{
		public int Id { get; set; }

		public int? SellerId { get; set; }
		public Seller Seller { get; set; }

		public int? ClientId { get; set; }
		public Client Client { get; set; }

		public int? ProductId { get; set; }
		public Product Product { get; set; }

		public DateTime Date { get; set; }
		public int Summa { get; set; }
	}
}
