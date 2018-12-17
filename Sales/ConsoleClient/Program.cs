using BL;
using System;
using System.Configuration;
using System.Globalization;
using System.IO;
using System.Linq;

namespace ConsoleCloient
{
	class Program
	{
		static void Main(string[] args)
		{
			using (DispatcherFolder dispatcher = new DispatcherFolder())
			{
				Console.WriteLine("Start... (Press any key for stop)");
				dispatcher.Start();
				Console.ReadKey();
				Console.WriteLine("Stop...");
			}
		}
	}
}