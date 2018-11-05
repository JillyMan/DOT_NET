using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopShoes.Core.Shoes.Types;

namespace ShopShoes.Complect
{
	public class PersonSeasonedShoesComplect : ShoesComplect, IPersonShoesComplect, ISeasonShoesComplect
	{
		public ShoesSeasonType SeasonType { get; }
		public ShoesPersonType PersonType { get; }

		public PersonSeasonedShoesComplect(ShoesSeasonType seasonType, ShoesPersonType personType)
		{
			SeasonType = seasonType;
			PersonType = personType;
		}
	}
}
