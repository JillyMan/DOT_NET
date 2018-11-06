using ShopShoes.Builder;
using ShopShoes.Builder.Family;
using ShopShoes.Builder.Kid;
using ShopShoes.Builder.Woman;
using ShopShoes.Complect;
using ShopShoes.Core.Shoes;
using ShopShoes.Core.Shoes.Types;
using ShopShoes.Core.Shoes.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
			Shop shop = new Shop();
			IShoesComplectBuilder familyComplectBuilder = new FamilySummerComplectBuilder();
			ShoesComplect familyComplect = null;
			Console.BackgroundColor = ConsoleColor.Red;
			Console.WriteLine("Make Family summer complect for price NO MORE 1000 ");
			Console.BackgroundColor = ConsoleColor.Black;
			try
			{
				familyComplect = shop.GetComplect(familyComplectBuilder, 1000);
				PrintComplectToConsole(familyComplect);
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
			}

			IShoesComplectBuilder kidSummerComplectBuilder = new KidSummerComplectBuilder();
			ShoesComplect kidComplect;
			int priceForKidComplect = 900;
			Console.BackgroundColor = ConsoleColor.Red;
			Console.WriteLine($"Make Kid summer complect for price NO MORE {priceForKidComplect }");
			Console.BackgroundColor = ConsoleColor.Black;
			try
			{
				kidComplect = shop.GetComplect(kidSummerComplectBuilder, priceForKidComplect);
				PrintComplectToConsole(kidComplect);
			}
			catch(Exception e)
			{
				Console.WriteLine(e.Message);
			}
		}

		private void PrintComplectToConsole(ShoesComplect complect)
		{
			Console.WriteLine($"The cost complect {complect.GetFullPrice()}");
			
			foreach (var shoes in complect.Shoes.SortByMaterial())
			{
				Console.WriteLine(shoes);
			}
		}
	}
}