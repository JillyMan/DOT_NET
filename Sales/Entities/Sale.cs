using System;

namespace Entities
{
	public class Sale
	{
		public int Id { get; set; }
		//public (Manager Saller, DateTime dateSales) SaleInfo;
		public DateTime Date { get; set; }
		public Client Client { get; set; }
		public Product Product { get; set; }
		public int Summa { get; set; }

		public Sale() { }

		public override string ToString()
		{
			return $"Sale [ ID={Id}, Date={Date}, {Client}, {Product}, Cost={Summa} ]";
		}
	}
}
