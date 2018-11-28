using Core;
using Core.ATC;
using Model;
using Model.ATC;
using Model.ATC.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sandbox
{
	class Program
	{
		static void Main(string[] args)
		{

			Port port0 = new Port(1);
			Port port1 = new Port(2);
			Port port2 = new Port(3);

			Station station = new Station();
			BinderPortStation binderPortStation = new BinderPortStation();
			binderPortStation.Bind(station);
			binderPortStation.Bind(station, port0);
			binderPortStation.Bind(station, port1);
			binderPortStation.Bind(station, port2);

			IClient client0 = new Abonent("Smith", "John");
			IClient client1 = new Abonent("Bob", "Miles");
			IClient client2 = new Abonent("Jimmy", "Neytron");

			Terminal terminal0 = new Terminal("11-11", client0);
			Terminal terminal1 = new Terminal("22-22", client1);
			Terminal terminal2 = new Terminal("33-33", client2);

			port0.Status = PortStatus.Online;
			port0.Attach(terminal0);
			port0.Attach(terminal1);

			port1.Attach(terminal0);
			port1.Attach(terminal2);

			terminal0.Call("22-22");
			terminal0.Call("33-33");

			terminal1.Answer();
			terminal2.Answer();

			terminal0.Reject();
			terminal0.Reject();
		}
	}
}