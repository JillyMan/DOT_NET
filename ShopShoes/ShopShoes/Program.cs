using ShopShoes.Builder;
using ShopShoes.Builder.Family;
using ShopShoes.Builder.Kid;
using ShopShoes.Builder.Woman;
using ShopShoes.Complect;
using ShopShoes.Core.Shoes;
using ShopShoes.Core.Shoes.Types;
using System;
using ShopShoes.Core.Footwear;

namespace ShopShoes
{
	public class Program
	{
		public static void Main(String[] args)
		{
			new Program().Run();
		}

		private void Run()
		{
			AbstractFootwear shoes = new Shoes(41);
		}
	}
}