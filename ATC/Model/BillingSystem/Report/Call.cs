using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.BillingSystem
{
	public abstract class AbstractCall
	{
		public enum TypeCall
		{
			OutgoingСall,
			IncomingCall,
		}

		public Abonent Sender;
		public Abonent Receiver;
		public int Duration { get; }
		public DateTime Date { get; }

		public TypeCall Type { get; }

		public AbstractCall(Abonent sender, Abonent receiver, int duration, 
			DateTime date, TypeCall type)
		{
			Sender = sender;
			Receiver = receiver;
			Duration = duration;
			Date = date;
			Type = type;
		}

		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append(Sender.FirstName);
			stringBuilder.Append(Sender.LastName);
			stringBuilder.Append(" -> ");
			stringBuilder.Append("Duration: ");
			stringBuilder.Append(Duration);
			stringBuilder.Append("Date: ");
			stringBuilder.Append(Date);

			return stringBuilder.ToString();
		}
	}
}
