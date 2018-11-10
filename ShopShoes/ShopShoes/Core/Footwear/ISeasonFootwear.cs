using ShopShoes.Core.Footwear.Types;

namespace ShopShoes.Core.Footwear
{
	public interface ISeasonFootwear
	{
		FootwearTypeSeason SeasonType { get; }
	}
}