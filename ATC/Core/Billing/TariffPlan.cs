using System;

namespace Core.Billing
{
	public interface TariffPlan
	{
		int GetPrice(DateTime time);
	}
}
