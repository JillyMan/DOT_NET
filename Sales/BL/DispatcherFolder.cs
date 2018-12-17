#define DEBUG_MODE
using BL.Loader;
using System;
using System.Configuration;
using System.IO;
using System.Threading;

namespace BL
{
	//Dispose and stop
	public class DispatcherFolder : IDisposable
    {
		private FileSystemWatcher _watcher;
		private FileSaleLoader _loader;
		private CancellationTokenSource _source;

		private bool disposed;

		private string _sourceFolder;
		private string _processingFolder;
		private string _processedFolder;
		private string _invalidFileFolder;

		public DispatcherFolder()
		{
			_sourceFolder = ConfigurationManager.AppSettings["SourceFolder"];
			_processingFolder = ConfigurationManager.AppSettings["ProcessingFolder"];
			_processedFolder = ConfigurationManager.AppSettings["ProcessedForlder"];
			_invalidFileFolder = ConfigurationManager.AppSettings["IvalidFileFolder"];
		}

		private void Init()
		{
			disposed = false;
			Logger.Logger.OtherLog += OtherLog;

			_source = new CancellationTokenSource();
			_loader = new FileSaleLoader(
				new Entities.Factory.SaleDbContextFactory(),
				new DAL.Factory.ConcurrencyAccessFactory(new DAL.Factory.RepositoryFactory()),
				_source.Token);

			_watcher = new FileSystemWatcher(_sourceFolder)
			{
				NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite
					| NotifyFilters.FileName | NotifyFilters.DirectoryName,
				Filter = "*.csv"
			};
			_watcher.Created += OnCreated;
			_watcher.EnableRaisingEvents = true;
		}

		public void Start()
		{
			Logger.Logger.Log("Star dispatcher");
			Init();
		}

		public void Stop()
		{
			Logger.Logger.Log("Stop dispatcher");
			Dispose(true);
		}

		private void OtherLog(string log)
		{
			Console.WriteLine(log);
		}

		private void OnCreated(object source, FileSystemEventArgs eventArgs)
		{
			try
			{
				Logger.Logger.Log("Create file: " + eventArgs.FullPath);
				string processingPath = _processingFolder + "\\" + eventArgs.Name;
				string processedPath = _processedFolder + "\\" + eventArgs.Name;
				
				Logger.Logger.Log("Move to: " + processingPath);
				File.Move(eventArgs.FullPath, processingPath);

				_loader.LoadFile(processingPath).ContinueWith((result) =>
				{
					if (result.Result)
					{
						Logger.Logger.Log("Move to: " + processedPath);
						File.Move(processingPath, processedPath);
					}
				});
			}
			catch (Exception e)
			{
				Logger.Logger.Log("", typeof(DispatcherFolder), e);
				throw e;
			}
		}

		public void Dispose(bool dispose)
		{
			if (!disposed)
			{
				if (dispose)
				{
					disposed = true;

					_watcher.EnableRaisingEvents = false;
					_watcher.Created -= OnCreated;
					_watcher.Dispose();

					_source.Cancel();
					_source.Dispose();

				}
			}
		}

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}
	}
}