using System;

namespace Entities
{
	public class Sale
	{
		public int Id { get; set; }
		public DateTime Date { get; set; }
		public Client Client { get; set; }
		public Product Product { get; set; }
		public int Summa { get; set; }

		public Sale() { }

		public Sale(int id, DateTime date, Client client, Product product, int summa)
		{
			Id = id;
			Date = date;
			Client = client;
			Product = product;
			Summa = summa;
		}
	}
}
