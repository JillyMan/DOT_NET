using DAL.Abstractions;
using Entities;
using Entities.Abstractions;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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
		private SourceDataSale _headerFile;
		private IConcurrencyAccessFactory _concurrencyFactory;
		private IDictionary<Type, ReaderWriterLockSlim> _lockers;

		public FileSaleLoader(
			IDbContextFactory dbContextFactory, 
			IConcurrencyAccessFactory concurrencyFactory, 
			CancellationToken cancellationToken) : 
			base(dbContextFactory, cancellationToken)
		{
			_concurrencyFactory = concurrencyFactory;
			_lockers = new Dictionary<Type, ReaderWriterLockSlim>();
		}

		private void InitLockers()
		{
			_lockers = new Dictionary<Type, ReaderWriterLockSlim>();
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
				Date = Convert.ToDateTime(tokens[0]),
				Client = new Client { Name = tokens[1] },
				Product = new Product { Name = tokens[2] },
				Summa = int.Parse(tokens[3])
			};
		}

		protected override void LoadData(DbContext context, FormatLine data)
		{
			data.Client = LoadEntity(data.Client, x => x.Name.Equals(data.Client.Name), context);
			data.Product = LoadEntity(data.Product, x => x.Name.Equals(data.Product.Name), context);

			Sale sale = new Sale
			{
				Client = data.Client,
				Date = data.Date,
				Product = data.Product,
				Summa = data.Summa,
				SourceData = _headerFile
			};

			LoadEntity(sale, null, context);
		}

		private Entity LoadEntity<Entity>(Entity entity, Expression<Func<Entity, bool>> searchExpression, DbContext context) where Entity : class
		{
			var loader = _concurrencyFactory.GetInstance<Entity>(context, _lockers[typeof(Entity)]);
			var saveEntity = loader.TryGet(searchExpression);

			if(saveEntity == null)
			{
				loader.Load(entity);
				saveEntity = entity;
			}

			return saveEntity;			
		}

		protected override void LoadHeader(DbContext context, string fileName)
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

			_headerFile = new SourceDataSale
			{
				Manager = new Manager { Name = parts[0] },
				DateCreateFile = Convert.ToDateTime(parts[1])
			};

			_headerFile.Manager = LoadEntity(_headerFile.Manager, x => x.Name.Equals(_headerFile.Manager.Name), context);
		}
	}
}
