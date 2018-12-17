#define DEBUG_MODE
using Entities.Abstractions;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace BL.Loader
{
	public abstract class AbstractLoadFile<FormatHeader, FormatLine> 
		where FormatLine : class 
		where FormatHeader : class
	{
		IDbContextFactory _factoryContext;
		private CancellationToken _cancellationToken;

		public AbstractLoadFile(IDbContextFactory factoryContext, CancellationToken cancellationToken)
		{
			_factoryContext = factoryContext;
			_cancellationToken = cancellationToken;
		}

		public Task<bool> LoadFile(string filePath)
		{
			if (string.IsNullOrEmpty(filePath))
			{
				throw new ArgumentNullException("Invalid argument");
			}

			if (!File.Exists(filePath))
			{
				throw new Exception("File not exist!" + filePath);
			}

			return Task<bool>.Factory.StartNew(() =>
			{
#if DEBUG_MODE
				Logger.Logger.Log(" Begin load : " + filePath);
#endif
				using (var context = _factoryContext.GetContext())
				{
					using(var transaction = context.Database.BeginTransaction())
					{
						try
						{
							Logger.Logger.Log("Begin read");
							LoadHeader(context, filePath);
							foreach (var line in GetLine(filePath))
							{
								FormatLine formatLine = ParseLine(line);
								Logger.Logger.Log("\tread line");
								LoadData(context, formatLine);								
								_cancellationToken.ThrowIfCancellationRequested();								
							}
							transaction.Commit();
						}
						catch (Exception e)
						{
							transaction.Rollback();
							//Console.WriteLine("---------ROLLBACK!!");
							Logger.Logger.Log("Processing: " + filePath + " interupted from ", this.GetType(), e);
							throw e;
						}
					}
				}

				Logger.Logger.Log(" Load successfully");
				return true;
			});
		}

		private IEnumerable<string[]> GetLine(string filePath)
		{
			using (var reader = new StreamReader(filePath))
			{
				var lines = Csv.CsvReader.Read(reader);
				foreach(var line in lines)
				{
					string[] valuesLine = new string[line.ColumnCount];
					for (int i = 0; i < valuesLine.Length; ++i)
					{
						valuesLine[i] = line[i];
					}
					yield return valuesLine;
				}
			}
		}

		protected abstract void LoadData(DbContext context, FormatLine line);
		protected abstract FormatLine ParseLine(string[] line);
		protected abstract void LoadHeader(DbContext contxt, string fileName);
	}
}