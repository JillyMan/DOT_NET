using ShopShoes.Builder;
using ShopShoes.Complect;
using ShopShoes.Core.Shoes;
using ShopShoes.Core.Shoes.Types;
using System;
using System.Collections.Generic;

namespace ShopShoes
{
	public class Shop
	{
		public List<Shoes> Shoes;
			
		public Shop()
		{
			Shoes = new List<Shoes>()
			{
				new Shoes(41, "Shoes_1" , ShoesTypeMaterial.LEATHER,	ShoesPersonType.Man,	ShoesSeasonType.Summer, 100),
				new Shoes(41, "Shoes_2" , ShoesTypeMaterial.RUBBER,		ShoesPersonType.Man,	ShoesSeasonType.Winter, 200),
				new Shoes(41, "Shoes_3" , ShoesTypeMaterial.TEXTILES,	ShoesPersonType.Man,	ShoesSeasonType.Autumn, 300),
				new Shoes(39, "Shoes_4" , ShoesTypeMaterial.LEATHER,	ShoesPersonType.Man,	ShoesSeasonType.Spring, 400),
				new Shoes(41, "Shoes_5" , ShoesTypeMaterial.LEATHER,	ShoesPersonType.Woman,	ShoesSeasonType.Summer, 100),
				new Shoes(41, "Shoes_6" , ShoesTypeMaterial.LEATHER,    ShoesPersonType.Woman,	ShoesSeasonType.Winter, 200),
				new Shoes(39, "Shoes_7" , ShoesTypeMaterial.SYNTHETICS, ShoesPersonType.Woman,	ShoesSeasonType.Autumn, 300),
				new Shoes(43, "Shoes_8" , ShoesTypeMaterial.LEATHER,	ShoesPersonType.Woman,	ShoesSeasonType.Spring, 400),
				new Shoes(41, "Shoes_9" , ShoesTypeMaterial.TEXTILES,	ShoesPersonType.Kid,	ShoesSeasonType.Summer, 100),
				new Shoes(41, "Shoes_10", ShoesTypeMaterial.SYNTHETICS, ShoesPersonType.Kid,	ShoesSeasonType.Summer, 200),
				new Shoes(39, "Shoes_11", ShoesTypeMaterial.LEATHER,	ShoesPersonType.Kid,	ShoesSeasonType.Autumn, 300),
				new Shoes(37, "Shoes_12", ShoesTypeMaterial.LEATHER,	ShoesPersonType.Kid,	ShoesSeasonType.Spring, 400),
				new Shoes(37, "Shoes_12", ShoesTypeMaterial.LEATHER,    ShoesPersonType.Kid,    ShoesSeasonType.Summer, 400),
				new Shoes(39, "Shoes_13", ShoesTypeMaterial.TEXTILES,	ShoesPersonType.Woman,	ShoesSeasonType.Spring, 100),
				new Shoes(42, "Shoes_14", ShoesTypeMaterial.RUBBER,		ShoesPersonType.Man,	ShoesSeasonType.Winter, 200),
				new Shoes(38, "Shoes_15", ShoesTypeMaterial.RUBBER,		ShoesPersonType.Kid,	ShoesSeasonType.Summer, 100),
			};

		}

		public ShoesComplect GetComplect(IShoesComplectBuilder builder, int money)
		{
			ShoesComplect complect = builder.Make(Shoes);
			var fullPrice = complect.GetFullPrice();

			if(fullPrice > money)
			{
				throw new Exception($"Not enough money. Have {money}, but need {fullPrice}");
			}
			return complect;

		}
	}
}
