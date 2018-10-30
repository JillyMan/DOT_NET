using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopShoes.Core.Model.Shoes.Season.Summer
{
	public class Sandals : AbstractShoes, ISummerShoes
	{
		public Sandals(int size, int price, TypeMaterial material, TypeShoes type) : 
			base(size, price, material, type)
		{
		}
	}
}
