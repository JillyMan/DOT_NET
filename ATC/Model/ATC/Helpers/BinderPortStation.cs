using Core.ATC;
using System;

namespace Model.ATC.Helpers
{
	public class BinderPortStation
	{
		public void Bind(IStation station)
		{
			Random rand = new Random();
			station.CallCompleted += (t1, t2) => Console.WriteLine($"{t1.Abonent} call with {t2.Abonent} -> {rand.Next(100)} min");
		}

		public void Bind(IStation station, IPort port)
		{
			if(station == null || port == null)
			{
				throw new System.ArgumentNullException();
			}

			port.CallAction += station.Call;
			port.AnswerAction += station.Answer;
			port.RejectAction += station.Reject;

			port.AttachTerminal += station.AddTerminal;
			port.UnhookTerminal += station.RemoveTerminal;
		}

		public void Bind(IStation station, IPort[] ports)
		{
			if (station == null || ports == null)
			{
				throw new System.ArgumentNullException();
			}

			for (int i = 0; i < ports.Length; ++i)
			{
				Bind(station, ports[i]);
			}
		}
	}
}
