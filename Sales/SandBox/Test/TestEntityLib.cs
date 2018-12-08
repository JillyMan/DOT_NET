using System;
using System.Linq;

namespace SandBox.Test
{
	public class TestEntityLib
	{
		public void Run()
		{
			using (var context = new Entities.SalesDbContext())
			{
				var client = new Entities.Client() { Name = $"TestNameClient {context.Clients.Count()}" };
				var product = new Entities.Product { Name = $"TestNameProduct {context.Products.Count()}" };
				var sales = new Entities.Sale { Date = DateTime.Now, Client = client, Product = product, Summa = context.Clients.Count() + context.Products.Count() };
				
				context.Clients.Add(client);
				context.Products.Add(product);
				context.Sales.Add(sales);
				context.SaveChanges();
			}

			using (var context = new Entities.SalesDbContext())
			{
				var client = context.Clients.OrderByDescending(x => x.Id).FirstOrDefault();
				var product = context.Products.OrderByDescending(x => x.Id).FirstOrDefault();
				var sale = context.Sales.OrderByDescending(x => x.Id).FirstOrDefault();

				Console.WriteLine("---------------Last record---------------");
				Console.WriteLine($"{client.Id}, {client.Name}");
				Console.WriteLine($"{product.Id}, {product.Name}");
				Console.WriteLine($"{sale.Id}, Client [ {sale.Client.Id}, {sale.Client.Name} ] Item [ {sale.Product.Id} , {sale.Product.Name}], {sale.Summa}");
				Console.WriteLine("-----------------------------------------");
			}
		}
	}
}
