using ShopShoes.Core.Model.Shoes;
using System.Collections.Generic;

namespace ShopShoes.Complect
{
	public class ComplectFamily<T> : IComplectFullPrice
		where T : IShoes
	{
		public ComplectShoes<T> ManComplect { get; private set; }
		public ComplectShoes<T> WomanComplect { get; private set; }
		public ComplectShoes<T> KidComplect { get; private set; }
	
		public ComplectFamily(IList<T> manContainer, IList<T> womanContainer, IList<T> kidContainer)
		{
			this.ManComplect = new ComplectShoes<T>(manContainer);
			this.WomanComplect = new ComplectShoes<T>(womanContainer);
			this.KidComplect = new ComplectShoes<T>(kidContainer);
		}

		public int FullPrice()
		{
			int result = 0;

			if (ManComplect != null)
			{
				result += ManComplect.FullPrice();
			}

			if (WomanComplect != null)
			{
				result += WomanComplect.FullPrice();
			}

			if (KidComplect != null)
			{
				result += KidComplect.FullPrice();
			}

			return result;
		}
		
		/*
		 * как-то не очень с проверками на тип!!!
		*/
		public void Add(T shoes)
		{
			if(shoes != null)
			{
				if(shoes.Type == Core.Model.TypeShoes.MAN)
				{
					ManComplect.Add(shoes);
				}
				else if (shoes.Type == Core.Model.TypeShoes.WOMAN)
				{
					WomanComplect.Add(shoes);
				}
				else if (shoes.Type == Core.Model.TypeShoes.KID)
				{
					KidComplect.Add(shoes);
				}
			}
		}

	}
}
