using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.BillingSystem
{
	public class OutgoingСall : AbstractCall
	{
		public int Price { get; }
		public OutgoingСall(Abonent sender, Abonent receiver, int duration, DateTime date, int price) : 
			base(sender, receiver, duration, date, TypeCall.OutgoingСall)
		{
			Price = price;
		}

		public override string ToString()
		{
			return base.ToString() + " Price: " + Price;
		}
	}
}