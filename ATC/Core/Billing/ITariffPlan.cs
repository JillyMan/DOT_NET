using System;

namespace Core.Billing
{
	public interface ITariffPlan
	{
		int GetPrice(int time);
	}
}
