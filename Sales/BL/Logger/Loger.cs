using System;
using System.Configuration;

namespace BL.Logger
{
	public static class Logger
	{
		private static string path = ConfigurationManager.AppSettings["LogFile"];
		public static event Action<string> OtherLog;

		private static object syncObj = new object();
		public static void Log(string info, Type type = null, Exception e = null)
		{
			lock (syncObj)
			{
				if (!System.IO.File.Exists(path))
				{
					System.IO.File.Create(path).Dispose();
				}

				using (var sw = new System.IO.StreamWriter(path, true))
				{
					string stringToWrite = info + "\n";

					if(type != null)
					{
						stringToWrite += type.FullName;
					}
					if (e != null)
					{
						stringToWrite += e.ToString();
					}
					sw.WriteLine(stringToWrite);
					if(OtherLog != null)
					{
						OtherLog.Invoke(stringToWrite);
					}
				}
			}
		}
	}
}