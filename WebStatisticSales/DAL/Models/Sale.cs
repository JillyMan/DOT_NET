using System;

namespace DAL.Models
{
	public class Sale
	{
		public int Id { get; set; }

		public int? SellerId { get; set; }
		public virtual Seller Seller { get; set; }

		public int? ClientId { get; set; }
		public virtual Client Client { get; set; }

		public int? ProductId { get; set; }
		public virtual Product Product { get; set; }

		public DateTime Date { get; set; }
		public int Cost { get; set; }
	}
}
