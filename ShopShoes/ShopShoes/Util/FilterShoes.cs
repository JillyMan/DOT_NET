using ShopShoes.Core.Model;
using ShopShoes.Core.Model.Shoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopShoes.Util
{
	public class FilterShoes
	{
		public IEnumerable<IShoes> FilterBySize(IList<IShoes> shoes, int min, int max)
		{
			return shoes.Where(x => x.Price >= min && x.Price <= max);
		}

		public IEnumerable<IShoes> FilterByMaterial(IList<IShoes> shoes, TypeMaterial material)
		{
			return shoes.Where(x => x.Material == material);
		}

		public IEnumerable<IShoes> FilterByType(IList<IShoes> shoes, TypeShoes type)
		{
			return shoes.Where(x => x.Type == type);
		}
	}
}
