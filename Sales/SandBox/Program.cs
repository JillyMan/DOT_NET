using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SandBox
{
	class Program
	{
		static void Main(string[] args)
		{
			new TestEntityLib().Run();
//			new Program().Run();
		}

		private void Run()
		{
			FillData();
		}

		private void FillData()
		{
			using (var context = new Entities.SalesDbContext())
			{
				FillClient(context);
			}
		}

		private void FillClient(DbContext dbContext)
		{
			using (var repClient = new DAL.GenericRepository<Entities.Client>(dbContext))
			{
				Entities.Client petya = new Entities.Client { Name = "Petya" };
				Entities.Client ivan = new Entities.Client { Name = "Ivan" };
				Entities.Client john = new Entities.Client { Name = "John" };

				repClient.Insert(petya);
				repClient.Insert(ivan);
				repClient.Insert(john);
				repClient.Save();
				PrintEntity(repClient);
			}
		}

		private void PrintEntity<T>(DAL.IGenericRepository<T> rep) where T : class
		{
			var entities = rep.Get();
			
			foreach(var entity in entities)
			{
				foreach(var property in entity.GetType().GetProperties())
				{
					Console.WriteLine(property.GetValue(entity, null));
				}
			}
		}
	}
}
