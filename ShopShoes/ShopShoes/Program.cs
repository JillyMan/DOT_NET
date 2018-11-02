using System;
using System.Collections.Generic;
using ShopShoes.Complect;
using ShopShoes.Core.Model;
using ShopShoes.Core.Model.Shoes;
using ShopShoes.Core.Model.Shoes.Season.Summer;

namespace ShopShoes
{
	public class Program
	{
		private Shop shop = new Shop();

		public static void Main(string[] args)
		{
			new Program().Run();
		}

		public void Run()
		{
			Sorting();
			Filtering();
			MakeSummerFamilyComplect();
		}

		public void MakeSummerFamilyComplect()
		{
			Console.WriteLine("Assembly Summer family complect: ");
			ComplectFamily<IShoesSummer> complect = 
				new ComplectFamily<IShoesSummer>(new List<IShoesSummer>(), new List<IShoesSummer>(), new List<IShoesSummer>());

			Console.WriteLine("Kid complect: ");
			AssemblySummerComplect(complect.KidComplect, shop.GetSummerShoesKid());

			Console.WriteLine("Woman complect: ");
			AssemblySummerComplect(complect.WomanComplect, shop.GetSummerShoesWoman());

			Console.WriteLine("Man complect: ");
			AssemblySummerComplect(complect.ManComplect, shop.GetSummerShoesMan());

			Console.WriteLine("Price family complect = " + complect.FullPrice());
		}

		private void AssemblySummerComplect(ComplectShoes<IShoesSummer> complectShoes, IList<IShoesSummer> shoesFromShop)
		{
			for (int i = 0; i < shoesFromShop.Count; ++i)
			{
				Console.WriteLine((i+1) + "----" + shoesFromShop[i]);
			}
			Console.WriteLine("Select shoes. If you wonna finish press 0");
			bool result = false;
			do
			{
				int input = GetInputFromConsole();
				if (input > 0 && input <= shoesFromShop.Count)
				{
					result = true;
					complectShoes.Add(shoesFromShop[input - 1]);
				}
				else if (input == -1)
				{
					Console.WriteLine("Incorrect input, please try again");
				}
				else
				{
					result = false;
				}
			} while (result);
		}

		public int GetInputFromConsole()
		{
			Console.WriteLine("Input number: ");
			string inputLine = Console.ReadLine();
			if(inputLine == null)
			{
				return -1;
			}
			return Int32.Parse(inputLine);
		}

		public void Sorting()
		{
			Console.WriteLine("Sort by materials");
			foreach (var shoes in shop.GetSortByMaterial())
			{
				Console.WriteLine(shoes);
			}
			Console.WriteLine("--------------------");
			Console.WriteLine("Sort by Price");
			foreach (var shoes in shop.GetSortByPrice())
			{
				Console.WriteLine(shoes);
			}
			Console.WriteLine("--------------------\n");
			Sleep();
		}

		public void Filtering()
		{
			Console.WriteLine("--------------------");
			Console.WriteLine("Filter by price (100, 200)");
			foreach (var shoes in shop.GetFilterBySize(100, 200))
			{
				Console.WriteLine(shoes);
			}

			Console.WriteLine("Filter by Material.LEATHER");
			foreach (var shoes in shop.GetFilterByMaterial(TypeMaterial.LEATHER))
			{
				Console.WriteLine(shoes);
			}
			Console.WriteLine("--------------------");
			Sleep();
		}

		private void Sleep()
		{
			Console.WriteLine("Press Any button: ");
			Console.ReadKey();
			Console.Clear();
		}
	}
}
