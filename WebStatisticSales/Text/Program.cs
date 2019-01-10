using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text
{
	class Program
	{
		static void Main(string[] args)
		{
			DAL.GenericRepository<Client> rep = new DAL.GenericRepository<Client>(new DAL.Models.SalesDbContext());
			var kek = rep.Get();

			foreach(var lol in kek)
			{
				Console.WriteLine(lol);
			}

		}
	}
}
