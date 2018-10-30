using ShopShoes.Core.Model.Shoes;
using System.Collections.Generic;
using System.Linq;

namespace ShopShoes.Complect
{
	public class ComplectShoes<T> : IComplectFullPrice 
		where T : IShoes
	{
		public IList<T> Shoes { get; private set; }
	
		public ComplectShoes(IList<T> container)
		{
			Shoes = container;
		}

		public void Add(T shoes)
		{
			if (shoes != null)
			{
				this.Shoes.Add(shoes);
			}
		}

		public void Clear()
		{
			if(Shoes != null)
			{
				Shoes.Clear();
			}
		}

		public bool Remove(T shoes)
		{
			if(shoes != null)
			{
				return this.Shoes.Remove(shoes);
			}
			return false;
		}

		public int FullPrice()
		{
			return Shoes.Sum(x => x.Price);
		}
	}
}
