using System;
using System.Collections.Generic;
using ShopShoes.Complect;
using ShopShoes.Core.Shoes;

namespace ShopShoes.Builder
{
	public abstract class AbstractComplectBuilder : IShoesComplectBuilder
	{
		protected ShoesComplect ShoesComplect { get; set; }

		public AbstractComplectBuilder()
		{
			InitComplect();
		}

		protected abstract void InitComplect();
		protected abstract void FilterShoesBySeason(ref List<Shoes> shoes);
		protected abstract void FilterShoesByPerson(ref List<Shoes> shoes);

		public ShoesComplect Make(List<Shoes> shoes)
		{
			InitComplect();

			FilterShoesByPerson(ref shoes);
			FilterShoesBySeason(ref shoes);

			foreach (var shoe in shoes)
			{
				ShoesComplect.Add(shoe);
			}

			return ShoesComplect; 
		}
	}
}
