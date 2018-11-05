using ShopShoes.Core.Shoes.Types;

namespace ShopShoes.Complect
{
	public class SeasonedShoesComplect : ShoesComplect, ISeasonShoesComplect
	{
		public ShoesSeasonType SeasonType { get; }

		public SeasonedShoesComplect(ShoesSeasonType type)
		{
			SeasonType = type;
		}
	}
}
