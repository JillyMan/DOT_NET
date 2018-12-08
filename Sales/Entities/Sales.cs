using System;

namespace Entities
{
	public class Sales
	{
		public int Id { get; set; }
		public DateTime Date { get; set; }
		public Client Client { get; set; }
		public Product Product { get; set; }
		public int Summa { get; set; }

		public Sales() { }

		public Sales(int id, DateTime date, Client client, Product product, int summa)
		{
			Id = id;
			Date = date;
			Client = client;
			Product = product;
			Summa = summa;
		}
	}
}
