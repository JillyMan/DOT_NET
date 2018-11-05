using ShopShoes.Complect;
using ShopShoes.Core.Shoes;
using System.Collections.Generic;

namespace ShopShoes.Builder
{
	public interface IShoesComplectBuilder
	{
		ShoesComplect Make(List<Shoes> shoes);
	}
}
