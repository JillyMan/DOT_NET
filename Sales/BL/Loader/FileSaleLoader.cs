using DAL.Abstractions;
using Entities;
using Entities.Abstractions;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Globalization;
using System.IO;
using System.Linq.Expressions;
using System.Threading;

namespace BL.Loader
{
	public class FormatLine
	{
		public DateTime Date { get; set; }
		public Client Client { get; set; }
		public Product Product { get; set; }
		public int Summa { get; set; }
	}

	public class FileSaleLoader : AbstractLoadFile<SourceDataSale, FormatLine>
	{
		private IConcurrencyAccessFactory _concurrencyFactory;
		private IDictionary<Type, ReaderWriterLockSlim> _lockers;

		public FileSaleLoader(
			IDbContextFactory dbContextFactory, 
			IConcurrencyAccessFactory concurrencyFactory, 
			CancellationToken cancellationToken) : 
			base(dbContextFactory, cancellationToken)
		{
			_concurrencyFactory = concurrencyFactory;
			InitLockers();
		}

		private void InitLockers()
		{
			_lockers = new Dictionary<Type, ReaderWriterLockSlim>();

			_lockers.Add(typeof(SourceDataSale), new ReaderWriterLockSlim());
			_lockers.Add(typeof(Client), new ReaderWriterLockSlim());
			_lockers.Add(typeof(Manager), new ReaderWriterLockSlim());
			_lockers.Add(typeof(Product), new ReaderWriterLockSlim());
			_lockers.Add(typeof(Sale), new ReaderWriterLockSlim());
		}

		protected override FormatLine ParseLine(string[] tokens)
		{
			if (tokens == null)
			{
				throw new ArgumentNullException("Inline line!");
			}
			if (tokens.Length != 4)
			{
				throw new FormatException("Line.lentgh not equals 4!");
			}

			return new FormatLine
			{
				Date = DateTime.ParseExact(tokens[0], 
								ConfigurationManager.AppSettings["DatePatterSale"], 
								CultureInfo.InvariantCulture),
				Client = new Client { Name = tokens[1] },
				Product = new Product { Name = tokens[2] },
				Summa = int.Parse(tokens[3])
			};
		}

		protected override void LoadData(DbContext context, SourceDataSale sourceData, FormatLine data)
		{
			data.Client = LoadEntity(data.Client, context, x => x.Name.Equals(data.Client.Name));
			data.Product = LoadEntity(data.Product, context, x => x.Name.Equals(data.Product.Name));

			Sale sale = new Sale
			{
				Client = data.Client,
				Date = data.Date,
				Product = data.Product,
				Summa = data.Summa,
				SourceData = sourceData
			};

			LoadEntity(sale, context);
		}

		private Entity LoadEntity<Entity>(Entity entity, DbContext context, Expression<Func<Entity, bool>> searchExpression = null) where Entity : class
		{
			var loader = _concurrencyFactory.GetInstance<Entity>(context, _lockers[typeof(Entity)]);
			var saveEntity = loader.TryGet(searchExpression);

			if(saveEntity == null)
			{
				loader.Load(entity, searchExpression);
				saveEntity = entity;
			}

			return saveEntity;			
		}

		protected override SourceDataSale LoadHeader(DbContext context, string fileName)
		{
			if (!File.Exists(fileName))
			{
				throw new FileNotFoundException(fileName + " not found");
			}

			string[] parts = Path.GetFileNameWithoutExtension(fileName).Split('_');

			if(parts.Length != 2)
			{
				throw new ArgumentException("Invalid file name need \'ManagerName_DDMMYYYY\'");
			}

			SourceDataSale header = new SourceDataSale
			{
				Manager = new Manager { Name = parts[0] },
				DateCreateFile = DateTime.ParseExact(parts[1], ConfigurationManager.AppSettings["DatePatterHeader"], CultureInfo.InvariantCulture)
			};

			header.Manager = LoadEntity(header.Manager, context, x => x.Name.Equals(header.Manager.Name));
			LoadEntity(header, context);
			return header;
		}
	}
}