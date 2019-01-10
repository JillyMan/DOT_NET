using System;

namespace DAL.Models
{
	public class Sale
	{
		public int Id { get; set; }
		public Manager Seller { get; set; }
		public DateTime Date { get; set; }
		public Client Client { get; set; }
		public Product Product { get; set; }
		public int Summa { get; set; }
	}
}
