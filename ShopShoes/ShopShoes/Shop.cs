using System.Collections.Generic;
using ShopShoes.Util;
using ShopShoes.Core.Model;
using ShopShoes.Core.Model.Shoes;
using ShopShoes.Core.Model.Shoes.Season.Summer;

namespace ShopShoes
{
	public class Shop
	{
		private List<IShoes> Shoes = new List<IShoes>();
		private SorterShoes sorter = new SorterShoes();
		private FilterShoes filter = new FilterShoes();

		private IList<IShoesSummer> KidSummerShoes = new List<IShoesSummer>
		{
			new Sandals(32, 100, "brand-1", TypeColor.BLACK, TypeMaterial.LEATHER, TypeShoes.KID),
			new Sandals(31, 200, "brand-2", TypeColor.RED, TypeMaterial.TEXTILES, TypeShoes.KID),
			new Sandals(33, 300, "brand-3", TypeColor.GREEN, TypeMaterial.RUBBER, TypeShoes.KID),
		};
		private IList<IShoesSummer> WomanSummerShoes = new List<IShoesSummer>
		{
			new HighHeels(38, 100, "brand-1", TypeColor.BLUE, TypeMaterial.LEATHER),
			new BalletShoes(37, 200, "brand-5", TypeColor.GREEN, TypeMaterial.TEXTILES),
			new Sandals(37, 300, "brand-2", TypeColor.WHITE, TypeMaterial.RUBBER, TypeShoes.WOMAN),
		};
		private IList<IShoesSummer> ManSummerShoes = new List<IShoesSummer>
		{
			new Sandals(43, 145, "brand-1", TypeColor.BLACK, TypeMaterial.LEATHER, TypeShoes.MAN),
			new Sandals(42, 231, "brand-6", TypeColor.RED, TypeMaterial.TEXTILES, TypeShoes.MAN),
			new Sandals(43, 347, "brand-3", TypeColor.WHITE, TypeMaterial.RUBBER, TypeShoes.MAN),
		};

		public Shop()
		{
			Init();
		}

		private void Init()
		{
			Shoes.AddRange(KidSummerShoes);
			Shoes.AddRange(WomanSummerShoes);
			Shoes.AddRange(ManSummerShoes);
		}

		public IList<IShoes> GetAll()
		{
			return Shoes;
		}

		public IList<IShoesSummer> GetSummerShoesKid()
		{
			return KidSummerShoes;
		}

		public IList<IShoesSummer> GetSummerShoesWoman()
		{
			return WomanSummerShoes;
		}

		public IList<IShoesSummer> GetSummerShoesMan()
		{
			return ManSummerShoes;
		}

		public IEnumerable<IShoes> GetSortByPrice()
		{
			return sorter.SortByPrice(Shoes);
		}

		public IEnumerable<IShoes> GetSortByMaterial()
		{
			return sorter.SortByMaterial(Shoes);
		}

		public IEnumerable<IShoes> GetFilterBySize(int min, int max)
		{
			return filter.FilterBySize(Shoes, min, max);
		}

		public IEnumerable<IShoes> FilterByType(TypeShoes type)
		{
			return filter.FilterByType(Shoes, type);
		}

		public IEnumerable<IShoes> GetFilterByMaterial(TypeMaterial material)
		{
			return filter.FilterByMaterial(Shoes, material);
		}
	}
}
