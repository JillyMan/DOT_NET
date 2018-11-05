using ShopShoes.Core.Shoes.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopShoes.Core.Shoes.Util
{
	public static class ShoesUtil
	{
		public static IEnumerable<Shoes> SortByPrice(this IEnumerable<Shoes> shoes)
		{
			return from s in shoes
				   orderby s.Price
				   select s;
		}

		public static IEnumerable<Shoes> SortByMaterial(this IEnumerable<Shoes> shoes)
		{
			return from s in shoes
				   orderby s.TypeMaterial
				   select s;
		}

		public static IEnumerable<Shoes> FindBySize(this IEnumerable<Shoes> shoes, int size)
		{
			return from s in shoes
				   where s.Size == size
				   select s;
		}

		public static IEnumerable<Shoes> FindByMaterial(this IEnumerable<Shoes> shoes, ShoesTypeMaterial typeMaterial)
		{
			return from s in shoes
				   where s.TypeMaterial == typeMaterial
				   select s;
		}
	}
}
