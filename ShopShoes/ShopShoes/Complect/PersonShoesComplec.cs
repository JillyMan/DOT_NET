using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopShoes.Core.Shoes.Types;

namespace ShopShoes.Complect
{
	public class PersonShoesComplect : ShoesComplect, IPersonShoesComplect
	{
		public ShoesPersonType PersonType { get; }

		public PersonShoesComplect(ShoesPersonType type)
		{
			PersonType = type;
		}
	}
}
