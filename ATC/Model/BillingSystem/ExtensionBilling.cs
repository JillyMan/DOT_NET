using Model.BillingSystem.Report;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Model.BillingSystem
{
	public static class ExtensionBilling
	{
		
		public static IEnumerable<OutgoingСall> GetCallsByReceiver(this Billing billing, Abonent recv)
		{
			if(recv == null)
			{
				throw new ArgumentNullException();
			}

			return billing.outgoingСalls.Where(x => x.Receiver.Equals(recv));
		}

		public static IEnumerable<OutgoingСall> GetCallsByPrice(this Billing billing, int price)
		{
			if (price < 0)
			{
				throw new ArgumentException();
			}

			return billing.outgoingСalls.Where(x => x.Price.Equals(price));
		}

		public static IEnumerable<OutgoingСall> GetCallsByDate(this Billing billing, DateTime date)
		{
			if (date == null)
			{
				throw new ArgumentNullException();
			}

			return billing.outgoingСalls.Where(x => x.Date.Equals(date));
		}

		public static IEnumerable<ReportByCall> GetReports(this Billing billing, Abonent abonent)
		{
			if(abonent == null)
			{
				throw new ArgumentNullException();
			}

			return billing.outgoingСalls
				.Where(x => x.Sender.Equals(abonent))
				.Select(x => new ReportByCall(x.Receiver, x.Duration, x.Price));
		}

		public static int GetBallance(this Billing billing, Abonent abonent)
		{
			var info = billing.Abonents.FirstOrDefault(x => x.Abonent.Equals(abonent));
			if(info == null)
			{
				throw new Exception(abonent + " no register in billing system");
			}

			return info.Ballance;
		}
	}
}
