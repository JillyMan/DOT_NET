using System;
using Model;
using Model.ATC;
using Model.BillingSystem;
using Model.BillingSystem.TariffPlan;

namespace Sandbox
{
	class Program
	{
		//Terminal in operator hard code??
		static void Main(string[] args)
		{
			Billing billing = new Billing(new BusinessTarifPlan());
			Operator @operator = new Operator();
			Station station = new Station(3);

			@operator.RegisterInBilling += billing.RegisterUser;
			@operator.AddTerminal += station.AddTerminal;
			station.CallCompleted += billing.EndOfCall;
			station.GetAbonentByNumber += @operator.GetAbonentByNumber;

			Abonent a1 = new Abonent("Mike", "Jordan");
			Abonent a2 = new Abonent("Bill", "Jonson");
			Abonent a3 = new Abonent("Mike", "Vazowski");

			Terminal t1 = @operator.RegisterAbonent(a1, 1200);
			Terminal t2 = @operator.RegisterAbonent(a2, 1300);
			Terminal t3 = @operator.RegisterAbonent(a3, 200);

			t1.Call(t2.Number);
			t2.Answer();
			t2.Reject();

			t1.Call(t3.Number);
			t3.Answer();
			t1.Reject();

			t2.Call(t3.Number);
			t3.Answer();
			t3.Reject();

			var reports = billing.GetReports(a1);
			Console.WriteLine(a1 + " : ");
			Console.WriteLine("Ballance: " + billing.GetBallance(a1));
			foreach (var r in reports)
			{
				Console.WriteLine(r);
			}

			var reports2 = billing.GetReports(a2);
			Console.WriteLine(a2 + " : ");
			Console.WriteLine("Ballance: " + billing.GetBallance(a2));
			foreach (var r in reports2)
			{
				Console.WriteLine(r);
			}
		}
	}
}