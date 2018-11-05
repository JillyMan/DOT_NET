using System;
using System.Collections.Generic;
using System.Linq;
using ShopShoes.Complect;
using ShopShoes.Core.Shoes;
using ShopShoes.Core.Shoes.Types;

namespace ShopShoes.Builder.Woman
{
	public class WomanComplectBuilder : AbstractComplectBuilder
	{
		private readonly IList<ShoesSeasonType> _seasons = new List<ShoesSeasonType>()
		{
			ShoesSeasonType.Summer,
			ShoesSeasonType.Winter,
			ShoesSeasonType.Autumn,
			ShoesSeasonType.Winter,
		};

		protected override void FilterShoesByPerson(ref List<Shoes> shoes)
		{
			shoes.RemoveAll(x => x.PersonType != ShoesPersonType.Woman);
		}

		protected override void FilterShoesBySeason(ref List<Shoes> shoes)
		{
			var list = shoes.Where(x => _seasons.Contains(x.SeasonType))
							.GroupBy(x => x.SeasonType)
							.Select(x => x.First())
							.ToList();

			if (list.Count < _seasons.Count)
			{
				var missedSeasons = _seasons.Except(list.Select(x => x.SeasonType));
				throw new Exception($"not enough shoes for all seasons. missed - { string.Join(",", missedSeasons.Select(x => Enum.GetName(typeof(ShoesSeasonType), x)))}");
			}

			shoes = list;
		}

		protected override void InitComplect()
		{
			ShoesComplect = new PersonShoesComplect(ShoesPersonType.Woman);
		}
	}
}
