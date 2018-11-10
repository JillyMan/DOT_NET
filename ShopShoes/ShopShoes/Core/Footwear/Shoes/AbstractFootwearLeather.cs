using ShopShoes.Core.Footwear.Types;

namespace ShopShoes.Core.Footwear
{
	public abstract class AbstractFootwearLeather : AbstractFootwear, ISeasonFootwear, IPersonFootwear//, IMaterialFootwear
	{
		public AbstractFootwearLeather(uint size, FootwearTypePerson typePerson, FootwearTypeSeason typeSeason) :
			base(size, "Shoes", FootwearTypeMaterial.Leather, typePerson, typeSeason)
		{
		}
	}
}