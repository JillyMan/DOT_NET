using Core.Billing;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Model.BillingSystem
{
	public class Billing
	{
		public class AbonentInfo
		{
			public Abonent Abonent { get; }
			public int Ballance { get; set; }

			public AbonentInfo(Abonent abonent, int ballance)
			{
				Abonent = abonent;
				Ballance = ballance;
			}
		}

		public ISet<AbonentInfo> Abonents { get; }

		public IList<OutgoingСall> outgoingСalls;
	
		private ITariffPlan TariffPlan { get; }

		public Billing(ITariffPlan tariffPlan)
		{
			TariffPlan = tariffPlan;
			outgoingСalls = new List<OutgoingСall>();
			Abonents = new HashSet<AbonentInfo>();
		}

		public void RegisterUser(Abonent a, int startBallance)
		{
			if(a == null && startBallance < 0)
			{
				throw new ArgumentException("Abonent null, startBallnce < 0");
			}
			Abonents.Add(new AbonentInfo(a, startBallance));
		}

		private void WriteOffMoney(Abonent abonent, int cost)
		{
			if(abonent == null || cost < 0)
			{
				throw new ArgumentNullException("Abonent is null, cost < 0");
			}

			var a = Abonents.FirstOrDefault(x => x.Abonent.Equals(abonent));
			a.Ballance -= cost;
		}

		public void EndOfCall(Abonent a1, Abonent a2, int duration)
		{
			if (a1 == null || a2 == null || duration < 0)
			{
				throw new ArgumentException();
			}

			int priceCall = TariffPlan.GetPrice(duration);
			WriteOffMoney(a1, priceCall);
			outgoingСalls.Add(new OutgoingСall(a1, a2, duration, DateTime.Now, TariffPlan.GetPrice(duration)));
		}
	}
}
