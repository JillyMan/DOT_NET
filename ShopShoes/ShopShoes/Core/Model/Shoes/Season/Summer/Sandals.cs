using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopShoes.Core.Model.Shoes.Season.Summer
{
	public class Sandals : AbstractShoes, IShoesSummer
	{
		public Sandals(int size, int price, string brand, TypeColor color, TypeMaterial material, TypeShoes type) :
			base(size, price, brand, color, material, type)
		{
		}
	}
}
