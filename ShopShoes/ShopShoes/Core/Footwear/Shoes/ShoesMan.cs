using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopShoes.Core.Footwear.Types;

namespace ShopShoes.Core.Footwear.Shoes
{
	public class ShoesMan : AbstractFootwearLeather
	{
		public ShoesMan(uint size, FootwearTypeSeason typeSeason) : 
			base(size, FootwearTypePerson.Man, typeSeason)
		{
		}
	}
}
