using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace ServiceClient
{
	public partial class ServiceClient : ServiceBase
	{
		BL.DispatcherFolder dispatcher;
		public ServiceClient()
		{
			InitializeComponent();
		}

		protected override void OnStart(string[] args)
		{
			dispatcher = new BL.DispatcherFolder();
			dispatcher.Start();
		}

		protected override void OnStop()
		{
			if(dispatcher != null)
			{
				dispatcher.Stop();
			}
		}
	}
}
