using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.BillingSystem.Report
{
	public class ReportByCall
	{
		public Abonent Receiver { get; }
		public int Duration { get; }
		public int Price { get; }

		public ReportByCall(Abonent receiver, int duration, int price)
		{
			Receiver = receiver;
			Duration = duration;
			Price = price;
		}

		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder();

			stringBuilder.Append("Call -> ");
			stringBuilder.Append(Receiver.FirstName);
			stringBuilder.Append(" ");
			stringBuilder.Append(Receiver.LastName);
			stringBuilder.Append(" Duration(min): ");
			stringBuilder.Append(Duration);
			stringBuilder.Append(" Cost: ");
			stringBuilder.Append(Price);

			return stringBuilder.ToString();
		}

	}
}
