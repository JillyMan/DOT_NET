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

		private void MakeSummerFamilyComplect()
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

			Console.WriteLine("Full price complect = " + complect.FullPrice());
		}

		private void AssemblySummerComplect(ComplectShoes<IShoesSummer> complectShoes, IList<IShoesSummer> shoesFromShop)
		{
			for (int i = 0; i < shoesFromShop.Count; ++i)
			{
				Console.WriteLine((i+1) + " ---- " + shoesFromShop[i]);
			}
			Console.WriteLine($"Select shoes [{1} , {shoesFromShop.Count}]. If you wonna finish press 0");
			bool result;
			do
			{
				result = true;
				Console.WriteLine("Input number: ");
				int input = GetInputFromConsole();
				if (input > 0 && input <= shoesFromShop.Count)
				{
					complectShoes.Add(shoesFromShop[input - 1]);
				}
				else if(input == -1 || input >= shoesFromShop.Count)
				{
					Console.WriteLine("Incorrect input, please try again");
				}
				else
				{
					result = false;
				}
			} while (result);
		}

		private int GetInputFromConsole()
		{
			string inputLine = Console.ReadLine();
			int result;
			try
			{
				result = Int32.Parse(inputLine);
			}
			catch (FormatException e)
			{
				result = -1;
			}
			return result;
		}

		private void Sorting()
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

		private void Filtering()
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
