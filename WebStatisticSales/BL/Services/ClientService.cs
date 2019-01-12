using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using DAL.Models;
using DAL.Abstractions;
using BL.Abstractions;
using DAL;

namespace BL.Services
{
	public class ClientService : IClientService
	{
		private IUnitOfWork _database;
		private IGenericRepository<Client> _repos;
		public bool disposed = false;

		public ClientService(IUnitOfWork db)
		{
			_database = db;
			_repos = _database.GetRepository<Client>();
		}

		public ClientService() : this(new UnitOfWork())
		{ }

		public IEnumerable<Client> Get(Expression<Func<Client, bool>> filter = null)
		{
			return _repos.Get(filter);
		}

		public bool AddClient(Client сlient)
		{
			if (сlient != null)
			{
				TryValidateMode(сlient);
				_repos.Insert(сlient);
				_database.Save();
			}
			return true;
		}

		public bool EditClient(Client client)
		{
			if (client == null)
			{
				throw new ArgumentNullException("Client is null");
			}

			TryValidateMode(client);

			var oldClient = _repos.GetById(client.Id);
			if (oldClient != null)
			{
				oldClient.Name = client.Name;
				_repos.Update(oldClient);
				_database.Save();
			}
			return true;
		}

		public void Delete(int id)
		{
			_repos.Delete(id);
			_database.Save();
		}

		public Client GetById(int id)
		{
			return _repos.GetById(id);
		}

		private void TryValidateMode(Client client)
		{
			if (string.IsNullOrEmpty(client.Name) &&
				(client.Name.Length > 0 && client.Name.Length < 100))
			{
				throw new ArgumentOutOfRangeException("Name length out of range");
			}
		}

		private void Dispose(bool dispose)
		{
			if (!disposed)
			{
				if (dispose)
				{
					_database.Save();
					disposed = true;
				}
			}
		}

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(true);
		}
	}
}