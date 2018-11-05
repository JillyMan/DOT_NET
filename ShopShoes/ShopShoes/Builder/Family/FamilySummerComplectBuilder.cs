using System;
using System.Collections.Generic;
using System.Linq;
using ShopShoes.Complect;
using ShopShoes.Core.Shoes;
using ShopShoes.Core.Shoes.Types;
using ShopShoes.Core.Shoes.Util;

namespace ShopShoes.Builder.Family
{
	public class FamilySummerComplectBuilder : AbstractComplectBuilder
	{
		private readonly List<ShoesPersonType> _persons = new List<ShoesPersonType>()
		{
			ShoesPersonType.Kid,
			ShoesPersonType.Woman,
			ShoesPersonType.Man
		};

		protected override void FilterShoesByPerson(ref List<Shoes> shoes)
		{
			var list = shoes.Where(x => _persons.Contains(x.PersonType))
							.GroupBy(x => x.PersonType)
							.Select(x => x.First())
							.ToList();

			if(list.Count < _persons.Count)
			{
				var missedPersons = _persons.Except(list.Select(x => x.PersonType));
				throw new Exception($"not enough shoes for all persosn in family. missed - {string.Join(",", missedPersons.Select(x => Enum.GetName(typeof(ShoesPersonType), x)))}");
			}
			shoes = list;
		}

		protected override void FilterShoesBySeason(ref List<Shoes> shoes)
		{
			shoes.RemoveAll(x => x.SeasonType != ShoesSeasonType.Summer);
		}

		protected override void InitComplect()
		{
			ShoesComplect = new SeasonedShoesComplect(ShoesSeasonType.Summer);
		}
	}
}
