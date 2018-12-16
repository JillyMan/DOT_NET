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
				Console.WriteLine(Thread.CurrentThread.Name + "  Wait 10000ms");
				Thread.Sleep(10000);
				Console.WriteLine(Thread.CurrentThread.Name + " Begin work");

				using (var context = _factoryContext.GetContext())
				{
					using(var transaction = context.Database.BeginTransaction())
					{
						try
						{
							LoadHeader(context, filePath);
							foreach (var line in GetLine(filePath))
							{
								FormatLine formatLine = ParseLine(line);
								LoadData(context, formatLine);
								
								try
								{
									_cancellationToken.ThrowIfCancellationRequested();
								}
								catch (OperationCanceledException cancelException)
								{
									Console.WriteLine("Processing: " + filePath + " interupted from CancelationToken: \n" + cancelException.Message);
									return false;
								}
							}
							transaction.Commit();
						}
						catch (Exception e)
						{
							transaction.Rollback();
							Console.WriteLine(e.Message);
							return false;
						}
					}
				}
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