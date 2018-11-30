using Core.Billing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.BillingSystem.TariffPlan
{
	public class BusinessTarifPlan : ITariffPlan
	{
		public int GetPrice(int duration)
		{
			return duration*2;
		}
	}
}
