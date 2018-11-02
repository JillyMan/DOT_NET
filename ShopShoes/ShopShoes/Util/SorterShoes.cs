using ShopShoes.Core.Model;
using ShopShoes.Core.Model.Shoes;
using System.Collections.Generic;
using System.Linq;

namespace ShopShoes.Util
{
	public class SorterShoes
	{
		public IEnumerable<IShoes> SortByPrice(IList<IShoes> list)
		{
			return list.OrderBy(x => x.Price);
		}

		public IEnumerable<IShoes> SortByMaterial(IList<IShoes> list)
		{
			return list.OrderBy(x => x.Material); ;
		}
	}
}