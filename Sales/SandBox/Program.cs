using Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace SandBox
{
	public class Program
	{
		public static void Main(string[] args)
		{
			using (CancellationTokenSource source = new CancellationTokenSource())
			{
				var token = source.Token;
				Task.Factory.StartNew(() =>
				{
					for(int i = 0; ; ++i)
					{
						Thread.Sleep(100);
						Console.WriteLine(i * i);
						try
						{
							token.ThrowIfCancellationRequested();
						}
						catch(OperationCanceledException e)
						{
							Console.WriteLine("Cancel infitity cycle");
						}					
					}
				});
				Console.ReadKey();
				source.Cancel();
				Console.ReadKey();
				source.Cancel();
			}

		}

	}
}