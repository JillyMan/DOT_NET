using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SalesService
{
	partial class SalesService : ServiceBase
	{
		public SalesService()
		{
			InitializeComponent();
		}

		protected override void OnStart(string[] args)
		{
			
			new Thread(() =>
			{
//				App.Start();
			}).Start();

		}

		protected override void OnStop()
		{

			new Thread(() =>
			{
//				App.Stop();
			}).Start();	

		}
	}
}