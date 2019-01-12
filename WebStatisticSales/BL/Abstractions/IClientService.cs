using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace BL.Abstractions
{
	public interface IClientService : IDisposable
	{
		IEnumerable<Client> Get(Expression<Func<Client, bool>> filter = null);
		bool AddClient(Client сlient);
		bool EditClient(Client client);
		void Delete(int id);

	}
}
