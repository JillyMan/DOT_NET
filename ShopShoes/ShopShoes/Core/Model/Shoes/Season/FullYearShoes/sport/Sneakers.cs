using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopShoes.Core.Model.Shoes.Season.FullYearShoes.sport
{
	public class Sneakers : AbstractShoes, IFullYearShoes
	{
		public Sneakers(int size, int price, string brand, TypeColor color, TypeMaterial material, TypeShoes type) :
			base(size, price, brand, color, material, type)
		{
		}
	}
}
