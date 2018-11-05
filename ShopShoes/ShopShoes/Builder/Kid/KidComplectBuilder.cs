using System.Collections.Generic;
using ShopShoes.Complect;
using ShopShoes.Core.Shoes;
using ShopShoes.Core.Shoes.Types;
using System.Linq;
using ShopShoes.Core.Shoes.Util;

namespace ShopShoes.Builder.Kid
{
	public class KidSummerComplectBuilder : AbstractComplectBuilder
	{
		protected override void FilterShoesByPerson(ref List<Shoes> shoes)
		{
			shoes.RemoveAll(x => x.PersonType != ShoesPersonType.Kid);
		}

		protected override void FilterShoesBySeason(ref List<Shoes> shoes)
		{
			shoes.RemoveAll(x => x.SeasonType != ShoesSeasonType.Summer);
		}

		protected override void InitComplect()
		{
			ShoesComplect = new PersonSeasonedShoesComplect(ShoesSeasonType.Summer, ShoesPersonType.Kid);
		}
	}
}
