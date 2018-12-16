using System;
using System.Configuration;

namespace ConsoleClient
{
	class Program
	{
		static void Main(string[] args)
		{
			string listenFolder = ConfigurationManager.AppSettings["ListenFolder"];
			string porcessingFolder = ConfigurationManager.AppSettings["ProcessingFolder"];
			string porcessedFolder = ConfigurationManager.AppSettings["ProcessedForlder"];

			Console.WriteLine(listenFolder);
			Console.WriteLine(porcessingFolder);
			Console.WriteLine(porcessedFolder);

			//BL.DispatcherFolder dispatcher = new BL.DispatcherFolder(listenFolder);
		}
	}
}
