using System.Collections.Generic;
using System.Linq;
using ShopShoes.Core.Shoes;

namespace ShopShoes.Complect
{
	public class ShoesComplect
	{
		public IList<Shoes> Shoes { get; }

		public ShoesComplect()
		{
			Shoes = new List<Shoes>();
		}

		public int GetFullPrice()
		{
			return Shoes.Sum(x => x.Price);
		}

		public void Add(Shoes shoes)
		{
			Shoes.Add(shoes);
		}
	}
}
