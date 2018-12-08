using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Data.Entity;
using System.Runtime.InteropServices;

namespace SandBox.Test
{
	public class TestRepository
	{
		private static Random random = new Random();

		public void Run()
		{
			using (var dbContext = new Entities.SalesDbContext())
			{
				TestClient(dbContext);
			}
		}

		private void TestClient(Entities.SalesDbContext dbContext)
		{
			Console.WriteLine("\tStart test client repository");
			using (var repClient = new DAL.GenericRepository<Entities.Client>(dbContext))
			{
				var client = new Entities.Client { Name = $"TestReposClient {dbContext.Clients.Count()}" };
				TestInsert(repClient, client);
				TestGet(repClient);
				client.Name = $"Updated name client with id={client.Id}";
				TestUpdate(repClient, client);
				TestGet(repClient);
				TestDelete(repClient, client);
				TestGet(repClient);

				//TestDeleteById(repClient);

				TestGet(repClient);
				TestGetById(repClient);
			}
			Console.WriteLine("\t Finish test client repository");
		}

		private void TestGetById<T>(DAL.IGenericRepository<T> rep)
		{
			ChangeColor();
			int rand = random.Next(rep.Get().Count()) + 1;
			Console.WriteLine($"Test getById(id) id={rand}");
			ReturnColor();
			Console.WriteLine(rep.GetById(rand));
		}

		private void TestInsert<T>(DAL.IGenericRepository<T> rep, T entity)
		{
			ChangeColor();
			Console.WriteLine($"Insert {entity}");
			ReturnColor();
			rep.Insert(entity);
			rep.Save();
		}

		private void TestDelete<T>(DAL.IGenericRepository<T> rep, T entity)
		{
			ChangeColor();
			Console.WriteLine($"Delete {entity}");
			ReturnColor();
			rep.Delete(entity);
			rep.Save();
		}

		[Obsolete("Method can try remove row which in reletion to other row in other table")]
		private void TestDeleteById<T>(DAL.IGenericRepository<T> rep)
		{
			ChangeColor();
			int rand = random.Next(rep.Get().Count()) + 1;
			Console.WriteLine($"Test DeleteById(id) id={rand}");
			Console.WriteLine(rep.GetById(rand));
			rep.Delete(rand);
			rep.Save();
			ReturnColor();
		}

		private void TestGet<T>(DAL.IGenericRepository<T> rep)
		{
			ChangeColor();
			Console.WriteLine("Get all elements");
			ReturnColor();

			foreach(var entity in rep.Get())
			{
				Console.WriteLine(entity);
			}
		}

		private void TestUpdate<T>(DAL.IGenericRepository<T> rep, T entity)
		{
			ChangeColor();
			Console.WriteLine($"Update entity {entity}");
			ReturnColor();
			rep.Update(entity);
			rep.Save();
		}

		private void ChangeColor()
		{
			Console.BackgroundColor = ConsoleColor.Red;
		}

		private void ReturnColor()
		{
			Console.BackgroundColor = ConsoleColor.Black;
		}
	}
}