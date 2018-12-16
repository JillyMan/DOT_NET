#define CONSOLE_APP
using BL.Loader;
using System;
using System.IO;
using System.Threading;

namespace BL
{
	public class DispatcherFolder : IDisposable
    {
		private FileSystemWatcher _watcher;
		private FileSaleLoader _loader;
		private CancellationTokenSource _source;

		private bool disposed = false;

		private string _sourceFolder;
		private string _procesingFolder;
		private string _processedFolder;

		public DispatcherFolder(string sourceFolder, string processingFolder, string processedFolder)
		{
			_sourceFolder = sourceFolder;
			_procesingFolder = processingFolder;
			_processedFolder = processedFolder;

			_source = new CancellationTokenSource();
			_loader = new FileSaleLoader(
				new Entities.Factory.SaleDbContextFactory(),
				new DAL.Factory.ConcurrencyAccessFactory(new DAL.Factory.RepositoryFactory()),
				_source.Token);

			InitWatcher();
		}

		private void InitWatcher()
		{
			_watcher = new FileSystemWatcher(_sourceFolder)
			{
				NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite
								| NotifyFilters.FileName | NotifyFilters.DirectoryName,
				Filter = "*.csv"
			};
			_watcher.Created += OnCreatedAsync;
		}

		public void Start()
		{
			_watcher.EnableRaisingEvents = true;
		}

		public void Stop()
		{
			_source.Cancel();
			_watcher.EnableRaisingEvents = false;
		}

		private void OnCreatedAsync(object source, FileSystemEventArgs eventArgs)
		{
			try
			{
#if CONSOLE_APP
				Console.WriteLine("Created file: " + eventArgs.FullPath + " " + eventArgs.ChangeType);
#endif
				string processingPath = _procesingFolder + "\\" + eventArgs.Name;
				string processedPath = _processedFolder + "\\" + eventArgs.Name;
				
				File.Move(eventArgs.FullPath, processingPath);
#if CONSOLE_APP
				Console.WriteLine("Move file: " + eventArgs.FullPath);
#endif
				_loader.LoadFile(processedPath);
				File.Move(processingPath, processedPath);
#if CONSOLE_APP
				Console.WriteLine("Move file: " + eventArgs.FullPath);
#endif
			}
			catch (Exception e)
			{
				Console.WriteLine(e.StackTrace);
			}
		}

		public void Dispose(bool dispose)
		{
			if (!disposed)
			{
				if (dispose)
				{
					disposed = true;
					_watcher.Created -= OnCreatedAsync;
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